using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieciNeuronowe01
{
    public class InputDataGenerator
    {
        SimpleConfigXml configXml = new SimpleConfigXml(@"..\..\config.xml");
        bool add_bias;
        double value_for_true;
        double value_for_false;

        public Dictionary<double[], double> Generate()
        {

            if(add_bias) return new Dictionary<double[], double>
            {
                { new double[] { value_for_false, value_for_false, value_for_true }, value_for_false },
                { new double[] { value_for_false, value_for_true, value_for_true }, value_for_false },
                { new double[] { value_for_true, value_for_false, value_for_true }, value_for_false },
                { new double[] { value_for_true, value_for_true, value_for_true }, value_for_true }
            };

            else return new Dictionary<double[], double>
            {
                { new double[] { value_for_false, value_for_false }, value_for_false },
                { new double[] { value_for_false, value_for_true }, value_for_false },
                { new double[] { value_for_true, value_for_false }, value_for_false },
                { new double[] { value_for_true, value_for_true }, value_for_true }
            };
        }

        public List<double[]> GenerateRandom()
        {
            List<double[]> res = new List<double[]>();
            Random r = new Random();
            for(int i = 0; i < 5; i++)
            {
                if (add_bias)
                    res.Add(new double[] { r.NextDouble(), r.NextDouble(), value_for_true });
                else res.Add(new double[] { r.NextDouble(), r.NextDouble() });
            }
            return res;
        }
        public InputDataGenerator()
        {
            add_bias = configXml.GetDoubleValue("add_bias") == 1;
            value_for_true = configXml.GetDoubleValue("activate_function_true");
            value_for_false = configXml.GetDoubleValue("activate_function_false");
        }
    }
}
