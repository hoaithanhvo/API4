using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
    {
    [Route("api/[controller]")]
    [ApiController]
    public class IOTMasterController : ControllerBase
        {
        private readonly ITiotmasterRepository _Repository;

        public IOTMasterController(ITiotmasterRepository repository)
            {
            _Repository = repository;
            }

        [HttpGet]
        public IActionResult getAll(string ModelSerial ,double? from , double?to,string sortBy,int page=1)
            {
            try
                {
                return Ok(_Repository.GetList(ModelSerial,from ,to,sortBy,page));
                }
            catch { return BadRequest(); }
            }



        [HttpGet("{id}")]
        public IActionResult getById(int id)
            {
            try
                {
                return Ok(_Repository.GetById(id));
                }
            catch { return BadRequest(); }
            }
        [HttpPost]
        public IActionResult Create(ITiotmasterView Item)
            {

            try
                {
                return Ok(_Repository.Create(Item));
                }
            catch { return BadRequest(); }
            }
        [HttpDelete]
        public IActionResult Delete(int id)
            {
            try
                {
                 _Repository.DeleteById(id);
                return Ok();
                }
            catch
                {
                return BadRequest();
                }
            }

        [HttpPut]
        public IActionResult Update(ITiotmaster Item,int id)
            {
            try
                {
                _Repository.Update(Item,id);
                return Ok();
                }
            catch
                {
                return BadRequest();
                }
            }


        }
    }
    
