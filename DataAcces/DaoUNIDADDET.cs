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
                        command.Parameters.Add(new OracleParameter("P_ID_UNIDAD", OracleType.Number)).Value = dto.ID_UNIDAD;
                        command.Parameters.Add(new OracleParameter("P_ID_TAREA", OracleType.Number)).Value = dto.ID_TAREA;
                        command.Parameters.Add(new OracleParameter("P_ESTAT", OracleType.Int32)).Value = dto.ESTADO;
                        //command.Parameters.Add(new OracleParameter("P_FECHEST", OracleType.DateTime)).Value = dto.FECHA_ESTIMADA;
                        if (dto.FECHA_ESTIMADA != "")
                        {
                            command.Parameters.Add(new OracleParameter("P_FECHEST", OracleType.DateTime)).Value = dto.FECHA_ESTIMADA;
                        }
                        else
                        {
                            command.Parameters.Add(new OracleParameter("P_FECHEST", OracleType.DateTime)).Value = DBNull.Value;
                        }
                        command.Parameters.Add(new OracleParameter("P_RUT_USU", OracleType.VarChar)).Value = dto.Rut_Usu;
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar,50)).Value = System.Data.ParameterDirection.Output;
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
                                dto.FECHA_TERMINO = Convert.ToString(dr["FECHA_TERMINO"]);
                                dto.FECHACREACION = Convert.ToDateTime(dr["FECHACREACION"]);
                                dto.ESTADO = Convert.ToInt32(dr["ESTADO_TAREA"]);
                                dto.FECHA_ESTIMADA = Convert.ToString(dr["FECHA_ESTIMADA"]);
                                dto.Rut_Usu = Convert.ToInt32(dr["rut_usu"]);
                                dto.NOMBRE_USUARIO = Convert.ToString(dr["NOMBRE_USUARIO"]);
                                dto.NOMBRE_ESTADO = Convert.ToString(dr["NOMBRE_ESTADO"]);
                                dto.DIAS_DIF = Convert.ToInt32(dr["DIAS_DIF"]);
                                dto.ATRASO = Convert.ToInt32(dr["Atraso"]);
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
                        command.Parameters.Add(new OracleParameter("P_ID_TAREA", OracleType.Number)).Value = dto.ID_TAREA;
                        command.Parameters.Add(new OracleParameter("p_ESTADO", OracleType.VarChar)).Value = dto.ESTADO;
                        command.Parameters.Add(new OracleParameter("p_FECHA_ES", OracleType.DateTime)).Value = dto.FECHA_ESTIMADA; 
                        command.Parameters.Add(new OracleParameter("p_rutusu", OracleType.VarChar)).Value = Convert.ToInt32(dto.Rut_Usu); 
                        command.Parameters.Add(new OracleParameter("P_ID_UNIDAD", OracleType.Int32)).Value = dto.ID_UNIDAD; 
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

        public List<UNIDAD_DETALLE> obtenerUnidadDetalle(int id_unidad)  //( USUARIO dto)
        {
            List<UNIDAD_DETALLE> result = new List<UNIDAD_DETALLE>();
            try
            {
                UNIDAD_DETALLE dto = null;
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();

                    OracleCommand cmd = new OracleCommand(" SELECT   ud.ID,ud.ID_UNIDAD,ud.NOMBRE_UNIDAD,ud.ID_TAREA,ud.NOMBRE_TAREA,ud.FECHA_TERMINO,ud.FECHACREACION,ud.ESTADO_TAREA,TO_CHAR(ud.FECHA_ESTIMADA, 'yyyy-mm-dd') AS FECHA_ESTIMADA,ud.rut_usuario as rut_usu,us.NOMBRE_USUARIO,es.nombre as NOMBRE_ESTADO,(case when ud.FECHA_ESTIMADA < SYSDATE then 1 else 0 end) as Atraso,nvl((case when (to_date(ud.fecha_estimada, 'dd-MM-yyyy') - to_date(SYSDATE, 'dd-mm-yyyy')) < 0 then 0 else to_date(ud.fecha_estimada, 'dd-MM-yyyy') - to_date(SYSDATE, 'dd-mm-yyyy') end), 0) AS DIAS_DIF FROM UNIDAD_DETALLE ud LEFT JOIN USUARIO us ON us.RUT = ud.rut_usuario inner join estado es on es.id_estado = ud.estado_tarea where ud.id_unidad = " + id_unidad , cn);

                    OracleDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        dto = new UNIDAD_DETALLE();
                        dto.id = Convert.ToInt32(dr["id"]);
                        dto.ID_UNIDAD = Convert.ToInt32(dr["ID_UNIDAD"]);
                        dto.NOMBRE_UNIDAD = Convert.ToString(dr["NOMBRE_UNIDAD"]);
                        dto.ID_TAREA = Convert.ToInt32(dr["ID_TAREA"]);
                        dto.NOMBRE_TAREA = Convert.ToString(dr["NOMBRE_TAREA"]);
                        dto.FECHA_TERMINO = Convert.ToString(dr["FECHA_TERMINO"]);
                        dto.FECHACREACION = Convert.ToDateTime(dr["FECHACREACION"]);
                        dto.ESTADO = Convert.ToInt32(dr["ESTADO_TAREA"]);
                        dto.FECHA_ESTIMADA = Convert.ToString(dr["FECHA_ESTIMADA"]);
                        dto.Rut_Usu = Convert.ToInt32(dr["rut_usu"]);
                        dto.NOMBRE_USUARIO = Convert.ToString(dr["NOMBRE_USUARIO"]);
                        dto.NOMBRE_ESTADO = Convert.ToString(dr["NOMBRE_ESTADO"]);
                        dto.DIAS_DIF = Convert.ToInt32(dr["DIAS_DIF"]);
                        dto.ATRASO = Convert.ToInt32(dr["Atraso"]);
                        result.Add(dto);
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                new Exception("Usuario o Contraseña incorrecta " + ex.Message);
            }
            return result;

        }
    }
}
