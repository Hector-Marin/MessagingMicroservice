using MediatR;
using Messaging.API.Commands;
using Messaging.Domain.AggregatesModel.MessageAggregate;
using Messaging.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Messaging.API.Commands.CreateMessageCommand;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Messaging.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageRepository _repository;
        private readonly IMongoContext _unitOfWork;
        private readonly IMediator _mediator;

        public MessageController(IMessageRepository repository, IMongoContext unitOfWork, IMediator mediator)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mediator = mediator;
        }

       

        // GET: api/<MessageController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var message = new Message(new Content("text"), new User(1));
            var response = await _repository.GetAllAsync(1);
            //var response = await _repository.GetAllAsync(1);
            return StatusCode(200, response);
        }


        // GET api/<MessageController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(string id)
        {
            var response = await _repository.GetAsync(id);
            //var response = await _repository.GetAllAsync(1);
            return StatusCode(200, response);
        }

        // POST api/<MessageController>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateMessageCommand command)
        {
            //var message = new Message(new Content("text"), new User(1));
            //var response = _repository.Add(message);
            //var unit = await _unitOfWork.SaveChangesAsync();
            //var response = await _repository.GetAllAsync(1);
            
            var commandResult = await _mediator.Send(command);
            return StatusCode(200, commandResult);
        }

        // PUT api/<MessageController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] object value)
        {
            var message = new Message(new Content("text"), new User(1));
            var response = _repository.Add(message);
            var unit = await _unitOfWork.SaveChangesAsync();
            //var response = await _repository.GetAllAsync(1);
            return StatusCode(200, new { response, unit });
        }

        // DELETE api/<MessageController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var message = new Message(new Content("text"), new User(1));
            var response = await _repository.GetAllAsync(1);
            //var response = await _repository.GetAllAsync(1);
            return StatusCode(200, response);
        }
    }
}
