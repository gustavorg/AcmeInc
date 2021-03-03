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
    public class CateringController:ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult  all()
        {
            CateringService service = new CateringService();
            var status = true; List<CateringModel>  result = null;
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
            CateringService service = new CateringService();
            var status = true; CateringModel result = null;
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
        public IActionResult  insert(CateringModel room)
        {
            CateringService service = new CateringService();
            var status = true; bool result = false;
            try{
                result = service.insert(room);
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
        [Route("{id}")]
        public IActionResult  update(int id,CateringModel room)
        {
            CateringService service = new CateringService();
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
            CateringService service = new CateringService();
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