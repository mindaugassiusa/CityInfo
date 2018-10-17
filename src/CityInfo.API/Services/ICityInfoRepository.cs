using CityInfo.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public interface ICityInfoRepository
    {
        IEnumerable<City> GetCities();
        City GetCity(int cityId, bool includePointsOfInterest);
        IEnumerable<PointOfInterest> GetPointOfInterestsForCity(int cityId);
        PointOfInterest GetPointOfInterestsForCity(int cityId, int pointOfInterestId);
        bool CityExists(int cityId);

        void AddPointOfInterestForCity(int cityId, PointOfInterest pointofInterest);
        void DeletePointOfInterest(PointOfInterest pointOfInterest);
        bool Save();

    }
}
