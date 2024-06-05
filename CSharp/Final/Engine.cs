using FinalAssignment;

namespace Engine {

    class EngineData {
        //Need avg mpg(from static), torque(from static), fwd t/f, weight

        public int cityMPG;

        public int highwayMPG;
        
        public int horsepower;

        public int horsepowerRPM;

        public int weight;

        public bool fwd;

        public double avgMPG;

        public double torque;

        public EngineData(Dictionary<string,string> info) {
            this.cityMPG = Convert.ToInt32(info["City MPG"]);
            this.highwayMPG = Convert.ToInt32(info["Highway MPG"]);
            this.horsepower = Convert.ToInt32(info["Horsepower (HP)"]);
            this.horsepowerRPM = Convert.ToInt32(info["Horsepower (rpm)"]);
            this.weight = Convert.ToInt32(info["Weight (lbs)"]);
            
            if (Convert.ToString(info["Drive type"]) is "four wheel drive") {
                this.fwd = true;
            } else {
                this.fwd = false;
            }

            this.avgMPG = StaticMethods.CalculateAverageMPG(this.cityMPG, this.highwayMPG);

            this.torque = StaticMethods.CalculateTorque(this.horsepower, this.horsepowerRPM);
        }

        public bool FWD() {
            return this.fwd;
        }
    }
}