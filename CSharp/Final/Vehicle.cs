using Engine;

namespace Vehicle {

    class VehicleData {
        //Need Max cost, min seats, range(avgmpg * fuel capacity) power(torque/grossWeight)
        public int vehicleID;

        public int cost;

        public int seats;

        public double fuelCapacity;

        public int weight;

        public EngineData engine;

        public double range;

        public double power;

        public bool fwd;

        public VehicleData(Dictionary<string, string> info, EngineData engineFocus) {
            this.vehicleID = Convert.ToInt32(info["Vehicle ID"]);
            this.cost = Convert.ToInt32(info["MSRP"]);
            this.seats = Convert.ToInt32(info["Seats"]);
            this.fuelCapacity = Convert.ToDouble(info["Fuel tank capacity (gal)"]);
            this.weight = Convert.ToInt32(info["Weight (lbs)"]);
            this.engine = engineFocus;
            this.range = Range();
            this.power = Power();
            this.fwd = engine.fwd;

        }

        public double GrossWeight() {
            return this.weight + this.engine.weight;
        }

        public double Range() {
            return this.engine.avgMPG * this.fuelCapacity;
        }

        public double Power() {
            return this.engine.torque / this.GrossWeight();
        }
        public bool Fwd() {
            return this.engine.FWD();
        }

        public int Cost() {
            return this.cost;
        }

        public int Seats() {
            return this.seats;
        }

        public int ID() {
            return this.vehicleID;
        }
    }
}