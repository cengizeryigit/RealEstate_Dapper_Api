﻿using Dapper;
using RealEstate_Dapper_Api.Dtos.ContactDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.ContactRepositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly Context _context;

        public ContactRepository(Context context)
        {
            _context = context;
        }
        public Task CreateContact(CreateContactDto createContactDto)
        {
            throw new NotImplementedException();
        }

        public Task DeleteContact(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<ResultContactDto>> GetAllContactAsync()
        {
            string query = "Select * From Contact";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultContactDto>(query);
                return values.ToList();
            }
        }

        public Task<GetByIDContactDto> GetContact(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Last4ContactResultDto>> GetLast4ContactAsync()
        {
            string query = "Select Top(4) * From Contact Order By ContactID desc";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<Last4ContactResultDto>(query);
                return values.ToList();
            }
        }

    }
}
