using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieciNeuronowe01
{
    class AdalinePerceptron : Perceptron
    {
        double targetMSE = 0.5;

        double MeanSquaredError(Dictionary<double[], double> learning_data)
        {
            double mse = 0;
            foreach(var input in learning_data.Keys)
            {
                double predicted = Predict(input);
                mse += (learning_data[input] - predicted) * (learning_data[input] - predicted);
            }

            return mse;
        }
        public override void Learn(Dictionary<double[], double> learning_data)
        {
            int k = 0;
            double[] next_weights = new double[input_weights.Length];
            Array.Copy(input_weights, next_weights, next_weights.Length);

            while (MeanSquaredError(learning_data) >= targetMSE)
            {
                Console.WriteLine($"Iteration {k}. Weights: {string.Join("; ", input_weights)}");

                foreach (var input_vector in learning_data.Keys)
                {
                    double predicted = Predict(input_vector);
                    for (int j = 0; j < input_vector.Length; j++)
                    {
                        double weight_change = learning_coefficient * (learning_data[input_vector] - predicted) * input_vector[j];
                        next_weights[j] += weight_change;
                    }
                }
                k++;
                Array.Copy(next_weights, input_weights, next_weights.Length);
            }
        }

        public AdalinePerceptron(int inputs) : base(inputs) { }
    }
}
