using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieciNeuronowe01
{
    class SimplePerceptron : Perceptron
    {        
        public override void Learn(Dictionary<double[], double> learning_data)
        {
            int k = 0;
            double[] next_weights = new double[input_weights.Length];
            Array.Copy(input_weights, next_weights, next_weights.Length);
            bool weights_changed = true;
            while (weights_changed)
            {
                
                weights_changed = false;
                Console.WriteLine($"Iteration {k}. Weights: {string.Join("; ", input_weights)}");
                foreach(double[] input_vector in learning_data.Keys)
                {
                    double predicted = Predict(input_vector);
                    for (int j = 0; j < input_vector.Length; j++)
                    {
                        double weight_change = learning_coefficient * (learning_data[input_vector] - predicted) * input_vector[j];
                        next_weights[j] += weight_change;
                        weights_changed = weights_changed || weight_change != 0;
                    }
                }
                k++;
                Array.Copy(next_weights, input_weights, next_weights.Length);
            }
        }
        public SimplePerceptron(int inputs) : base(inputs) { }
    }
}
