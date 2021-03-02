using System;
namespace getaclub_api.Models
{
    public class ClientModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastName { get; set; }
        public string surName { get; set; }
        public string businessName { get; set; }
        public int idDocumentType { get; set; }
        public string document { get; set; }
        public string email { get; set; }
        public string phoneCode { get; set; }
        public string phone { get; set; }
        public string gender { get; set; }
        public DateTime createdAt { get; set; }
        public int createdBy { get; set; }
        public DateTime updatedAt { get; set; }
        public int updatedBy { get; set; }
    }
}