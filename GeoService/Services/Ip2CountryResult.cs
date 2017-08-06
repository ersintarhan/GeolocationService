namespace GeolocationService.Services
{
    public class Ip2CountryResult
    {
        public Ip2CountryResult()
        {

        }

        /// <inheritdoc />
        public Ip2CountryResult(string iso, string continent, string country)
        {
            Iso = iso;
            Continent = continent;
            Country = country;
        }

        public string Iso { get; set; }
        public string Continent { get; set; }
        public string Country { get; set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return $"{nameof(Iso)}: {Iso}, {nameof(Continent)}: {Continent}, {nameof(Country)}: {Country}";
        }
    }
}