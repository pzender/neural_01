using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieciNeuronowe01
{
    static class InputDataGenerator
    {
        public static Dictionary<double[], double> Generate()
        {
            SimpleConfigXml configXml = new SimpleConfigXml(@"..\..\config.xml");
            bool add_bias = configXml.GetDoubleValue("add_bias") == 1;
            double value_for_true = configXml.GetDoubleValue("activate_function_true");
            double value_for_false = configXml.GetDoubleValue("activate_function_false");

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
    }
}
