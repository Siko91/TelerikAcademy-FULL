namespace JsonImports.Parsers.JsonPOCOs
{
    public class JsonCar
    {
        public JsonDealer Dealer { get; set; }

        public string ManufacturerName { get; set; }

        public string Model { get; set; }

        public double Price { get; set; }

        public int TransmissionType { get; set; }

        public int Year { get; set; }
    }
}