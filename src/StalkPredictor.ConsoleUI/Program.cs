using StalkPredictor.Contracts;
using StalkPredictor.Domain;
using System;
using System.Collections.Generic;

namespace StalkPredictor.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            PredictFor(44);
            PredictFor(80);
            PredictFor(90);
            PredictFor(100);
            PredictFor(86, 81, 77, 55);
            PredictFor(90, 81, 77, 78);
            PredictFor(90, 210);


            Console.ReadLine();
        }

        private static void PredictFor(params int[] prices)
        {
            IPredictor predictor = new Predictor();

            var pricelist = String.Join(", ", prices);

            var possiblePatterns = predictor.GetPossibleStalkPatterns(new CurrentWeekData(100, prices));
            var possiblePatternNames = String.Join(", ", possiblePatterns);

            Console.WriteLine($"Prices:            {pricelist}");
            Console.WriteLine($"Possible patterns: {possiblePatternNames}");
            Console.WriteLine("---");
        }
    }
}
