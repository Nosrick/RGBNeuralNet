using System;
using System.Collections.Generic;

namespace RGBNeuralNet
{
    public class Node
    {
        protected List<double> m_Weights;

        protected static Random m_Roller = new Random();

        public const int INPUT_SAMPLE_SIZE = 3;

        public Node(int left, int top, int width, int height, int weightsCount)
        {
            Bounds = new Rectangle(left, top, width, height);
            m_Weights = new List<double>();

            //Initialise the weights to 0 < weight < 1
            for(int i = 0; i < weightsCount; i++)
            {
                m_Weights.Add(m_Roller.NextDouble());
            }

            //Calculate the node's centre point
            Vector = new Vector(left + (width / 2), top + (height / 2));
        }

        public double GetDistance(List<double> inputList)
        {
            double distance = 0;

            //Using the Euclidian distance
            for(int i = 0; i < m_Weights.Count; i++)
            {
                distance += (inputList[i] - m_Weights[i]) * (inputList[i] - m_Weights[i]);
            }

            distance = Math.Sqrt(distance);

            return distance;
        }

        public void AdjustWeights(List<double> target, double learningRate, double influence)
        {
            for(int i = 0; i < m_Weights.Count; i++)
            {
                m_Weights[i] += learningRate * influence * (target[i] * m_Weights[i]);
            }
        }

        public Vector Vector
        {
            get;
            set;
        }

        public Rectangle Bounds
        {
            get;
            set;
        }

        public List<double> Weights
        {
            get
            {
                return m_Weights;
            }
        }
    }
}
