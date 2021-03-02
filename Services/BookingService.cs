using System.Collections.Generic;
using getaclub_api.Data;
using getaclub_api.Models;
using System;
namespace getaclub_api.Services
{
    public class BookingService
    {
        public List<BookingModel> all()
        {
            BookingData droom = new BookingData();
            return droom.all();
        }

        public BookingModel get(int id)
        {
            BookingData droom = new BookingData();
            return droom.get(id);
        }

        public bool insert(BookingModel room)
        {
            BookingData droom = new BookingData();
            return droom.insert(room);
        }

        public bool update(BookingModel room,int id)
        {
            BookingData droom = new BookingData();
            return droom.update(room,id);
        }
        public bool delete(int id)
        {
            BookingData droom = new BookingData();
            return droom.delete(id);
        }

    }
}