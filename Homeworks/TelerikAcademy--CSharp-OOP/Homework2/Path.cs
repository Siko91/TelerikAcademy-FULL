using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Homework2
{
    public class Path
    {
        private List<Point> pointList = new List<Point>();

        public int Length
        {
            get { return this.pointList.Count; }
        }

        public Point this[int index]
        {
            get { return this.pointList[index]; }
        }

        public void AddPoint(Point p)
        {
            pointList.Add(p);
        }
        public void AddPoint(int coordX, int coordY, int coordZ)
        {
            pointList.Add(new Point(coordX, coordY, coordZ));
        }

        public static class PathStorage
        {
            public static void Store(Path path, string fileName)
            {
                using (StreamWriter PathStore = new StreamWriter(fileName))
                {
                    foreach (Point p in path.pointList)
                    {
                        PathStore.WriteLine(p.ToString());
                    }
                }
            }
            public static Path Load(string fileName)
            {
                if (!File.Exists(fileName))
                { throw new ArgumentException("There is no such file."); }

                Path path = new Path();
                using (StreamReader PathLoad = new StreamReader(fileName))
                {
                    string line = PathLoad.ReadLine();
                    while (line != null)
                    {
                        string[] nums = line.Split(' ');
                        path.AddPoint(int.Parse(nums[0]), int.Parse(nums[1]), int.Parse(nums[2]));
                        line = PathLoad.ReadLine();
                    }
                }
                return path;
            }
        }
    }
}
