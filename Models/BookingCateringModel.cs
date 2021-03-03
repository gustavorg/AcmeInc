using System;
namespace getaclub_api.Models
{
    public class BookingCateringModel
    {
        public int id { get; set; }
        public int idBooking { get; set; }  
        public int idCatering { get; set; } 
        public int quantity { get; set; }
        public decimal unitPrice { get; set; }
        public decimal amount { get; set; }
        public DateTime createdAt { get; set; }
        public int createdBy { get; set; }
        public DateTime updatedAt { get; set; }
        public int updatedBy { get; set; }
    }
}