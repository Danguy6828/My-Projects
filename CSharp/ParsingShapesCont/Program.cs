using Assignment3;

namespace Program {

    class Program {
        public static void Main(string[] args) {
            Solver.ReadFile(args);
            double total = Solver.total;
            Console.WriteLine($"Your total sum of measurements is {total:0,0.00}");

        //Console.WriteLine(Solver.shapesList);
        }
    }
}

