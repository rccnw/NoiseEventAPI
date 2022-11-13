namespace NoiseEventApi.Models.NoiseEvent
{
    public class CreateNoiseEventDto
    {
        public CreateNoiseEventDto()
        {
            Data = string.Empty;
            Type = string.Empty;
            UtcTime = string.Empty;
        }

        public string Data { get; set; }
        public string Type { get; set; }
        public string UtcTime { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
