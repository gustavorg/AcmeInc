using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using getaclub_api.Library;
using getaclub_api.Models;
using System;

namespace getaclub_api.Data
{
    public class RoomData : MsSqlExtensions
    { 
        public List<RoomModel> all(){
            List<RoomModel> rtn = null;
            DataTable dt = base.ExecuteDataTable("usp_rooms_s_rooms");
            if (dt!=null && dt.Rows.Count>0)
            {
                rtn = new List<RoomModel>();

                foreach(DataRow dr in dt.Rows)
                {
                    rtn.Add(new RoomModel{
                        id = Convert.ToInt16(dr["id"]),
                        name = Convert.ToString(dr["name"]),
                        hourPrice = Convert.ToDecimal(dr["hourPrice"]),
                        cleaningTime = Convert.ToString(dr["cleaningTime"]),
                        description = Convert.ToString(dr["description"]),
                        numberAttendees = Convert.ToInt16(dr["numberAttendees"]),
                        createdAt = Convert.ToDateTime(dr["createdAt"]),
                        updatedAt = Convert.ToDateTime(dr["updatedAt"])
                    });
                }
            }

            return rtn;
        }

        public RoomModel get(int id){
            RoomModel  rtn = null;

            SqlParameter[] parameters = {
                new SqlParameter{ ParameterName= "@id", Value = id, DbType = DbType.Int32}
            };

            DataTable dt = base.ExecuteDataTable("usp_room_s_room",parameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                rtn = new RoomModel{
                        id = id,
                        name = Convert.ToString(dr["name"]),
                        hourPrice = Convert.ToDecimal(dr["hourPrice"]),
                        cleaningTime = Convert.ToString(dr["cleaningTime"]),
                        description = Convert.ToString(dr["description"]),
                        numberAttendees = Convert.ToInt16(dr["numberAttendees"]),
                        createdAt = Convert.ToDateTime(dr["createdAt"]),
                        updatedAt = Convert.ToDateTime(dr["updatedAt"])
                };
            }

            return rtn;
        }

        public bool insert(RoomModel room){
            bool  rtn = false;

            SqlParameter[] parameters = {
                new SqlParameter{ ParameterName= "@name", Value = room.name},
                new SqlParameter{ ParameterName= "@hourPrice", Value = room.hourPrice},
                new SqlParameter{ ParameterName= "@cleaningTime", Value = room.cleaningTime},
                new SqlParameter{ ParameterName= "@description", Value = room.description},
                new SqlParameter{ ParameterName= "@numberAttendees", Value = room.numberAttendees},
                new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
            };

            SqlParameter[] outputs = base.ExecuteNonQuery("usp_room_i_room", parameters);

            if (outputs !=null && outputs.Length>0)
            {
                rtn = Convert.ToBoolean(outputs[0].Value);
            }

            return rtn;
        }

        public bool update(RoomModel room,int id){
            bool  rtn = false;

            SqlParameter[] parameters = {
                new SqlParameter{ ParameterName= "@id", Value = id},
                new SqlParameter{ ParameterName= "@name", Value = room.name},
                new SqlParameter{ ParameterName= "@hourPrice", Value = room.hourPrice},
                new SqlParameter{ ParameterName= "@cleaningTime", Value = room.cleaningTime},
                new SqlParameter{ ParameterName= "@description", Value = room.description},
                new SqlParameter{ ParameterName= "@numberAttendees", Value = room.numberAttendees},
                new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
            };

            SqlParameter[] outputs = base.ExecuteNonQuery("usp_room_u_room", parameters);
            if (outputs !=null && outputs.Length>0)
            {
                rtn = Convert.ToBoolean(outputs[0].Value);
            }

            return rtn;
        }

        public bool delete(int id){
            bool  rtn = false;

            SqlParameter[] parameters = {
                new SqlParameter{ ParameterName= "@id", Value = id},
                new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
            };

            SqlParameter[] outputs = base.ExecuteNonQuery("usp_room_d_room", parameters);

            if (outputs !=null && outputs.Length>0)
            {
                rtn = Convert.ToBoolean(outputs[0].Value);
            }

            return rtn;
        }
    }
}