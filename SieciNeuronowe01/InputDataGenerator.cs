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
        public static Random random = new Random();

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

        public Dictionary<double[], double> GenerateLightApprox()
        {
            double offset = (value_for_true - value_for_false) * 0.05;
            if (add_bias) return new Dictionary<double[], double>
            {
                { new double[] { value_for_false + offset, value_for_false + offset, value_for_true }, value_for_false },
                { new double[] { value_for_false + offset, value_for_true - offset, value_for_true }, value_for_false },
                { new double[] { value_for_true - offset, value_for_false + offset, value_for_true }, value_for_false },
                { new double[] { value_for_true - offset, value_for_true - offset, value_for_true }, value_for_true }
            };

            else return new Dictionary<double[], double>
            {
                { new double[] { value_for_false + offset, value_for_false + offset }, value_for_false },
                { new double[] { value_for_false + offset, value_for_true - offset }, value_for_false },
                { new double[] { value_for_true - offset, value_for_false + offset }, value_for_false },
                { new double[] { value_for_true - offset, value_for_true - offset}, value_for_true }
            };
        }
        public Dictionary<double[], double> GenerateStrongApprox()
        {
            double offset = (value_for_true - value_for_false) * 0.3;
            if (add_bias) return new Dictionary<double[], double>
            {
                { new double[] { value_for_false + offset, value_for_false + offset, value_for_true }, value_for_false },
                { new double[] { value_for_false + offset, value_for_true - offset, value_for_true }, value_for_false },
                { new double[] { value_for_true - offset, value_for_false + offset, value_for_true }, value_for_false },
                { new double[] { value_for_true - offset, value_for_true - offset, value_for_true }, value_for_true }
            };

            else return new Dictionary<double[], double>
            {
                { new double[] { value_for_false + offset, value_for_false + offset }, value_for_false },
                { new double[] { value_for_false + offset, value_for_true - offset }, value_for_false },
                { new double[] { value_for_true - offset, value_for_false + offset }, value_for_false },
                { new double[] { value_for_true - offset, value_for_true - offset }, value_for_true }
            };
        }

        public InputDataGenerator()
        {
            add_bias = configXml.GetDoubleValue("add_bias") == 1;
            value_for_true = configXml.GetDoubleValue("activate_function_true");
            value_for_false = configXml.GetDoubleValue("activate_function_false");
        }
    }
}
