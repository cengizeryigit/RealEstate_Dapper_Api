using Dapper;
using RealEstate_Dapper_Api.Dtos.MessageDtos;
using RealEstate_Dapper_Api.Models.DapperContext;

namespace RealEstate_Dapper_Api.Repositories.MessageRepositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly Context _context;

        public MessageRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<ResultInboxMessageDto>> GetInBoxLast3MessageListByReceiver(int id)
        {
            string query = "select top(3) MessageId,UserName as 'Name' ,UserImageUrl,Subject,Detail,SendDate, IsRead from Message inner join AppUser On Message.Sender=AppUser.UserID Where Receiver = 2 order by MessageId desc ";
            var parameters = new DynamicParameters();
            parameters.Add("receiverid", id);
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultInboxMessageDto>(query, parameters);
                return values.ToList();
            }
        }
    }
}
