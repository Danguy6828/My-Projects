import Shapes3D, sys

class Solver:
    shapesList = []
    total = 0
    with open(sys.argv[1]) as readFile:
        for line in readFile.readlines():
            lineData = line.split(',')   
            
            if lineData[0] == "cuboid":
                insertedShape = Shapes3D.Cuboid(
                    width = float(lineData[1]),
                    height = float(lineData[2]),
                    depth = float(lineData[3])
                )
                shapesList.append(insertedShape)

            elif lineData[0] == "cube":
                insertedShape = Shapes3D.Cube(
                    sidelength = float(lineData[1])
                )
                shapesList.append(insertedShape)

            elif lineData[0] == "cylinder":
                insertedShape = Shapes3D.Cylinder(
                    radius = float(lineData[1]),
                    height = float(lineData[2])
                )
                shapesList.append(insertedShape)

            elif lineData[0] == "sphere":
                insertedShape = Shapes3D.Sphere(
                    radius = float(lineData[1])
                )
                shapesList.append(insertedShape)

            elif lineData[0] == "prism":
                insertedShape = Shapes3D.Prism(
                    sidelength = float(lineData[1]),
                    faces = float(lineData[2]),
                    height = float(lineData[3])
                )
                shapesList.append(insertedShape)

            elif lineData[0] == "area":
                multiplier = float(lineData[1])
                for shape in shapesList:
                    total += shape.getSurfaceArea() * multiplier
                shapesList.clear()

            elif lineData[0] == "volume":
                multiplier = float(lineData[1])
                for shape in shapesList:
                    total += shape.getVolume() * multiplier
                shapesList.clear()

result = Solver()
print(result.total)