using System;
namespace getaclub_api.Models
{
    public class CateringModel
    {
        public int id { get; set; }
        public string name { get; set; }  
        public decimal price { get; set; }
        public DateTime createdAt { get; set; }
        public int createdBy { get; set; }
        public DateTime updatedAt { get; set; }
        public int updatedBy { get; set; }
    }
}