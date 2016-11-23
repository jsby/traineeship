
namespace TestCars.TestCars.Models
{
    class Car
    {
        private string make;
        private string model;
        private string year;
        private string engine;
        private string transmission;

        public Car(string make, string model, string year)
        {
            this.make = make;
            this.model = model;
            this.year = year;
        }

        public string GetMake()
        {
            return make;
        }

        public string GetModel()
        {
            return model;
        }

        public string GetYear()
        {
            return year;
        }

        public string GetEngine()
        {
            return engine;
        }

        public void SetEngine(string engine)
        {
            this.engine = engine;
        }

        public string GetTransmission()
        {
            return transmission;
        }

        public void SetTransmission(string transmission)
        {
            this.transmission = transmission;
        }
    }
}
