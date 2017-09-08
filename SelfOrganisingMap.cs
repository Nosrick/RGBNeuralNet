using System;
using System.Collections.Generic;

namespace RGBNeuralNet
{
    public class SelfOrganisingMap
    {
        protected List<Node> m_Nodes;
        protected Node m_LastWinner;

        protected Random m_Roller;

        public SelfOrganisingMap(int width, int height)
        {
            m_Roller = new Random();
            m_Nodes = new List<Node>();

            Width = width;
            Height = height;

            for(int x = 0; x < width; x++)
            {
                for(int y = 0; y < height; y++)
                {
                    m_Nodes.Add(new Node(x, y, x + 1, y + 1, Node.INPUT_SAMPLE_SIZE));
                }
            }
        }

        public bool Epoch(List<List<double>> data)
        {
            if(data[0].Count != Node.INPUT_SAMPLE_SIZE)
            {
                return false;
            }

            int result = m_Roller.Next(0, data.Count);
            m_LastWinner = GetBestMatch(data[result]);

            double neighbourhood = Math.Sqrt(Width * Height) / 10;
            double widthSquared = neighbourhood * neighbourhood;

            for (int i = 0; i < m_Nodes.Count; i++)
            {
                double distanceSquared = (m_LastWinner.Vector.X - m_Nodes[i].Vector.X) *
                                        (m_LastWinner.Vector.X - m_Nodes[i].Vector.X) +
                                        (m_LastWinner.Vector.Y - m_Nodes[i].Vector.Y) *
                                        (m_LastWinner.Vector.Y - m_Nodes[i].Vector.Y);

                if(distanceSquared < widthSquared)
                {
                    double influence = Math.Exp((-distanceSquared) / (2 * widthSquared));

                    m_Nodes[i].AdjustWeights(data[result], 1.0d, influence);
                }
            }

            return true;
        }

        public Node GetBestMatch(List<double> inputs)
        {
            double lowestDistance = double.MaxValue;
            Node winner = null;
            foreach(Node node in m_Nodes)
            {
                double distance = node.GetDistance(inputs);
                if(distance < lowestDistance)
                {
                    winner = node;
                    lowestDistance = distance;
                }
            }

            return winner;
        }

        public Node LastWinner
        {
            get
            {
                return m_LastWinner;
            }
        }

        protected int Width
        {
            get;
            set;
        }

        protected int Height
        {
            get;
            set;
        }
    }
}
