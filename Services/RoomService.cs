using System.Collections.Generic;
using getaclub_api.Data;
using getaclub_api.Models;
using System;
namespace getaclub_api.Services
{
    public class RoomService
    {
        public List<RoomModel> all()
        {
            RoomData droom = new RoomData();
            return droom.all();
        }

        public RoomModel get(int id)
        {
            RoomData droom = new RoomData();
            return droom.get(id);
        }

        public bool insert(RoomModel room)
        {
            RoomData droom = new RoomData();
            return droom.insert(room);
        }

        public bool update(RoomModel room,int id)
        {
            RoomData droom = new RoomData();
            return droom.update(room,id);
        }
        public bool delete(int id)
        {
            RoomData droom = new RoomData();
            return droom.delete(id);
        }

    }
}