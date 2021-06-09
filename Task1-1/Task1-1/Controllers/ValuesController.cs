using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1_1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly Temp _temp;
        public ValuesController(Temp temp)
        {

            _temp = temp;
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
            var item = new Temp() { TemperatureC = input, Date = date };
            _temp.tmp.Add(item);

            return Ok();
        }
        [HttpPut]
        public IActionResult Update([FromQuery] int year, [FromQuery] int month, [FromQuery] int day, [FromQuery] int input)
        {
            DateTime date = new DateTime(year, month, day);
            foreach (Temp a in _temp.tmp)
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
            foreach (Temp a in _temp.tmp)
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
