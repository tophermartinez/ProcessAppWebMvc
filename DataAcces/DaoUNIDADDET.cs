using Entity_Layer;
using DataAcces.ICRUDTODO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces.Conexion;
using System.Data.OracleClient;

namespace DataAcces
{
    public class DaoUNIDADDET : OracleConexion, ICRUDTODO<UNIDAD_DETALLE>
    {

        public string Delete(string dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_DELETE_UNIDADDET", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_ID", OracleType.Number)).Value = dto;
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

        public string Insert(UNIDAD_DETALLE dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_CREATE_UNIDADDET", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        //command.Parameters.Add(new OracleParameter("ID", OracleType.Number)).Value = dto.ID;
                        command.Parameters.Add(new OracleParameter("p_ID_UNIDAD", OracleType.Number)).Value = dto.ID_UNIDAD;
                        command.Parameters.Add(new OracleParameter("NOMBRE_UNIDAD", OracleType.VarChar)).Value = dto.NOMBRE_UNIDAD;
                        command.Parameters.Add(new OracleParameter("P_ID_TAREA", OracleType.Number)).Value = dto.ID_TAREA;
                        command.Parameters.Add(new OracleParameter("NOMBRE_TAREA", OracleType.VarChar)).Value = dto.NOMBRE_TAREA;
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar, 50)).Value = System.Data.ParameterDirection.Output;
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

        public List<UNIDAD_DETALLE> Read()
        {
            List<UNIDAD_DETALLE> list = new List<UNIDAD_DETALLE>();
            UNIDAD_DETALLE dto = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("LIST_UNIDADDET", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_CURSOR", OracleType.Cursor)).Direction =
                        System.Data.ParameterDirection.Output;

                        using (OracleDataReader dr = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                        {
                            while (dr.Read())
                            {
                                dto = new UNIDAD_DETALLE();
                                dto.id = Convert.ToInt32(dr["id"]);
                                dto.ID_UNIDAD = Convert.ToInt32(dr["ID_UNIDAD"]);
                                dto.NOMBRE_UNIDAD = Convert.ToString(dr["NOMBRE_UNIDAD"]);
                                dto.ID_TAREA = Convert.ToInt32(dr["ID_TAREA"]);
                                dto.NOMBRE_TAREA = Convert.ToString(dr["NOMBRE_TAREA"]);
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

        public string Update(UNIDAD_DETALLE dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_UPDATE_UNIDADDET", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_ID", OracleType.Number)).Value = dto.id;
                        command.Parameters.Add(new OracleParameter("P_ID_UNIDAD", OracleType.Number)).Value = dto.ID_UNIDAD;
                        command.Parameters.Add(new OracleParameter("P_NOMBRE_UNIDAD", OracleType.VarChar)).Value = dto.NOMBRE_UNIDAD;
                        command.Parameters.Add(new OracleParameter("P_ID_TAREA", OracleType.Number)).Value = dto.ID_TAREA;
                        command.Parameters.Add(new OracleParameter("P_NOMBRE_TAREA", OracleType.VarChar)).Value = dto.NOMBRE_TAREA;
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
