using System.Collections.Generic;
using getaclub_api.Data;
using getaclub_api.Models;
using System;
namespace getaclub_api.Services
{
    public class ScheduleService
    {
        public List<ScheduleModel> all()
        {
            ScheduleData schedule = new ScheduleData();
            return schedule.all();
        }

        public List<ScheduleModel> roomAll(int idRoom)
        {
            ScheduleData schedule = new ScheduleData();
            return schedule.roomAll(idRoom);
        }
        
        public ScheduleModel get(int id)
        {
            ScheduleData schedule = new ScheduleData();
            return schedule.get(id);
        }

        public bool insert(ScheduleModel room)
        {
            ScheduleData schedule = new ScheduleData();
            return schedule.insert(room);
        }

        public bool update(ScheduleModel room,int id)
        {
            ScheduleData schedule = new ScheduleData();
            return schedule.update(room,id);
        }
        public bool delete(int id)
        {
            ScheduleData schedule = new ScheduleData();
            return schedule.delete(id);
        }

    }
}