using David.Shapes3D;

namespace Tester {
    public class Tester {
        public static bool CheckValues(string valueName, double targetValue, double errorRange, double actualValue) {
            // Checking for success first
            double minValue = targetValue - errorRange;
            double maxValue = targetValue + errorRange;
            bool success = minValue < actualValue && actualValue < maxValue;
            if (success) {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"    {valueName} check successful.");
            } else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"    {valueName} check unsuccessful.");
            }
            Console.WriteLine($"    Expected {targetValue} and got {actualValue}.");
            Console.ResetColor();
            return success;
        }

        public static int TestShape(Shape3D testShape, double targetSurfaceArea, double targetVolume, double errorRange = 0.05) {
            string shapeName = testShape.GetType().Name;
            // Printing message for what we're testing
            Console.WriteLine($"Testing our `{shapeName}`.");

            // Checking our target Surface Area
            double surfaceArea = testShape.GetSurfaceArea();
            bool saCheck = CheckValues("Surface Area", targetSurfaceArea, errorRange, surfaceArea);

            // Checking our target Volume
            double volume = testShape.GetVolume();
            bool vCheck = CheckValues("Volume", targetVolume, errorRange, volume);

            // Returning number of falses
            if (saCheck & vCheck) {
                return 0;
            } else if(saCheck || vCheck) {
                return 1;
            } else {
                return 2;
            }
        }
        public static void Main() {
            /*
            cuboid,4.5910,2.1215,3.3676 = 64.689643, 32.7997723694
            cube,3.5312 = 74.81624064 & 44.031851491328
            cylinder,4.9448,1.5906 = 203.04896 & 122.1823
            sphere,volume,4.2586 = 227.8996 & 323.51108
            */
            int errors = 0;

            errors += TestShape(new Cuboid(4.5910,2.1215,3.3676), 64.689643, 32.7997723694);
            errors += TestShape(new Cube(3.5312), 74.81624064, 44.031851491328);
            errors += TestShape(new Cylinder(4.9448,1.5906), 203.04896, 122.1823);
            errors += TestShape(new Sphere(4.2586), 227.8996, 323.51108);

            // Coloring depending on error numbers
            Console.WriteLine("");
            if (errors > 0) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Test failed!");
            } else {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Test passed!");
            }

            // Printing error count message
            Console.WriteLine($"There were {errors} total errors.");
            Console.ResetColor();
        }
    }
}