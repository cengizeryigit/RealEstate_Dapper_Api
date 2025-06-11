using Dapper;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Dtos.ProductDetailDtos;
using RealEstate_Dapper_Api.Dtos.ProductDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ProductRepository
{
    public class ProductRepository : IProductRepository
    {
        private readonly Context _context;

        public ProductRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateProduct(CreateProductDto createProductDto)
        {
            string query = " insert into Product (Title, Price,City, District,CoverImage, Type,Address, DealOfTheDay,AdvertisementDate,Description,ProductStatus,ProductCategory,EmployeeID) values (@Title, @Price,@City, @District,@CoverImage, @Type,@Address, @DealOfTheDay,@AdvertisementDate,@Description,@ProductStatus,@ProductCategory,@EmployeeID)";

            var parameters = new DynamicParameters();
            parameters.Add("Title", createProductDto.Title);
            parameters.Add("Price", createProductDto.Price);
            parameters.Add("City", createProductDto.City);
            parameters.Add("District", createProductDto.District);
            parameters.Add("CoverImage", createProductDto.CoverImage);
            parameters.Add("Type", createProductDto.Type);
            parameters.Add("Address", createProductDto.Address);
            parameters.Add("DealOfTheDay", createProductDto.DealOfTheDay);
            parameters.Add("AdvertisementDate", createProductDto.AdvertisementDate);
            parameters.Add("ProductStatus", createProductDto.ProductStatus);
            parameters.Add("ProductCategory", createProductDto.ProductCategory);
            parameters.Add("EmployeeID", createProductDto.EmployeeID);
            parameters.Add("Description", createProductDto.Description);
            
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "Select * From Product";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "Select ProductId,Title,Price,City,District,CategoryName,CoverImage,Type,Address, DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultLast5ProductWithCategoryDto>> GetLast5ProductAsync()
        {
            string query = "SELECT TOP (5) ProductID, Title, Price, City, District, ProductCategory, CategoryName, AdvertisementDate FROM Product INNER JOIN Category ON Product.ProductCategory = Category.CategoryID WHERE Type = 'Kiralık' ORDER BY ProductID DESC";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultLast5ProductWithCategoryDto>(query);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByFalse(int id)
        {
            string query = @"SELECT ProductID, Title, Price, City,DealOfTheDay, District, ProductCategory, CategoryName,
                 AdvertisementDate 
                 FROM Product 
                 INNER JOIN Category ON Product.ProductCategory = Category.CategoryID 
                 WHERE EmployeeID = @employeeId  and ProductStatus=0
                 ORDER BY ProductID DESC";

            var parameters = new DynamicParameters();
            parameters.Add("employeeId", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<List<ResultProductAdvertListWithCategoryByEmployeeDto>> GetProductAdvertListByEmployeeAsyncByTrue(int id)
        {
            string query = @"SELECT ProductID, Title, Price, City,DealOfTheDay, District, ProductCategory, CategoryName,
                 AdvertisementDate 
                 FROM Product 
                 INNER JOIN Category ON Product.ProductCategory = Category.CategoryID 
                 WHERE EmployeeID = @employeeId  and ProductStatus=1
                 ORDER BY ProductID DESC";

            var parameters = new DynamicParameters();
            parameters.Add("employeeId", id);

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultProductAdvertListWithCategoryByEmployeeDto>(query, parameters);
                return values.ToList();
            }
        }

        public async Task<GetProductByProductIdDto> GetProductByProductId(int id)
        {
            string query = "Select ProductId,Title,Price,City,District,CategoryName,CoverImage,Type,Address, DealOfTheDay From Product inner join Category on Product.ProductCategory=Category.CategoryID where  ProductId = @productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductByProductIdDto>(query, parameters);
                return values.FirstOrDefault();
            }

            
        }

        public async Task<GetProductDetailByIdDto> GetProductDetailByProductId(int id)
        {
            string query = "Select * from ProductDetails where ProductId = @productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<GetProductDetailByIdDto>(query, parameters);
                return values.FirstOrDefault();
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToFalse(int id)
        {
            string query = "Update Product Set DealOfTheDay=0 Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task ProductDealOfTheDayStatusChangeToTrue(int id)
        {
            string query= "Update Product Set DealOfTheDay=1 Where ProductID=@productID";
            var parameters = new DynamicParameters();
            parameters.Add("@productID", id);
            using (var connection = _context.CreateConnection())
            {
               await connection.ExecuteAsync(query, parameters);
            }
        }
    }

}
