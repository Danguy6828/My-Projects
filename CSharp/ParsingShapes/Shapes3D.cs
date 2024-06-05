namespace David.Shapes3D {

    public abstract class Shape3D {
        public abstract double GetSurfaceArea();
        public abstract double GetVolume();
    }

    class Cuboid : Shape3D {
        public double width;
        public double height;
        public double depth;

        public Cuboid(double width, double height, double depth) {
            this.width = width;
            this.height = height;
            this.depth = depth;
        }
        override public double GetSurfaceArea() {
            return 2 * (this.width * this.height + this.height * this.depth + this.width * this.depth);
        }
        override public double GetVolume() {
            return this.width * this.height * this.depth;
        }
    }

    class Cube : Cuboid {
        public Cube(double length) : base(length, length, length) {}
    }

    class Cylinder : Shape3D {
        public double radius;
        public double height;

        public Cylinder(double radius, double height) {
            this.radius = radius;
            this.height = height;
        }
        override public double GetSurfaceArea() {
            return (2 *  Math.PI * this.radius * this.height) + (2 * Math.PI * Math.Pow(this.radius, 2));
        }
        override public double GetVolume() {
            return Math.PI * Math.Pow(this.radius, 2) * this.height;
        }
    }

    class Sphere : Shape3D {
        public double radius;

        public Sphere(double radius) {
            this.radius = radius;
        }
        public override double GetSurfaceArea() {
            return 4 * Math.PI * Math.Pow(this.radius, 2);
        }
        public override double GetVolume() {
            return (4d / 3d) * Math.PI * Math.Pow(this.radius, 3);
        }
    }
}