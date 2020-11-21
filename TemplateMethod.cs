using System;

namespace OOP
{
    class TemplateMethod
    {
        static void Main(string[] args)
        {
            ScoringAlgorithm algorithm;

            Console.WriteLine("Men");
            algorithm = new MensScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 10)));

            Console.WriteLine("Women");
            algorithm = new WomensScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 10)));

            Console.WriteLine("Children");
            algorithm = new ChildrensScoringAlgorithm();
            Console.WriteLine(algorithm.GenerateScore(10, new TimeSpan(0, 2, 10)));
        }
    }

    abstract class ScoringAlgorithm
    {
        public int GenerateScore(int hits, TimeSpan time)
        {
            int score = CalculateBaseScore(hits);
            int reduction = CalculateReduction(time);

            return CalculateOverallScore(score, reduction);
        }

        public abstract int CalculateOverallScore(int score, int reduction);
        public abstract int CalculateReduction(TimeSpan time);
        public abstract int CalculateBaseScore(int hits);
    }

    class MensScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }
        
        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 5;
        }
        
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }
    }

    class WomensScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }
        
        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 3;
        }
        
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }
    }

    class ChildrensScoringAlgorithm : ScoringAlgorithm
    {
        public override int CalculateOverallScore(int score, int reduction)
        {
            return score - reduction;
        }
        
        public override int CalculateReduction(TimeSpan time)
        {
            return (int)time.TotalSeconds / 2;
        }
        
        public override int CalculateBaseScore(int hits)
        {
            return hits * 100;
        }
    }
}
