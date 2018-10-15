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
            string cmd = "";
            while (cmd != "exit")
            {
                
                try
                {
                    cmd = Console.ReadLine();
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    InputDataGenerator inputDataGenerator = new InputDataGenerator();
                    //foreach (var data_point in inputDataGenerator.Generate())
                    //{
                    //    Console.WriteLine($"{data_point.Key[0]} & {data_point.Key[1]} => {data_point.Value}");
                    //}
                    //foreach (var data_point in inputDataGenerator.GenerateLightApprox())
                    //{
                    //    Console.WriteLine($"{data_point.Key[0]} & {data_point.Key[1]} => {data_point.Value}");
                    //}

                    //foreach (var data_point in inputDataGenerator.GenerateStrongApprox())
                    //{
                    //    Console.WriteLine($"{data_point.Key[0]} & {data_point.Key[1]} => {data_point.Value}");
                    //}





                    var data = inputDataGenerator.Generate();
                    if (cmd == "simple")
                    {
                        int iterations = 0, predictions_correct_none = 0, predictions_correct_light = 0, predictions_correct_strong = 0;
                        for (int i = 0; i < 100; i++)
                        {
                            Perceptron perceptron = new SimplePerceptron(data.Keys.First().Count());
                            iterations += perceptron.Learn(data);
                            foreach(var data_point in inputDataGenerator.Generate())
                            {
                                predictions_correct_none += (perceptron.Predict(data_point.Key) == data_point.Value ? 1 : 0);
                            }
                            foreach (var data_point in inputDataGenerator.GenerateLightApprox())
                            {
                                predictions_correct_light += (perceptron.Predict(data_point.Key) == data_point.Value ? 1 : 0);
                            }
                            foreach (var data_point in inputDataGenerator.GenerateStrongApprox())
                            {
                                predictions_correct_strong += (perceptron.Predict(data_point.Key) == data_point.Value ? 1 : 0);
                            }

                        }

                        Console.WriteLine($"****************************\n" +
                            $"\tAvg of 100 runs: \n" +
                            $"\t{iterations / 100.0} iterations per run\n" +
                            $"\t{predictions_correct_none / 4.0}% correct predictions without offset\n" +
                            $"\t{predictions_correct_light / 4.0}% correct predictions with light offset\n" +
                            $"\t{predictions_correct_strong / 4.0}% correct predictions with strong offset\n");
                    }

                    else if (cmd == "adaline")
                    {
                        int iterations = 0, predictions_correct_none = 0, predictions_correct_light = 0, predictions_correct_strong = 0;
                        for (int i = 0; i < 100; i++)
                        {
                            Perceptron perceptron = new AdalinePerceptron(data.Keys.First().Count());
                            iterations += perceptron.Learn(data);
                            foreach (var data_point in inputDataGenerator.Generate())
                            {
                                predictions_correct_none += (perceptron.Predict(data_point.Key) == data_point.Value ? 1 : 0);
                            }
                            foreach (var data_point in inputDataGenerator.GenerateLightApprox())
                            {
                                predictions_correct_light += (perceptron.Predict(data_point.Key) == data_point.Value ? 1 : 0);
                            }
                            foreach (var data_point in inputDataGenerator.GenerateStrongApprox())
                            {
                                predictions_correct_strong += (perceptron.Predict(data_point.Key) == data_point.Value ? 1 : 0);
                            }

                        }

                        Console.WriteLine($"****************************\n" +
                            $"\tAvg of 100 runs: \n" +
                            $"\t{iterations / 100.0} iterations per run\n" +
                            $"\t{predictions_correct_none / 4.0}% correct predictions without offset\n" +
                            $"\t{predictions_correct_light / 4.0}% correct predictions with light offset\n" +
                            $"\t{predictions_correct_strong / 4.0}% correct predictions with strong offset\n");
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
