using DataAcces.Cliente;
using DataAcces.Conexion;
using DataAcces.Tarea;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class DaoTarea : OracleConexion, ICRUDT<TAREA>
    {
        public string Delete(string dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_DELETE_TAREA", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_IDTAREA", OracleType.Number)).Value = dto;
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

        public string Insert(TAREA dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("INSERT_TAREA", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                       
                        command.Parameters.Add(new OracleParameter("P_NOMBRETAREA", OracleType.VarChar)).Value = dto.NOMBRETAREA;
                        command.Parameters.Add(new OracleParameter("P_ESTADO_TAREA", OracleType.Number)).Value = dto.ESTADO_TAREA;
                        //command.Parameters.Add(new OracleParameter("p_RutEmp", OracleType.Number)).Value = dto.RUT_EM;
                        command.Parameters.Add(new OracleParameter("p_Rutusu", OracleType.Number)).Value = dto.RUT_USU;
                        if (dto.FechaEstimada != "")
                        {
                            command.Parameters.Add(new OracleParameter("p_FechaEst", OracleType.DateTime)).Value = dto.FechaEstimada;
                        }
                        else
                        {
                            command.Parameters.Add(new OracleParameter("p_FechaEst", OracleType.DateTime)).Value = DBNull.Value;
                        }
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar, 500)).Direction = System.Data.ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        result = Convert.ToString(command.Parameters["P_RESULT"].Value);
                        //command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar, 50)).Value = System.Data.ParameterDirection.Output;
                        //command.ExecuteNonQuery();
                        //result = Convert.ToString(command.Parameters["P_RESULT"].Value);
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

        public List<TAREA> Read()
        {
            List<TAREA> list = new List<TAREA>();
            TAREA dto = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("LIST_TAREA", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_CURSOR", OracleType.Cursor)).Direction =
                        System.Data.ParameterDirection.Output;

                        using (OracleDataReader dr = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                        {
                            while (dr.Read())
                            {
                                dto = new TAREA();
                                dto.IDTAREA = Convert.ToInt32(dr["IDTAREA"]);
                                dto.NOMBRETAREA = Convert.ToString(dr["NOMBRETAREA"]);
                                dto.FECHACREACION = Convert.ToDateTime(dr["FECHACREACION"]);
                                dto.ESTADO_TAREA = Convert.ToInt32(dr["ESTADO_TAREA"]);
                                dto.FECHA_TERMINO = Convert.ToString(dr["fecha_termino"]);
                                dto.FechaEstimada = Convert.ToString(dr["fecha_estimada"]);
                                dto.RUT_USU = Convert.ToInt32(dr["rut_usu"]);
                                dto.nombre_usuario = Convert.ToString(dr["nombre_usuario"]);

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

        public string Update(TAREA dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_UPDATE_TAREA", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_IDTAREA", OracleType.Number)).Value = dto.IDTAREA;
                        command.Parameters.Add(new OracleParameter("P_NOMBRETAREA", OracleType.VarChar)).Value = dto.NOMBRETAREA;
                        command.Parameters.Add(new OracleParameter("P_IDESTADO", OracleType.Number)).Value = dto.ESTADO_TAREA;
                        command.Parameters.Add(new OracleParameter("p_Rutusu", OracleType.Number)).Value = dto.RUT_USU;
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

        public List<estado> ObtenerEstadoTarea()
        {
            List<estado> list = new List<estado>();
            estado dto = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand cmd = new OracleCommand("SELECT ID_ESTADO, NOMBRE, DESCRIPCION FROM estado where Descripcion = 'Tarea'", cn))
                    {
                        OracleDataReader _reader = cmd.ExecuteReader();
                        while (_reader.Read())
                        {
                            dto = new estado();
                            dto.ID = Convert.ToInt32(_reader["ID_ESTADO"]);
                            dto.NOMBRE = Convert.ToString(_reader["NOMBRE"]);
                            dto.DESCRIPCION = Convert.ToString(_reader["DESCRIPCION"]);
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

        public List<TAREA> ObtenerTareas(int rut , int rut_empresa , int tipo_busqueda)
        {
            List<TAREA> list = new List<TAREA>();
            TAREA dto = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand cmd = new OracleCommand("SELECT IDTAREA, " +
                                                                    "NOMBRETAREA " +
                                                                    "FROM TAREA " +
                                                                    "WHERE RUT_EM = " + rut_empresa  + 
                                                                    "AND ESTADO_TAREA NOT IN (13)", cn))
                    {
                        OracleDataReader _reader = cmd.ExecuteReader();
                        while (_reader.Read())
                        {
                            dto = new TAREA();
                            dto.IDTAREA = Convert.ToInt32(_reader["IDTAREA"]);
                            dto.NOMBRETAREA = Convert.ToString(_reader["NOMBRETAREA"]);
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
    }  
}
