using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task1Shapes
{
    public class Test
    {
        private static double accuracy = 0.001;
        public static double Accuracy 
        { 
            get { return accuracy; }
            set { accuracy = Math.Abs(value); } 
        }

        public static string TestShapes(int numberOfTests)
        {
            if (numberOfTests < 1)
            {
                throw new ArgumentException();
            }

            StringBuilder result = new StringBuilder();

            Rectangle rectangle;
            for (int i = 1; i < numberOfTests+1; i++)
            {
                rectangle = new Rectangle(i, i);
                if (Math.Abs(rectangle.CalculateSurface() - (i * i)) > Accuracy)
                {
                    result.Append("Rectangle has failed the test.\n");
                    break;
                }
                if (i == numberOfTests)
                {
                    result.Append("Rectangle has passed the test.\n");
                }
            }
            Triangle triangle;
            for (int i = 1; i < numberOfTests+1; i++)
            {
                triangle = new Triangle(i, i);
                if (Math.Abs(triangle.CalculateSurface() - ((double)i * i / 2)) > Accuracy)
                {
                    result.Append("Triangle has failed the test.\n");
                    break;
                }
                if (i == numberOfTests)
                {
                    result.Append("Triangle has passed the test.\n");
                }
            }

            Circle circle;
            for (int i = 1; i < numberOfTests+1; i++)
            {
                circle = new Circle(i);
                if (Math.Abs(circle.CalculateSurface() - (Math.PI * i * i)) > Accuracy)
                {
                    result.Append("Circle has failed the test.\n");
                    break;
                }
                if (i == numberOfTests)
                {
                    result.Append("Circle has passed the test.\n");
                }
            }

            return result.ToString();
        }
    }
}
