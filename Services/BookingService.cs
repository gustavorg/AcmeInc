using System.Collections.Generic;
using getaclub_api.Data;
using getaclub_api.Models;
using System;
namespace getaclub_api.Services
{
    public class BookingService
    {
        public List<BookingModel> all(BookingModel booking)
        {
            BookingData droom = new BookingData();
            return droom.all(booking);
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

        /* Catering */

        public bool cateringInsert(int idBooking,BookingCateringModel bc)
        {
            BookingData droom = new BookingData();
            return droom.cateringInsert(idBooking,bc);
        }
        public bool cateringUpdate(int id,BookingCateringModel bc)
        {
            BookingData droom = new BookingData();
            return droom.cateringUpdate(id,bc);
        }
        public bool cateringDelete(int id)
        {
            BookingData droom = new BookingData();
            return droom.cateringDelete(id);
        }

        public List<BookingCateringModel> cateringAll(int idBooking)
        {
            BookingData droom = new BookingData();
            return droom.cateringAll(idBooking);
        }

        public BookingCateringModel cateringGet(int id)
        {
            BookingData droom = new BookingData();
            return droom.cateringGet(id);
        }
        
    }
}