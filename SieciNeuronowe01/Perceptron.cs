using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieciNeuronowe01
{
    public abstract class Perceptron
    {
        protected double threshold;
        protected double[] input_weights;
        protected SimpleConfigXml configXml = new SimpleConfigXml(@"..\..\config.xml");
        protected double learning_coefficient;

        protected double Net(double[] inputs)
        {
            double net = 0;
            for (int i = 0; i < inputs.Length; i++)
            {
                net += inputs[i] * input_weights[i];
            }
            return net;
        }

        public double Predict(double[] inputs)
        {
             return Net(inputs) > threshold ?
                configXml.GetDoubleValue("activate_function_true") :
                configXml.GetDoubleValue("activate_function_false");
        }
        public abstract void Learn(Dictionary<double[], double> learning_data);

        public Perceptron(int inputs)
        {
            learning_coefficient = configXml.GetDoubleValue("learning_coefficient");
            threshold = configXml.GetDoubleValue("threshold");
            input_weights = new double[inputs];
            Random r = new Random();
            for (int i = 0; i < input_weights.Length; i++)
            {
                input_weights[i] = 2 * (r.NextDouble() - 0.5) * configXml.GetDoubleValue("starting_weight_range");
            }
        }
    }
}
