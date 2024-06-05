using Engine;
using Vehicle;
using ConsoleExtension;

namespace Final {
    public class Finder {

        List<VehicleData> vehicleList;

        public Finder() {
            this.vehicleList = CarDatabase();
        }

        static List<VehicleData> CarDatabase() {
            Dictionary<string, EngineData> engineList = new Dictionary<string, EngineData>();

            string[] engineAttributes = new string[0];
            bool engineAttributesSet = false;
            foreach (string line in System.IO.File.ReadLines("engine_data.csv")) {
                if(!engineAttributesSet) {
                    engineAttributes = line.Split(",");
                    engineAttributesSet = true;

                } else {
                    string[] engineValues = line.Split(",");
                    Dictionary<string, string> engineData = new Dictionary<string, string>();
                    for (int i = 0; i < engineAttributes.Length; i += 1) {
                        engineData.Add(engineAttributes[i], engineValues[i]);
                    }
                    EngineData myEngine = new EngineData(engineData);
                    engineList.Add(engineValues[0],myEngine);
                }
            }

            List<VehicleData> vehicleList = new List<VehicleData>();
            string[] vehicleAtts = new string[0];
            bool vehicleAttsSet = false;
            foreach (string line in System.IO.File.ReadLines("vehicle_data.csv")) {
                if(!vehicleAttsSet) {
                  vehicleAtts = line.Split(",");
                  vehicleAttsSet = true;

                } else {
                  string[] vehicleValues = line.Split(",");
                  Dictionary<string, string> vehicleData = new Dictionary<string, string>();
                
                for (int i = 0; i < vehicleAtts.Length; i += 1) {
                    vehicleData.Add(vehicleAtts[i], vehicleValues[i]);
                }

                string engineID = vehicleData["Engine ID"];
                VehicleData myVehicle = new VehicleData(vehicleData, engineList[engineID]);
                vehicleList.Add(myVehicle);
                }
            } 
            return vehicleList;
        } 

    public string GetVehicleList(int cost=0, bool useCost=false, int seats=0, bool useSeats=false, double range=0, bool useRange=false, double power=0, bool usePower=false, bool FWD=false, bool useFwd=false) {

      string matchingIds = "";
      foreach (VehicleData vehicle in this.vehicleList) {
        if (useCost) {
          if (vehicle.Cost() > cost) {
            continue;
          }
        } 
        
        if (useSeats) {
          if (vehicle.Seats() < seats) {
            continue;
          }
        } 
        
        if (useRange) {
          if (vehicle.Range() < range) {
            continue;
          }
        }

        if (usePower) {
          if (vehicle.Power() < power) {
            continue;
          }
        }

        if (useFwd) {
          if (vehicle.Fwd() != FWD) {
            continue;
          }
        }
        matchingIds += vehicle.ID() + ", ";

      }
      return $"{matchingIds}";

    } 
  }
    
    public class UserInterface {

        public int maxCost;

        public int minSeats;

        public double minRange;

        public double minPower;

        public bool fwd;

        static void Main(string[] args) {

            List<string> menu = new List<string>() {
                " ",
                "This is a tool to look up specific vehicle and engine information." ,
                "Please make a selection." ,
                "(1) Add filter for Maximum cost" ,
                "(2) Add filter for Minimum seats" ,
                "(3) Add filter for Minimum range" ,
                "(4) Add filter for Minimum power" ,
                "(5) Add filter for Four Wheel Drive", 
                "(6) Find vehicles with given filters"
            };
            int maxCost = 0;
            bool costCheck = false;
            int minSeats = 0;
            bool seatCheck = false;
            double minRange = 0;
            bool rangeCheck = false;
            double minPower = 0;
            bool powerCheck = false;
            bool fwd = false;
            bool fwdCheck = false;
            menu.ForEach(Console.WriteLine);
            
            while(true) {

                string selection = Console.ReadLine()!;

                if (selection is "1") {
                    maxCost = STDIn.promptInt("Please enter your maximum cost.");
                    costCheck = true;
                    menu.ForEach(Console.WriteLine);

                } else if (selection is "2") {
                    minSeats = STDIn.promptInt("Please enter the minimum amount of seats wanted.");
                    seatCheck = true;
                    menu.ForEach(Console.WriteLine);

                } else if (selection is "3") {
                    minRange = STDIn.promptDouble("Please enter the minium desired range.");
                    rangeCheck = true;
                    menu.ForEach(Console.WriteLine);

                } else if (selection is "4") {
                    minPower = STDIn.promptDouble("Please enter the minimum desired power.");
                    powerCheck = true;
                    menu.ForEach(Console.WriteLine);

                } else if (selection is "5") {
                    Console.WriteLine("Do you want four wheel drive? Please enter (Yes/No)");
                    string response = Console.ReadLine()!;
                    if (response == "Yes") {
                        fwdCheck = true;
                        fwd = true;
                        menu.ForEach(Console.WriteLine);

                    } else if (response == "No") {
                        menu.ForEach(Console.WriteLine);

                    } else {
                        Console.WriteLine(" ");
                        Console.WriteLine("Please enter a valid response.");
                        Console.WriteLine(" ");
                        menu.ForEach(Console.WriteLine);
                    }

                } else if (selection is "6") {
                    Console.WriteLine("Please confirm your entered data.");
                    if (costCheck == true) {
                      Console.WriteLine($"Maximum cost is ${maxCost}.");
                    }
                    if (seatCheck == true) {
                      Console.WriteLine($"Minimum seats is {minSeats}.");
                    }
                    if (rangeCheck == true) {
                      Console.WriteLine($"Minimum range is {minRange}.");
                    }
                    if (powerCheck == true) {
                      Console.WriteLine($"Minimum power is {minPower}.");
                    }
                    if (fwdCheck == true) {
                      Console.WriteLine($"Four wheel drive is desired: {fwd}");
                    }
                    Console.WriteLine("Is this all correct? Type 'Yes' to continue or 'No' to return to data entry.");
                    
                    string response = Console.ReadLine()!;
                    string lowerResponse = response.ToLower();
                    if (lowerResponse == "yes") {
                      Console.WriteLine("We will begin searching for matching vehicles.");
                      Finder resultsFinder = new Finder();
                      Console.WriteLine("Here are the IDs that fit your desired parameters:");
                      string found = resultsFinder.GetVehicleList(maxCost, costCheck, minSeats, seatCheck, minRange, rangeCheck, minPower, powerCheck, fwd, fwdCheck);
                      Console.WriteLine(found);
                      if (found == "") {
                        Console.WriteLine("No vehicles match your desired parameters, please try again.");
                        Console.WriteLine("");
                      }
                      Environment.Exit(0);
                    } else if (lowerResponse == "no") {
                      menu.ForEach(Console.WriteLine);

                } else {
                    Console.WriteLine(" ");
                    Console.WriteLine("Please enter a valid response.");
                    Console.WriteLine(" ");
                    menu.ForEach(Console.WriteLine);

                }

                } else {
                    Console.WriteLine(" ");
                    Console.WriteLine("Please enter a valid number.");
                    menu.ForEach(Console.WriteLine);

                }
            }
        }
    }
}