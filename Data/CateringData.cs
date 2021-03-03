using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using getaclub_api.Library;
using getaclub_api.Models;
using System;

namespace getaclub_api.Data
{
    public class CateringData : MsSqlExtensions
    { 
        public List<CateringModel> all(){
            List<CateringModel> rtn = null;
            DataTable dt = base.ExecuteDataTable("usp_caterings_s_caterings");
            if (dt!=null && dt.Rows.Count>0)
            {
                rtn = new List<CateringModel>();

                foreach(DataRow dr in dt.Rows)
                {
                    rtn.Add(new CateringModel{
                        id = Convert.ToInt16(dr["id"]),
                        name = Convert.ToString(dr["name"]),
                        price = Convert.ToDecimal(dr["price"]),
                        createdAt = Convert.ToDateTime(dr["createdAt"]),
                        updatedAt = Convert.ToDateTime(dr["updatedAt"])
                    });
                }
            }

            return rtn;
        }

        public CateringModel get(int id){
            CateringModel  rtn = null;

            SqlParameter[] parameters = {
                new SqlParameter{ ParameterName= "@id", Value = id, DbType = DbType.Int32}
            };

            DataTable dt = base.ExecuteDataTable("usp_catering_s_catering",parameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                rtn = new CateringModel{
                        id = id,
                        name = Convert.ToString(dr["name"]),
                        price = Convert.ToDecimal(dr["price"]),
                        createdAt = Convert.ToDateTime(dr["createdAt"]),
                        updatedAt = Convert.ToDateTime(dr["updatedAt"])
                };
            }

            return rtn;
        }

        public bool insert(CateringModel catering){
            bool  rtn = false;

            SqlParameter[] parameters = {
                new SqlParameter{ ParameterName= "@name", Value = catering.name},
                new SqlParameter{ ParameterName= "@price", Value = catering.price},
                new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
            };

            SqlParameter[] outputs = base.ExecuteNonQuery("usp_catering_i_catering", parameters);

            if (outputs !=null && outputs.Length>0)
            {
                rtn = Convert.ToBoolean(outputs[0].Value);
            }

            return rtn;
        }

        public bool update(CateringModel catering,int id){
            bool  rtn = false;

            SqlParameter[] parameters = {
                new SqlParameter{ ParameterName= "@id", Value = id},
                new SqlParameter{ ParameterName= "@name", Value = catering.name},
                new SqlParameter{ ParameterName= "@price", Value = catering.price},
                new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
            };

            SqlParameter[] outputs = base.ExecuteNonQuery("usp_catering_u_catering", parameters);
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

            SqlParameter[] outputs = base.ExecuteNonQuery("usp_catering_d_catering", parameters);

            if (outputs !=null && outputs.Length>0)
            {
                rtn = Convert.ToBoolean(outputs[0].Value);
            }

            return rtn;
        }
    }
}