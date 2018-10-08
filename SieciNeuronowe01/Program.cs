using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SieciNeuronowe01
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++)
            {
                var data = InputDataGenerator.Generate();
                Perceptron perceptron = new AdalinePerceptron(data.Keys.First().Count());
                perceptron.Learn(data);

                foreach (double[] inputvector in InputDataGenerator.Generate().Keys)
                {
                    Console.WriteLine($"{inputvector[0]} && {inputvector[1]} <=> {perceptron.Predict(inputvector)}");
                }

                Console.ReadLine();
            }
        }
    }
}
