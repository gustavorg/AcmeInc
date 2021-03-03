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
        public IActionResult  all(BookingModel booking)
        {
            BookingService service = new BookingService();
            var status = true; List<BookingModel>  result = null;
            try{
                result = service.all(booking);
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


        /* Caterings */

        [HttpPost]
        [Route("catering/{idBooking}")]
        public IActionResult  cateringInsert(int idBooking,BookingCateringModel bc)
        {
            BookingService service = new BookingService();
            var status = true; bool result = false;
            
                try{
                    result = service.cateringInsert(idBooking,bc);
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

        [HttpPut]
        [Route("catering/{id}")]
        public IActionResult  cateringUpdate(int id,BookingCateringModel bc)
        {
            BookingService service = new BookingService();
            var status = true; bool result = false;
            
                try{
                    result = service.cateringUpdate(id,bc);
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
        [Route("catering/{id}")]
        public IActionResult  cateringDelete(int id)
        {
            BookingService service = new BookingService();
            var status = true; bool result = false;
            try{
                result = service.cateringDelete(id);
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
        [Route("catering/all/{idBooking}")]
        public IActionResult  cateringAll(int idBooking)
        {
            BookingService service = new BookingService();
            var status = true; List<BookingCateringModel>  result = null;
            try{
                result = service.cateringAll(idBooking);
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
        [Route("catering/get/{id}")]
        public IActionResult  cateringGet(int id)
        {
            BookingService service = new BookingService();
            var status = true; BookingCateringModel result = null;
            try{
                result = service.cateringGet(id);
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