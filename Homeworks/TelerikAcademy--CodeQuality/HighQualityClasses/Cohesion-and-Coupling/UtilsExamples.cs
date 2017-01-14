using System;

namespace CohesionAndCoupling
{
    class UtilsExamples
    {
        static void Main()
        {
            try 
	        {
                Console.WriteLine(JustFileNameHandler.GetFileExtension("example"));
	        }
	        catch (ArgumentException ae)
	        {
                Console.WriteLine(ae.Message);
	        }
            Console.WriteLine(JustFileNameHandler.GetFileExtension("example.pdf"));
            Console.WriteLine(JustFileNameHandler.GetFileExtension("example.new.pdf"));

            Console.WriteLine(JustFileNameHandler.GetFileNameWithoutExtension("example"));
            Console.WriteLine(JustFileNameHandler.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(JustFileNameHandler.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                JustGeometry.CalcDistance2D(
                    new Point2D(1, -2),
                    new Point2D(3, 4))
                );
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                JustGeometry.CalcDistance3D(
                    new Point3D(5, 2, -1),
                    new Point3D(3, -6, 4)
                ));

            Figure3D figure = new Figure3D(3, 4, 5);
            Console.WriteLine("Volume = {0:f2}", figure.CalcVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", figure.CalcDiagonal3D());
            Console.WriteLine("Diagonal XY = {0:f2}", figure.CalcDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", figure.CalcDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", figure.CalcDiagonalYZ());
        }
    }
}
