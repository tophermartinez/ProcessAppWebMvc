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
    public class DaoUnidad : OracleConexion, ICRUDTODO<UNIDAD>
    {

        public string Delete(string dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_DELETE_UNIDAD", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_ID_UNIDAD", OracleType.Number)).Value = dto;
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

        public string Insert(UNIDAD dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_CREATE_UNIDAD", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        // command.Parameters.Add(new OracleParameter("IDTAREA", OracleType.Number)).Value = dto.IDTAREA;
                        command.Parameters.Add(new OracleParameter("NOMBRE", OracleType.VarChar)).Value = dto.NOMBRE;
                        command.Parameters.Add(new OracleParameter("DETALLE", OracleType.VarChar)).Value = dto.DETALLE;
                        command.Parameters.Add(new OracleParameter("p_Rutusu", OracleType.Number)).Value = dto.RUT_USU;
                        if (dto.FechaEstimada != "")
                        {
                            command.Parameters.Add(new OracleParameter("p_FechaEst", OracleType.DateTime)).Value = dto.FechaEstimada;
                        }
                        else
                        {
                            command.Parameters.Add(new OracleParameter("p_FechaEst", OracleType.DateTime)).Value = DBNull.Value;
                        }
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar, 500)).Value = System.Data.ParameterDirection.Output;
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

        public List<UNIDAD> Read()
        {
            List<UNIDAD> list = new List<UNIDAD>();
            UNIDAD dto = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("LIST_UNIDAD", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_CURSOR", OracleType.Cursor)).Direction =
                        System.Data.ParameterDirection.Output;

                        using (OracleDataReader dr = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                        {
                            while (dr.Read())
                            {
                                dto = new UNIDAD();
                                dto.ID_UNIDAD = Convert.ToInt32(dr["ID_UNIDAD"]);
                                dto.NOMBRE = Convert.ToString(dr["NOMBRE"]);
                                dto.DETALLE = Convert.ToString(dr["DETALLE"]);
                                dto.FECHACREACION = Convert.ToDateTime(dr["FECHACREACION"]);
                                dto.FechaEstimada = Convert.ToString(dr["FECHA_ESTIMADA"]);
                                dto.FECHA_ACTUAL = Convert.ToString(dr["fecha_actual"]);
                                dto.FECHA_TERMINO = Convert.ToString(dr["FECHA_TERMINO"]);
                                dto.nombre_usuario = Convert.ToString(dr["nombre_usuario"]);
                                dto.RUT_USU = Convert.ToInt32(dr["rut_usu"]);
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

        public string Update(UNIDAD dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_UPDATE_UNIDAD", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_ID_UNIDAD", OracleType.Number)).Value = dto.ID_UNIDAD;
                        command.Parameters.Add(new OracleParameter("P_NOMBRE", OracleType.VarChar)).Value = dto.NOMBRE;
                        command.Parameters.Add(new OracleParameter("P_DETALLE", OracleType.VarChar)).Value = dto.DETALLE;
                        command.Parameters.Add(new OracleParameter("p_Rutusu", OracleType.Int32)).Value = dto.RUT_USU;
                        if (dto.FechaEstimada != null)
                        {
                            command.Parameters.Add(new OracleParameter("p_FechaEst", OracleType.DateTime)).Value = dto.FechaEstimada;
                        }
                        else
                        {
                            command.Parameters.Add(new OracleParameter("p_FechaEst", OracleType.DateTime)).Value = DBNull.Value;
                        }
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



        public string DeleteF(string dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_DELETE_UNIDAD", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_ID_UNIDAD", OracleType.Number)).Value = dto;
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

        public string InsertF(UNIDAD dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_CREATE_UNIDAD_F", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        // command.Parameters.Add(new OracleParameter("IDTAREA", OracleType.Number)).Value = dto.IDTAREA;
                        command.Parameters.Add(new OracleParameter("NOMBRE", OracleType.VarChar)).Value = dto.NOMBRE;
                        command.Parameters.Add(new OracleParameter("DETALLE", OracleType.VarChar)).Value = dto.DETALLE;
                        command.Parameters.Add(new OracleParameter("P_FECHA_TERMINO", OracleType.VarChar)).Value = dto.FECHA_TERMINO;
                        command.Parameters.Add(new OracleParameter("P_EMPRESA", OracleType.Number)).Value = dto.RUT_EM;
                        command.Parameters.Add(new OracleParameter("P_RUT", OracleType.VarChar)).Value = dto.RUT_USU;
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

        public List<UNIDAD> ReadF()
        {
            List<UNIDAD> list = new List<UNIDAD>();
            UNIDAD dto = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("LIST_UNIDAD_F", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_CURSOR", OracleType.Cursor)).Direction =
                        System.Data.ParameterDirection.Output;

                        using (OracleDataReader dr = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                        {
                            while (dr.Read())
                            {
                                dto = new UNIDAD();
                                dto.ID_UNIDAD = Convert.ToInt32(dr["ID_UNIDAD"]);
                                dto.NOMBRE = Convert.ToString(dr["NOMBRE"]);
                                dto.DETALLE = Convert.ToString(dr["DETALLE"]);
                                dto.FECHA_TERMINO = Convert.ToString(dr["FECHA_TERMINO"]);
                                dto.FECHACREACION = Convert.ToDateTime(dr["FECHACREACION"]);
                                dto.RUT_USU = Convert.ToInt32(dr["RUT_USU"]);
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

        public string UpdateF(UNIDAD dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_UPDATE_UNIDAD_F", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_ID_UNIDAD", OracleType.Number)).Value = dto.ID_UNIDAD;
                        command.Parameters.Add(new OracleParameter("P_NOMBRE", OracleType.VarChar)).Value = dto.NOMBRE;
                        command.Parameters.Add(new OracleParameter("P_DETALLE", OracleType.VarChar)).Value = dto.DETALLE;
                        command.Parameters.Add(new OracleParameter("P_FECHA_TERMINO", OracleType.DateTime)).Value = dto.FECHA_TERMINO;
                        command.Parameters.Add(new OracleParameter("P_RUT_USU", OracleType.VarChar)).Value = dto.RUT_USU;
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



        public List<UNIDAD> ListarUnidades(int rut_empresa)
        {
            List<UNIDAD> list = new List<UNIDAD>();
            UNIDAD dto = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand cmd = new OracleCommand("SELECT ID_UNIDAD, NOMBRE FROM UNIDAD WHERE RUT_EM = " + rut_empresa , cn))
                    {
                        OracleDataReader _reader = cmd.ExecuteReader();
                        while (_reader.Read())
                        {
                            dto = new UNIDAD();
                            dto.ID_UNIDAD = Convert.ToInt32(_reader["ID_UNIDAD"]);
                            dto.NOMBRE = Convert.ToString(_reader["NOMBRE"]);
                            list.Add(dto);
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


        public string Replicar(int id_unidad)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_UNIDAD_REPLICAR", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        // command.Parameters.Add(new OracleParameter("IDTAREA", OracleType.Number)).Value = dto.IDTAREA;
                        command.Parameters.Add(new OracleParameter("P_ID_UNIDAD", OracleType.Number)).Value = id_unidad;
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar, 500)).Value = System.Data.ParameterDirection.Output;
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









    }
}
