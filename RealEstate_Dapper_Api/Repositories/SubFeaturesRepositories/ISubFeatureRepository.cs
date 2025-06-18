﻿using RealEstate_Dapper_Api.Dtos.SubFeatureDtos;

namespace RealEstate_Dapper_Api.Repositories.SubFeaturesRepositories
{
    public interface ISubFeatureRepository
    {
        Task<List<ResultSubFeatureDtos>> GetAllSubFeatureAsync();
    }
}
