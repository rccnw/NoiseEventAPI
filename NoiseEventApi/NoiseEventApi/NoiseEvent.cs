namespace NoiseEventApi
{
    public class NoiseEvent
    {
        public NoiseEvent()
        {
            Data = string.Empty;
            Type = string.Empty;
            UtcTime = string.Empty;
        }

        public int Id { get; set; }
        public string Data { get; set; }
        public string Type { get; set; }
        //
        //public Point Location { get; set; }
        public string UtcTime { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }

        //  public GeoLocation GeoLocation { get; set; }


        // var seattle = new Point(-122.333056, 47.609722) { SRID = 4326 };
        // new Location(20.7557, -155.9880);
    }
}
