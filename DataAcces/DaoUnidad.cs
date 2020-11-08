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
