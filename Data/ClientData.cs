using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using getaclub_api.Library;
using getaclub_api.Models;
using System;

namespace getaclub_api.Data
{
    public class ClientData : MsSqlExtensions
    { 
        public List<ClientModel> all(){
            List<ClientModel> rtn = null;
            DataTable dt = base.ExecuteDataTable("usp_clients_s_clients");
            if (dt!=null && dt.Rows.Count>0)
            {
                rtn = new List<ClientModel>();

                foreach(DataRow dr in dt.Rows)
                {
                    rtn.Add(new ClientModel{
                        id = Convert.ToInt16(dr["id"]),
                        name = Convert.ToString(dr["name"]),
                        lastName = Convert.ToString(dr["lastName"]),
                        surName = Convert.ToString(dr["surName"]),
                        businessName = Convert.ToString(dr["businessName"]),
                        idDocumentType = Convert.ToInt16(dr["idDocumentType"]),
                        document = Convert.ToString(dr["document"]),
                        email = Convert.ToString(dr["email"]),
                        phoneCode = Convert.ToString(dr["phoneCode"]),
                        phone = Convert.ToString(dr["phone"]),
                        gender = Convert.ToString(dr["gender"]),
                        createdAt = Convert.ToDateTime(dr["createdAt"]),
                        updatedAt = Convert.ToDateTime(dr["updatedAt"])
                    });
                }
            }

            return rtn;
        }

        public ClientModel get(int id){
            ClientModel  rtn = null;

            SqlParameter[] parameters = {
                new SqlParameter{ ParameterName= "@id", Value = id, DbType = DbType.Int32}
            };

            DataTable dt = base.ExecuteDataTable("usp_client_s_client",parameters);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                rtn = new ClientModel{
                        id = id,
                        name = Convert.ToString(dr["name"]),
                        lastName = Convert.ToString(dr["lastName"]),
                        surName = Convert.ToString(dr["surName"]),
                        businessName = Convert.ToString(dr["businessName"]),
                        idDocumentType = Convert.ToInt16(dr["idDocumentType"]),
                        document = Convert.ToString(dr["document"]),
                        email = Convert.ToString(dr["email"]),
                        phoneCode = Convert.ToString(dr["phoneCode"]),
                        phone = Convert.ToString(dr["phone"]),
                        gender = Convert.ToString(dr["gender"]),
                        createdAt = Convert.ToDateTime(dr["createdAt"]),
                        updatedAt = Convert.ToDateTime(dr["updatedAt"])
                };
            }

            return rtn;
        }

        public bool insert(ClientModel client){
            bool  rtn = false;
            Console.WriteLine(client.name);
            SqlParameter[] parameters = {
                new SqlParameter{ ParameterName= "@name", Value = client.name},
                new SqlParameter{ ParameterName= "@lastName", Value = client.lastName},
                new SqlParameter{ ParameterName= "@surName", Value = client.surName},
                new SqlParameter{ ParameterName= "@businessName", Value = client.businessName},
                new SqlParameter{ ParameterName= "@idDocumentType", Value = client.idDocumentType},
                new SqlParameter{ ParameterName= "@document", Value = client.document},
                new SqlParameter{ ParameterName= "@email", Value = client.email},
                new SqlParameter{ ParameterName= "@phoneCode", Value = client.phoneCode},
                new SqlParameter{ ParameterName= "@phone", Value = client.phone},
                new SqlParameter{ ParameterName= "@gender", Value = client.gender},
                new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
            };

            SqlParameter[] outputs = base.ExecuteNonQuery("usp_client_i_client", parameters);

            if (outputs !=null && outputs.Length>0)
            {
                rtn = Convert.ToBoolean(outputs[0].Value);
            }

            return rtn;
        }

        public bool update(ClientModel client,int id){
            bool  rtn = false;

            SqlParameter[] parameters = {
                new SqlParameter{ ParameterName= "@id", Value = id},
                new SqlParameter{ ParameterName= "@name", Value = client.name},
                new SqlParameter{ ParameterName= "@lastName", Value = client.lastName},
                new SqlParameter{ ParameterName= "@surName", Value = client.surName},
                new SqlParameter{ ParameterName= "@businessName", Value = client.businessName},
                new SqlParameter{ ParameterName= "@idDocumentType", Value = client.idDocumentType},
                new SqlParameter{ ParameterName= "@document", Value = client.document},
                new SqlParameter{ ParameterName= "@email", Value = client.email},
                new SqlParameter{ ParameterName= "@phoneCode", Value = client.phoneCode},
                new SqlParameter{ ParameterName= "@phone", Value = client.phone},
                new SqlParameter{ ParameterName= "@gender", Value = client.gender},
                new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
            };

            SqlParameter[] outputs = base.ExecuteNonQuery("usp_client_u_client", parameters);
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

            SqlParameter[] outputs = base.ExecuteNonQuery("usp_client_d_client", parameters);

            if (outputs !=null && outputs.Length>0)
            {
                rtn = Convert.ToBoolean(outputs[0].Value);
            }

            return rtn;
        }

        public bool exist(int id){
            bool  rtn = false;

            SqlParameter[] parameters = {
                new SqlParameter{ ParameterName= "@id", Value = id},
                new SqlParameter{ ParameterName = "@result", Direction = ParameterDirection.Output, DbType = DbType.Int32 }
            };

            SqlParameter[] outputs = base.ExecuteNonQuery("usp_client_e_client", parameters);

            if (outputs !=null && outputs.Length>0)
            {
                rtn = Convert.ToBoolean(outputs[0].Value);
            }

            return rtn;
        }
    }
}