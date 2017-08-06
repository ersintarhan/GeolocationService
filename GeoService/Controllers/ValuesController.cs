using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GeoService.Services;
using Microsoft.AspNetCore.Mvc;

namespace GeoService.Controllers
{
    [Route("api/geoip")]
    public class GeoIpController : Controller
    {
        private ICountryQuery _country;
        public GeoIpController(ICountryQuery country)
        {
            _country = country;
        }


        [HttpGet]
        [Route("ip2iso")]
        public async Task<IActionResult> Ip2iso(string ip)
        {
            return await Task.FromResult(Ok(_country.CountryIsoByIp(ip)));
        }
        [HttpGet]
        [Route("ip2country")]
        public async Task<JsonResult> Ip2Country(string ip)
        {
            return await Task.FromResult(new JsonResult(_country.CountryQueryByIp(ip)));
        }

    }
}
