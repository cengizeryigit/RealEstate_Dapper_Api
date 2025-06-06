﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.MessageRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageRepository _messageRepository;
        public MessagesController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet("GetInBoxLast3MessageListByReceiver/{id}")]
        public async Task<IActionResult> GetInBoxLast3MessageListByReceiver(int id)
        {
            var result = await _messageRepository.GetInBoxLast3MessageListByReceiver(id);
            return Ok(result);
        }
    }
}
