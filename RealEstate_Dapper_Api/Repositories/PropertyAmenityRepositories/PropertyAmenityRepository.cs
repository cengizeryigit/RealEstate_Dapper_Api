using Dapper;
using RealEstate_Dapper_Api.Dtos.PropertyAmenityDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.PropertyAmenityRepositories
{
    public class PropertyAmenityRepository : IPropertyAmenityRepository
    {
        private readonly Context _context;

        public PropertyAmenityRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<ResultPropertAmenityByStatusTrueDto>> GetPropertyAmenityByStatusTrue(int id)
        {
            string query = "select PropertyAmenityId,Title from PropertyAmenity inner join Amenity on PropertyAmenity.AmenityId = Amenity.AmenityId Where PropertyId = @propertyId And Status=1";
            var parameters = new DynamicParameters();
            parameters.Add("@propertyId", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultPropertAmenityByStatusTrueDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}
