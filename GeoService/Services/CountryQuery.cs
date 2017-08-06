using System;
using GeolocationService.Services;
using MaxMind.Db;
using MaxMind.GeoIP2;

namespace GeoService.Services
{

    public interface ICountryQuery
    {
        string CountryIsoByIp(string ip);
        Ip2CountryResult CountryQueryByIp(string ipAddress);

    }
    public class CountryQuery : ICountryQuery
    {
        private readonly DatabaseReader reader;

        public CountryQuery()
        {
            reader = new DatabaseReader("Ip2Country.mmdb", FileAccessMode.Memory);
        }

        public string CountryIsoByIp(string ip)
        {
            try
            {
                var response = reader.Country(ip);
                if (response != null)
                {
                    return response.Country.IsoCode.ToLowerInvariant();

                }
                else
                {
                    return "NA";
                }
            }
            catch (Exception e)
            {
                return "NA";
            }
        }
        public Ip2CountryResult CountryQueryByIp(string ipAddress)
        {
            try
            {
                var response = reader.Country(ipAddress);
                if (response != null)
                {
                    return new Ip2CountryResult(response.Country.IsoCode.ToLowerInvariant(), response.Continent.Name, response.Country.Name);

                }
                else
                {
                    return new Ip2CountryResult(null, null, null);
                }
            }
            catch (Exception e)
            {
                return new Ip2CountryResult("NA", null, null);
            }

        }
    }
}
