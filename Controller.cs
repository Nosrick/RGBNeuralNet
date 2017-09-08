using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBNeuralNet
{
    public class Controller
    {
        protected List<List<double>> m_TrainingSet;

        public Controller()
        {
            m_TrainingSet = new List<List<double>>();
        }

        public void CreateTrainingSet()
        {
            m_TrainingSet = new List<List<double>>();

            List<double> red = new List<double>(3);
            red.Add(1.0d);
            red.Add(0);
            red.Add(0);

            List<double> green = new List<double>(3);
            green.Add(0);
            green.Add(1.0d);
            green.Add(0);

            List<double> blue = new List<double>(3);
            blue.Add(0);
            blue.Add(0);
            blue.Add(1.0d);

            m_TrainingSet.Add(red);
            m_TrainingSet.Add(green);
            m_TrainingSet.Add(blue);
        }

        public List<List<double>> TrainingSet
        {
            get
            {
                return m_TrainingSet;
            }
        }
    }
}
