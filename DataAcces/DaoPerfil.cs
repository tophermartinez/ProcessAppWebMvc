using DataAcces.Conexion;
using DataAcces.Perfil;
using DataAcces.Tarea;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
     public class DaoPerfil : OracleConexion, ICRUDP<PERFIL>
    {
        public string Delete(string dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_DELETE_PERFIL", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_ID_PERFIL", OracleType.Number)).Value = dto;
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar, 50)).Direction =
                            System.Data.ParameterDirection.Output;

                        command.ExecuteNonQuery();
                        result = Convert.ToString(command.Parameters["P_RESULT"].Value);
                    }
                    cn.Close();
                }

            }
            catch (Exception ex)
            {

                new Exception("Error en metodo ELiminar " + ex.Message);
            }
            return result;
        }

        public string Insert(PERFIL dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_CREATE_PERFIL", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        //command.Parameters.Add(new OracleParameter("ID_PERFIL", OracleType.Number)).Value = dto.ID_PERFIL;
                        command.Parameters.Add(new OracleParameter("NOMBRE", OracleType.VarChar)).Value = dto.NOMBRE;
                        command.Parameters.Add(new OracleParameter("DESCRIPCION", OracleType.VarChar)).Value = dto.DESCRIPCION;
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar)).Value = System.Data.ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        result = Convert.ToString(command.Parameters["P_RESULT"].Value);
                    }
                    cn.Close();


                }
            }
            catch (Exception ex)
            {

                new Exception("ERROR EN METODO INSERTAR" + ex.Message);
            }
            return result;
        }

        public List<PERFIL> Read()
        {
            List<PERFIL> list = new List<PERFIL>();
            PERFIL dto = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("LIST_PERFIL", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_CURSOR", OracleType.Cursor)).Direction =
                        System.Data.ParameterDirection.Output;

                        using (OracleDataReader dr = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                        {
                            while (dr.Read())
                            {
                                dto = new PERFIL();
                                dto.ID_PERFIL = Convert.ToInt32(dr["ID_PERFIL"]);
                                dto.NOMBRE = Convert.ToString(dr["NOMBRE"]);
                                dto.DESCRIPCION = Convert.ToString(dr["DESCRIPCION"]);
                                list.Add(dto);
                            }

                        }

                    }

                }
            }
            catch (Exception ex)
            {

                new Exception("Error en metodo listar" + ex.Message);
            }
            return list;
        }

        public string Update(PERFIL dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_UPDATE_PERFIL", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_ID_PERFIL", OracleType.Number)).Value = dto.ID_PERFIL;
                        command.Parameters.Add(new OracleParameter("P_NOMBRE", OracleType.VarChar)).Value = dto.NOMBRE;
                        command.Parameters.Add(new OracleParameter("P_DESCRIPCION", OracleType.VarChar)).Value = dto.DESCRIPCION;
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar, 50)).Value = System.Data.ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        result = Convert.ToString(command.Parameters["P_RESULT"].Value);
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {

                new Exception("ERROR EN METODO ACTUALIZAR" + ex.Message);
            }
            return result;
        }
    }
}
