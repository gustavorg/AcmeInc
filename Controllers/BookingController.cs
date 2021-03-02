using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using getaclub_api.Models;
using getaclub_api.Services;
using System;

namespace getaclub_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingController:ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult  all()
        {
            BookingService service = new BookingService();
            var status = true; List<BookingModel>  result = null;
            try{
                result = service.all();
            }catch (System.Exception)
            {
                status = false;
            }

            var rtn = new {
                status = status,
                result = result
            };

            return Ok(rtn);
        }
        
        [HttpGet]
        [Route("{id}")]
        public IActionResult  get(int id)
        {
            BookingService service = new BookingService();
            var status = true; BookingModel result = null;
            try{
                result = service.get(id);
            }catch (System.Exception)
            {
                status = false;
            }

            var rtn = new {
                status = status,
                result = result
            };

            return Ok(rtn);
        }

        [HttpPost]
        [Route("")]
        public IActionResult  insert(BookingModel room)
        {
            BookingService service = new BookingService();
            ClientService sclient = new ClientService();
            var status = true; bool result = false;
            
            if(sclient.exist(room.idClient)){
                try{
                    result = service.insert(room);
                }catch (System.Exception)
                {
                    status = false;
                }
            }

            var rtn = new {
                status = status,
                result = result
            };

            return Ok(rtn);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult  update(int id,BookingModel room)
        {
            BookingService service = new BookingService();
            var status = true; bool result = false;
            try{
                result = service.update(room,id);
            }catch (System.Exception)
            {
                status = false;
            }

            var rtn = new {
                status = status,
                result = result
            };

            return Ok(rtn);
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult  delete(int id)
        {
            BookingService service = new BookingService();
            var status = true; bool result = false;
            try{
                result = service.delete(id);
            }catch (System.Exception)
            {
                status = false;
            }

            var rtn = new {
                status = status,
                result = result
            };

            return Ok(rtn);
        }
    }

}