import math
from Shapes import Polygon

class Shape:
    def __init__(self):
        raise NotImplementedError()
    
    def getSurfaceArea(self):
        pass

    def getVolume(self):
        pass

class Cuboid(Shape):
    def __init__(self, width, height, depth):
        self._width = width
        self._height = height
        self._depth = depth
    
    def getSurfaceArea(self):
        return 2 * (self._height * self._width + self._depth * self._height + self._width * self._depth)
    
    def getVolume(self):
        return self._height * self._width * self._depth
    
class Cube(Cuboid):
    def __init__(self, sidelength):
        super().__init__(sidelength, sidelength, sidelength)

class Cylinder(Shape):
    def __init__(self, radius, height):
        self._radius = radius
        self._height = height

    def getSurfaceArea(self):
        return (2 * math.pi * self._radius * self._height) + (2 * math.pi * (self._radius**2))
    
    def getVolume(self):
        return math.pi * (self._radius ** 2) * self._height

class Sphere(Shape):
    def __init__(self, radius):
        self._radius = radius

    def getSurfaceArea(self):
        return 4 * math.pi * (self._radius ** 2)
    
    def getVolume(self):
        return (4/3) * math.pi * (self._radius ** 3)

class Prism(Shape):
    def __init__(self, sidelength, faces, height):
        self._sidelength = sidelength
        self._faces = faces
        self._height = height
        self._base = Polygon(sideLength = sidelength,sides = faces)
        self._area = (2 * self._base.GetArea()) + (self._base.GetPerimeter() * self._height)
        self._volume = self._base.GetArea() * self._height

    def getSurfaceArea(self):
        return self._area
    
    def getVolume(self):
        return self._volume