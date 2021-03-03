using System;
namespace getaclub_api.Models
{
    public class BookingModel
    {
        public int id { get; set; }
        public int idBookingStatus { get; set; }
        public int idRoom { get; set; }
        public int idClient { get; set; }
        public string date { get; set; }
        public string startHour { get; set; }
        public string endHour { get; set; }
        public ClientModel client { get; set; }
        public DateTime createdAt { get; set; }
        public int createdBy { get; set; }
        public DateTime updatedAt { get; set; }
        public int updatedBy { get; set; }
        public string startDate { get; set; }
        public string endDate { get; set; }
    }
}