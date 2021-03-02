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
    public class ScheduleController:ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult  all()
        {
            ScheduleService service = new ScheduleService();
            var status = true; List<ScheduleModel>  result = null;
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
        [Route("room/{idRoom}")]
        public IActionResult  roomAll(int idRoom)
        {
            ScheduleService service = new ScheduleService();
            var status = true; List<ScheduleModel>  result = null;
            try{
                result = service.roomAll(idRoom);
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
            ScheduleService service = new ScheduleService();
            var status = true; ScheduleModel result = null;
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
        public IActionResult  insert(ScheduleModel schedule)
        {
            ScheduleService service = new ScheduleService();
            var status = true; bool result = false;
            try{
                result = service.insert(schedule);
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
        public IActionResult  update(int id,ScheduleModel schedule)
        {
            ScheduleService service = new ScheduleService();
            var status = true; bool result = false;
            try{
                result = service.update(schedule,id);
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
            ScheduleService service = new ScheduleService();
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