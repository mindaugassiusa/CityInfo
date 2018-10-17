using AutoMapper;
using CityInfo.API.Models;
using CityInfo.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Controllers
{
    [Route("api/cities")]
    public class CitiesController : Controller
    {
        private readonly ICityInfoRepository _cityInfoRepository;

        public CitiesController(ICityInfoRepository cityInfoRepository)
        {
            _cityInfoRepository = cityInfoRepository;
        }
        [HttpGet()]
        public IActionResult GetCities()
        {
            // return Ok(CitiesDataStore.Current.Cities);
            var cityEntities = _cityInfoRepository.GetCities();
            var results = Mapper.Map<IEnumerable<CityWithoutPointsOfInterestDto>>(cityEntities);

            return Ok(results);
        }

        [HttpGet("{id}")]
        public IActionResult GetCity(int id, bool includePointsOfInterest = false)
        {
            var city = _cityInfoRepository.GetCity(id, includePointsOfInterest);
            if (city == null)
            {
                return NotFound();
            }
            if (includePointsOfInterest)
            {
                var cityResult = Mapper.Map<CityDto>(city);

                return Ok(cityResult);
            }

            var cityWithoutPointsOfInterestResult = Mapper.Map<CityDto>(city);
            return Ok(cityWithoutPointsOfInterestResult);
            // find city
            //var cityToReturn = CitiesDataStore.Current.Cities.FirstOrDefault(c => c.Id == id);
            //if (cityToReturn == null)
            //{
            //    return NotFound();
            //}

            //return Ok(cityToReturn);
        }

    }
}
