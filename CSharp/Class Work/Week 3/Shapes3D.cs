using Shapes3D;

namespace Shapes3D {

    public abstract class Shape3D {

        public abstract double GetSurfaceArea();

        public abstract double GetVolume();
    }
    class Cylinder : Shape3D {
        public Shapes.Circle mybase;
        public double height;

        public double surfaceArea;
        public double volume;

        public Cylinder(double radius, double height) {
            this.mybase = new Circle(radius);
            this.height = height;

            this.surfaceArea = this._GetSurfaceArea();
            this.volume - this._GetVolume();
        }
        private override double _GetSurfaceArea() {
            double baseArea = this.mybase.GetArea();

            double baseArea = this.mybase.GetPerimeter() * this.height;

            return (baseArea * 2) + sideArea;
        }

        private override double _GetVolume() {
            return this.mybase.GetSurfaceArea() * this.height;
        }

        public override double GetSurfaceArea() {
            return this.surfaceArea;
        }
        
        public override double GetVolume() {
            return this.volume;
        }
    }
}