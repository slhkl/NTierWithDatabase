using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Data.Dtos;
using Business;

namespace NTierWithDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        BookBusiness bookBusiness = new BookBusiness();
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(bookBusiness.GetAll());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(bookBusiness.GetById(id));
        }
        [HttpPost]
        public IActionResult Add(BookForAddDto book)
        {
            
            return Ok(bookBusiness.Add(new Book { BookName= book.BookName, BookShelf= book.BookShelf, WriterId=book.WriterId}));
        }
        [HttpPut]
        public IActionResult Update(Book book)
        {
            return Ok(bookBusiness.Update(book));
        }
        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            return Ok(bookBusiness.Remove(id));
        }
    }
}
