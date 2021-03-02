using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using getaclub_api.Library;
using getaclub_api.Models;
using System;

namespace getaclub_api.Data
{
    public class ScheduleData : MsSqlExtensions
    { 
        public List<ScheduleModel> all(){
            List<ScheduleModel> rtn = null;
            DataTable dt = base.ExecuteDataTable("usp_room_s_schedules");

            if (dt!=null && dt.Rows.Count>0)
            {
                rtn = new List<ScheduleModel>();

                foreach(DataRow dr in dt.Rows)
                {
                    rtn.Add(new ScheduleModel{
                        id = Convert.ToInt16(dr["id"]),
                        idRoom = Convert.ToInt16(dr["idRoom"]),
                        day = Convert.ToInt16(dr["day"]),
                        startHour = Convert.ToString(dr["startHour"]),
                        endHour = Convert.ToString(dr["endHour"]),
                        createdAt = Convert.ToDateTime(dr["createdAt"]),
                        updatedAt = Convert.ToDateTime(dr["updatedAt"])
                    });
                }
            }

            return rtn;
        }

        public ScheduleModel get(int id){
            ScheduleModel  rtn = null;

            SqlParameter[] parameters = {
                new SqlParameter{ ParameterName= "@id", Value = id, DbType = DbType.Int32}
            };

            DataTable dt = base.ExecuteDataTable("usp_schedule_s_schedule",parameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                rtn = new ScheduleModel{
                        id = id,
                        idRoom = Convert.ToInt16(dr["idRoom"]),
                        day = Convert.ToInt16(dr["day"]),
                        startHour = Convert.ToString(dr["startHour"]),
                        endHour = Convert.ToString(dr["endHour"]),
                        createdAt = Convert.ToDateTime(dr["createdAt"]),
                        updatedAt = Convert.ToDateTime(dr["updatedAt"])
                };
            }

            return rtn;
        }

        public List<ScheduleModel> roomAll(int idRoom){
            List<ScheduleModel> rtn = null;

            SqlParameter[] parameters = {
                new SqlParameter{ ParameterName= "@idRoom", Value = idRoom, DbType = DbType.Int32}
            };

            DataTable dt = base.ExecuteDataTable("usp_room_s_schedule",parameters);

            if (dt!=null && dt.Rows.Count>0)
            {
                rtn = new List<ScheduleModel>();

                foreach(DataRow dr in dt.Rows)
                {
                    rtn.Add(new ScheduleModel{
                        id = Convert.ToInt16(dr["id"]),
                        day = Convert.ToInt16(dr["day"]),
                        startHour = Convert.ToString(dr["startHour"]),
                        endHour = Convert.ToString(dr["endHour"]),
                        createdAt = Convert.ToDateTime(dr["createdAt"]),
                        updatedAt = Convert.ToDateTime(dr["updatedAt"])
                    });
                }
            }

            return rtn;
        }
        

        public bool insert(ScheduleModel schedule){
            bool  rtn = false;

            SqlParameter[] parameters = {
                new SqlParameter{ ParameterName= "@idRoom", Value = schedule.idRoom},
                new SqlParameter{ ParameterName= "@day", Value = schedule.day},
                new SqlParameter{ ParameterName= "@startHour", Value = schedule.startHour},
                new SqlParameter{ ParameterName= "@endHour", Value = schedule.endHour},
                new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
            };

            SqlParameter[] outputs = base.ExecuteNonQuery("usp_room_i_schedule", parameters);

            if (outputs !=null && outputs.Length>0)
            {
                rtn = Convert.ToBoolean(outputs[0].Value);
            }

            return rtn;
        }

        public bool update(ScheduleModel schedule,int id){
            bool  rtn = false;

            SqlParameter[] parameters = {
                new SqlParameter{ ParameterName= "@id", Value = id},
                new SqlParameter{ ParameterName= "@idRoom", Value = schedule.idRoom},
                new SqlParameter{ ParameterName= "@day", Value = schedule.day},
                new SqlParameter{ ParameterName= "@startHour", Value = schedule.startHour},
                new SqlParameter{ ParameterName= "@endHour", Value = schedule.endHour},
                new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
            };

            SqlParameter[] outputs = base.ExecuteNonQuery("usp_room_u_schedule", parameters);
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

            SqlParameter[] outputs = base.ExecuteNonQuery("usp_room_d_schedule", parameters);

            if (outputs !=null && outputs.Length>0)
            {
                rtn = Convert.ToBoolean(outputs[0].Value);
            }

            return rtn;
        }
    }
}