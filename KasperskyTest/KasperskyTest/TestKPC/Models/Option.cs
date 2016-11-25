namespace KasperskyTest.TestKPC.Models
{
    public class Option
    {
        public string Devices { get; set; }

        public string Year { get; set; }

        public string Cost { get; set; }

        public Option(string devices, string year, string cost)
        {
            Devices = devices;
            Year = year;
            Cost = cost;
        }
    }
}
