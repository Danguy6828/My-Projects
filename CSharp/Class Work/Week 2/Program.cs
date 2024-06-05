namespace Program {
    static class Program {
        public static void Main(string[] args) {
            Console.WriteLine("Hello, World!");

            string filepath = args[0];

            int total = 0;

            foreach (string line in System.IO.File.ReadLines(filepath)) {
                //Split on instance of bee, array length will be one more than instances of bee
                string[] beeSplit = line.ToLower().Split(" bee");
                total += beeSplit.Length - 1;
            }
            Console.WriteLine($"The number of bees in Bee Movie is {total}.");
        }
    }
}