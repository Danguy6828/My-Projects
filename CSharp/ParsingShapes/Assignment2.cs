using David.Shapes3D;

namespace David.Assignment2 {

    public static class Solver {

            public static double total = 0;
            public static void ReadFile(string[] args) {
            
            foreach (string line in System.IO.File.ReadLines(args[0])) {
                string[] lineData = line.Split(',');

                Shape3D insertedShape;

                switch (lineData[0]) {
                    case "cuboid":
                        insertedShape = new Cuboid(
                            Convert.ToDouble(lineData[2]),
                            Convert.ToDouble(lineData[3]),
                            Convert.ToDouble(lineData[4])
                        );
                    break;

                    case "cube":
                        insertedShape = new Cube(
                            Convert.ToDouble(lineData[2])
                        );
                    break;
                    
                    case "cylinder":
                        insertedShape = new Cylinder(
                            Convert.ToDouble(lineData[2]),
                            Convert.ToDouble(lineData[3])
                        );
                    break;

                    case "sphere":
                            insertedShape = new Sphere(
                            Convert.ToDouble(lineData[2])
                        );
                    break;

                    default:
                        throw new FormatException("Please enter a valid shape!");
                }
                if (lineData[1] == "area") {
                    total += insertedShape.GetSurfaceArea();
                } else if (lineData[1] == "volume") {
                    total += insertedShape.GetVolume();
                }
            }
        }
    }
}