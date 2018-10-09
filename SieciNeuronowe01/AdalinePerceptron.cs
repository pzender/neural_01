﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieciNeuronowe01
{
    class AdalinePerceptron : Perceptron
    {
        double targetMSE;

        

        double MeanSquaredError(Dictionary<double[], double> learning_data)
        {
            double tse = 0;
            foreach(var input in learning_data.Keys)
            {
                double net = Net(input);
                
                tse += (learning_data[input] - net) * (learning_data[input] - net);
            }

            return (tse/learning_data.Keys.First().Count());
        }
        public override void Learn(Dictionary<double[], double> learning_data)
        {
            int k = 0;
            double[] next_weights = new double[input_weights.Length];
            Array.Copy(input_weights, next_weights, next_weights.Length);

            while (MeanSquaredError(learning_data) > targetMSE)
            {
                foreach (var input_vector in learning_data.Keys)
                {
                    double net = Net(input_vector);
                    for (int j = 0; j < input_vector.Length; j++)
                    {
                        double weight_change = 2 * learning_coefficient * (learning_data[input_vector] - net) * input_vector[j];
                        next_weights[j] += weight_change;
                    }
                }
                
                if (k > 250) throw new InvalidOperationException("Infinite loop");
                Console.WriteLine($"Iteration {k}. Weights: {string.Join("; ", input_weights)} *MSE: {MeanSquaredError(learning_data)}");
                Array.Copy(next_weights, input_weights, next_weights.Length);
                k++;
            }
        }

        public AdalinePerceptron(int inputs) : base(inputs)
        {
            targetMSE = configXml.GetDoubleValue("targetMSE");
        }
    }
}
