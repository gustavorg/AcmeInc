using System;
namespace getaclub_api.Models
{
    public class ScheduleModel
    {
        public int id { get; set; }
        public int idRoom { get; set; }
        public int day { get; set; }
        public string startHour { get; set; }
        public string endHour { get; set; }
        public DateTime createdAt { get; set; }
        public int createdBy { get; set; }
        public DateTime updatedAt { get; set; }
        public int updatedBy { get; set; }
    }
}