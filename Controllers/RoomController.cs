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
    public class RoomController:ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult  all()
        {
            RoomService service = new RoomService();
            status = true; result = null;
            try{
                List<RoomModel> result = service.all(id);
            }catch (System.Exception)
            {
                status = false;
            }

            var rtn = new {
                status = status,
                result = arr
            };

            return Ok(rtn);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult  get(int id)
        {
            RoomService service = new RoomService();
            status = true; result = null;
            try{
                RoomModel result= service.all(id);
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