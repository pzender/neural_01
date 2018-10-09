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
            Perceptron perceptron = null;
            string cmd = "";
            while (cmd != "exit")
            {
                try
                {
                    cmd = Console.ReadLine();
                    InputDataGenerator inputDataGenerator = new InputDataGenerator();
                    var data = inputDataGenerator.Generate();
                    switch (cmd)
                    {
                        case "simple":
                            perceptron = new SimplePerceptron(data.Keys.First().Count());
                            break;
                        case "adaline":
                            perceptron = new AdalinePerceptron(data.Keys.First().Count());
                            break;
                        default:
                            continue;
                    }
                    if (perceptron != null) {
                        perceptron.Learn(data);
                        foreach (double[] inputvector in inputDataGenerator.Generate().Keys)
                        {
                            Console.WriteLine($"{inputvector[0]} && {inputvector[1]} <=> {perceptron.Predict(inputvector)}");
                        }
                        foreach (var random_input in inputDataGenerator.GenerateRandom())
                        {
                            Console.WriteLine($"{random_input[0]} && {random_input[1]} <=> {perceptron.Predict(random_input)}");
                        }

                    }
                }
                catch(InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
