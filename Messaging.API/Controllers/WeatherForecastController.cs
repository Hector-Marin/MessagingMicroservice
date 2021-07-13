using Messaging.Domain.AggregatesModel.MessageAggregate;
using Messaging.Domain.SharedKernel;
using Messaging.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDDExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IMessageRepository _repository;
        private readonly IMongoContext _unitOfWork;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMessageRepository repository, IMongoContext unitOfWork)
        {
            _logger = logger;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var message = new Message(new Content("text"),new User(1));
            var response = await _repository.GetAllAsync(1);
            //var response = await _repository.GetAllAsync(1);
            return StatusCode(200, response);
        }

        [HttpGet("add")]
        public async Task<IActionResult> Add()
        {
            var message = new Message(new Content("text"), new User(1));
            var response = _repository.Add(message);
            var unit = await _unitOfWork.SaveChangesAsync();
            //var response = await _repository.GetAllAsync(1);
            return StatusCode(200, new { response , unit });
        }
    }
}
