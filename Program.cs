using System;
using System.Collections.Generic;

namespace RGBNeuralNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Controller controller = new Controller();
            controller.CreateTrainingSet();

            SelfOrganisingMap brain = new SelfOrganisingMap(10, 10);
            for (int i = 0; i < 10; i++)
            {
                brain.Epoch(controller.TrainingSet);
            }

            Console.WriteLine("Welcome to RGBNeuralNet. Enter a colour value to use. For example: FFFFFF");
            while (true)
            {
                string input = Console.ReadLine();
                List<double> colours = ColourConverter.Convert(input);

                Node winner = brain.GetBestMatch(colours);
                Console.WriteLine();
                Console.WriteLine("Winner is:");
                if (winner != null)
                {
                    Console.WriteLine("Red: " + winner.Weights[0]);
                    Console.WriteLine("Green: " + winner.Weights[1]);
                    Console.WriteLine("Blue: " + winner.Weights[2]);
                }
                else
                {
                    Console.WriteLine("NULL");
                }
            }
        }
    }
}
