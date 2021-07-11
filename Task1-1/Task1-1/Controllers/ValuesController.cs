using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1_1.Controllers
{
    [Route("api/Values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly Temp _temp;
        private readonly InputData _inputdata;
        public ValuesController(Temp temp,InputData inputData)
        {
            _temp = temp;
            _inputdata = inputData;
        }
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_temp.tmp);
        }
        [HttpPost]
        public IActionResult Create([FromQuery] int input, [FromQuery] int year, [FromQuery] int month, [FromQuery] int day)
        {
            DateTime date = new DateTime(year, month, day);
            var item = new InputData() { TemperatureC = input, Date = date };
            _temp.tmp.Add(item);

            return Ok();
        }
        [HttpPut]
        public IActionResult Update([FromQuery] int year, [FromQuery] int month, [FromQuery] int day, [FromQuery] int input)
        {
            DateTime date = new DateTime(year, month, day);
            foreach (InputData a in _temp.tmp)
            {
                if (date == a.Date)
                {
                    a.TemperatureC = input;
                }
            }
            return Ok();
        }
        [HttpDelete]
        public IActionResult Delete([FromQuery] int year, [FromQuery] int month, [FromQuery] int day)
        {
            DateTime date = new DateTime(year, month, day);
            foreach (InputData a in _temp.tmp)
            {
                if (date == a.Date)
                {
                    _temp.tmp.Remove(a);
                    return Ok();
                }
            }
            return Ok();
        }
    }
}
