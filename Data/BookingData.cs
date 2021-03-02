using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using getaclub_api.Library;
using getaclub_api.Models;
using System;

namespace getaclub_api.Data
{
    public class BookingData : MsSqlExtensions
    { 
        public List<BookingModel> all(){
            List<BookingModel> rtn = null;
            DataTable dt = base.ExecuteDataTable("usp_bookings_s_bookings");
            if (dt!=null && dt.Rows.Count>0)
            {
                rtn = new List<BookingModel>();

                foreach(DataRow dr in dt.Rows)
                {
                    rtn.Add(new BookingModel{
                        id = Convert.ToInt16(dr["id"]),
                        idRoom = Convert.ToInt16(dr["idRoom"]),
                        date = Convert.ToString(dr["date"]),
                        startHour = Convert.ToString(dr["startHour"]),
                        endHour = Convert.ToString(dr["endHour"]),
                        createdAt = Convert.ToDateTime(dr["createdAt"]),
                        updatedAt = Convert.ToDateTime(dr["updatedAt"]),
                        client = new ClientModel{
                            id = Convert.ToInt16(dr["idClient"]),
                            name = Convert.ToString(dr["name"]),
                            lastName = Convert.ToString(dr["lastName"]),
                            surName = Convert.ToString(dr["surName"]),
                            businessName = Convert.ToString(dr["businessName"]),
                            idDocumentType = Convert.ToInt16(dr["idDocumentType"]),
                            document = Convert.ToString(dr["document"]),
                            email = Convert.ToString(dr["email"]),
                            phoneCode = Convert.ToString(dr["phoneCode"]),
                            phone = Convert.ToString(dr["phone"]),
                            gender = Convert.ToString(dr["gender"])
                        }
                    });
                }
            }

            return rtn;
        }

        public BookingModel get(int id){
            BookingModel  rtn = null;

            SqlParameter[] parameters = {
                new SqlParameter{ ParameterName= "@id", Value = id, DbType = DbType.Int32}
            };

            DataTable dt = base.ExecuteDataTable("usp_booking_s_booking",parameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                rtn = new BookingModel{
                        id = id,
                        idRoom = Convert.ToInt16(dr["idRoom"]),
                        date = Convert.ToString(dr["date"]),
                        startHour = Convert.ToString(dr["startHour"]),
                        endHour = Convert.ToString(dr["endHour"]),
                        createdAt = Convert.ToDateTime(dr["createdAt"]),
                        updatedAt = Convert.ToDateTime(dr["updatedAt"]),
                        client = new ClientModel{
                            id = Convert.ToInt16(dr["idClient"]),
                            name = Convert.ToString(dr["name"]),
                            lastName = Convert.ToString(dr["lastName"]),
                            surName = Convert.ToString(dr["surName"]),
                            businessName = Convert.ToString(dr["businessName"]),
                            idDocumentType = Convert.ToInt16(dr["idDocumentType"]),
                            document = Convert.ToString(dr["document"]),
                            email = Convert.ToString(dr["email"]),
                            phoneCode = Convert.ToString(dr["phoneCode"]),
                            phone = Convert.ToString(dr["phone"]),
                            gender = Convert.ToString(dr["gender"])
                        }
                };
            }

            return rtn;
        }

        public bool insert(BookingModel booking){
            bool  rtn = false;

            SqlParameter[] parameters = {
                new SqlParameter{ ParameterName= "@idRoom", Value = booking.idRoom},
                new SqlParameter{ ParameterName= "@idClient", Value = booking.idClient},
                new SqlParameter{ ParameterName= "@date", Value = booking.date},
                new SqlParameter{ ParameterName= "@startHour", Value = booking.startHour},
                new SqlParameter{ ParameterName= "@endHour", Value = booking.endHour},
                new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
            };

            SqlParameter[] outputs = base.ExecuteNonQuery("usp_booking_i_booking", parameters);

            if (outputs !=null && outputs.Length>0)
            {
                rtn = Convert.ToBoolean(outputs[0].Value);
            }

            return rtn;
        }

        public bool update(BookingModel booking,int id){
            bool  rtn = false;

            SqlParameter[] parameters = {
                new SqlParameter{ ParameterName= "@id", Value = id},
                new SqlParameter{ ParameterName= "@idRoom", Value = booking.idRoom},
                new SqlParameter{ ParameterName= "@idClient", Value = booking.idClient},
                new SqlParameter{ ParameterName= "@date", Value = booking.date},
                new SqlParameter{ ParameterName= "@startHour", Value = booking.startHour},
                new SqlParameter{ ParameterName= "@endHour", Value = booking.endHour},
                new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
            };

            SqlParameter[] outputs = base.ExecuteNonQuery("usp_booking_u_booking", parameters);
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

            SqlParameter[] outputs = base.ExecuteNonQuery("usp_booking_d_booking", parameters);

            if (outputs !=null && outputs.Length>0)
            {
                rtn = Convert.ToBoolean(outputs[0].Value);
            }

            return rtn;
        }
    }
}