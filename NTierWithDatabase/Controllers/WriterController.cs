using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business;
using Data.Models;
using Data.Dtos;


namespace NTierWithDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WriterController : ControllerBase
    {
        WriterBusiness writerBusiness = new WriterBusiness();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(writerBusiness.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(writerBusiness.GetById(id));
        }
        [HttpPost]
        public IActionResult Add(WriterForAddDto writer)
        {
            return Ok(writerBusiness.Add(new Writer { WriterName=writer.WriterName}));
        }
        [HttpPut]
        public IActionResult Update(Writer writer)
        {
            return Ok(writerBusiness.Update(writer));
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            return Ok(writerBusiness.Remove(id));
        }
    }
}
