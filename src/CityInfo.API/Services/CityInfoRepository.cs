using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityInfo.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.API.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly CityInfoContext _context;

        public CityInfoRepository(CityInfoContext context)
        {
            _context = context;
        }

        public void AddPointOfInterestForCity(int cityId, PointOfInterest pointofInterest)
        {
            var city = GetCity(cityId, false);
            city.PointsOfInterest.Add(pointofInterest); 
        }

        public IEnumerable<City> GetCities()
        {
            return _context.Cities.OrderBy(c => c.Name).ToList();
        }

        public City GetCity(int cityId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
            {
                return _context.Cities.Include(c => c.PointsOfInterest)
                    .Where(c => c.Id == cityId).FirstOrDefault();
            }
            return _context.Cities.FirstOrDefault(c => c.Id == cityId);
        }

        public bool CityExists(int cityId)
        {
            return _context.Cities.Any(c => c.Id == cityId);
        }

        public IEnumerable<PointOfInterest> GetPointOfInterestsForCity(int cityId)
        {
            return _context.PointsOfInterest
                        .Where(p => p.CityId == cityId).ToList();
        }

        public PointOfInterest GetPointOfInterestsForCity(int cityId, int pointOfInterestId)
        {
            return _context.PointsOfInterest.FirstOrDefault(p => p.CityId == cityId && p.Id == pointOfInterestId);
        }
        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            _context.PointsOfInterest.Remove(pointOfInterest);
        }
        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
