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
                    using (OracleCommand command = new OracleCommand("SP_CREATE_TAREA", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        // command.Parameters.Add(new OracleParameter("IDTAREA", OracleType.Number)).Value = dto.IDTAREA;
                        command.Parameters.Add(new OracleParameter("NOMBRETAREA", OracleType.VarChar)).Value = dto.NOMBRETAREA;
                        // command.Parameters.Add(new OracleParameter("FECHACREACION", OracleType.DateTime)).Value = dto.FECHACREACION;
                        command.Parameters.Add(new OracleParameter("IDESTADO", OracleType.Number)).Value = dto.ESTADO_TAREA;
                        //command.Parameters.Add(new OracleParameter("FECHA_ACTUAL", OracleType.Number)).Value = dto.FECHA_ACTUAL;
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
                                dto.FECHA_ACTUAL = Convert.ToDateTime(dr["FECHA_ACTUAL"]);
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
                       // command.Parameters.Add(new OracleParameter("P_FECHACREACION", OracleType.DateTime)).Value = dto.FECHACREACION;
                        command.Parameters.Add(new OracleParameter("P_IDESTADO", OracleType.Number)).Value = dto.ESTADO_TAREA;
                       // command.Parameters.Add(new OracleParameter("p_FECHA_ACTUAL", OracleType.DateTime)).Value = dto.FECHA_ACTUAL;
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
