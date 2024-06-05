using Shapes3D;

namespace Assignment3 {

    public static class Solver {

            public static double total = 0;

            public static void ReadFile(string[] args) {
                List<Shape3D> shapesList = new List<Shape3D>() {};
                double areaMultiplier = 0;
                double volumeMultiplier = 0;
            
            foreach (string line in System.IO.File.ReadLines(args[0])) {
                string[] lineData = line.Split(',');

                Shape3D insertedShape;

                switch (lineData[0]) {
                    case "cuboid":
                        insertedShape = new Cuboid(
                            Convert.ToDouble(lineData[1]),
                            Convert.ToDouble(lineData[2]),
                            Convert.ToDouble(lineData[3])
                        );
                        shapesList.Add(insertedShape);
                    break;

                    case "cube":
                        insertedShape = new Cube(
                            Convert.ToDouble(lineData[1])
                        );
                        shapesList.Add(insertedShape);
                    break;
                    
                    case "cylinder":
                        insertedShape = new Cylinder(
                            Convert.ToDouble(lineData[1]),
                            Convert.ToDouble(lineData[2])
                        );
                        shapesList.Add(insertedShape);
                    break;

                    case "sphere":
                            insertedShape = new Sphere(
                            Convert.ToDouble(lineData[1])
                        );
                        shapesList.Add(insertedShape);
                    break;

                    case "prism":
                            insertedShape = new Prism(
                            Convert.ToDouble(lineData[1]),
                            Convert.ToInt32(lineData[2]),
                            Convert.ToDouble(lineData[3])
                        );
                        shapesList.Add(insertedShape);
                    break;

                    case "area":
                        areaMultiplier = Convert.ToDouble(lineData[1]);
                        foreach (Shape3D shape in shapesList) {
                            total += shape.GetSurfaceArea() * areaMultiplier;
                        }
                        shapesList.Clear();
                    break;

                    case "volume":
                        volumeMultiplier = Convert.ToDouble(lineData[1]);
                        foreach (Shape3D shape in shapesList) {
                            total += shape.GetVolume() * volumeMultiplier;
                        }
                        shapesList.Clear();
                    break;

                }
            }
        }
    }
}