
using DataAcces.Conexion;
using DataAcces.ICRUDTODO;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Data.OracleClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces
{
    public class DaoCliente2 : OracleConexion, ICRUDTODO<Usuario2>
    {

        public string Delete(string dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("DELETE_USUARIO", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("p_id", OracleType.Number)).Value = dto;
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

        public string Insert(Usuario2 dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("INSERT_USUARIO", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("RUT", OracleType.Number)).Value = dto.RUT;
                        command.Parameters.Add(new OracleParameter("DV", OracleType.VarChar)).Value = dto.DV;
                        command.Parameters.Add(new OracleParameter("NOMBRES", OracleType.VarChar)).Value = dto.NOMBRES;
                        command.Parameters.Add(new OracleParameter("APATERNO", OracleType.VarChar)).Value = dto.APELLIDO_PATERNO;
                        command.Parameters.Add(new OracleParameter("AMATERNO", OracleType.VarChar)).Value = dto.APELIIDO_MATERNO;
                        command.Parameters.Add(new OracleParameter("CORREO", OracleType.VarChar)).Value = dto.CORREO;
                        command.Parameters.Add(new OracleParameter("NUMERO", OracleType.Number)).Value = dto.NUMERO;
                        command.Parameters.Add(new OracleParameter("DIRECCION", OracleType.VarChar)).Value = dto.DIRECCION;
                        command.Parameters.Add(new OracleParameter("USUARIO", OracleType.VarChar)).Value = dto.NOMBRE_USUARIO;
                        command.Parameters.Add(new OracleParameter("CONTRASENA", OracleType.VarChar)).Value = dto.CONTRASENA;
                        command.Parameters.Add(new OracleParameter("ID_PERFIL", OracleType.Number)).Value = dto.ID_PERFIL;
                        command.Parameters.Add(new OracleParameter("ESTADO", OracleType.Number)).Value = dto.ESTADO;
                        command.Parameters.Add(new OracleParameter("EMPRESA", OracleType.Number)).Value = dto.EMPRESA;
                        command.Parameters.Add(new OracleParameter("p_RESULT", OracleType.VarChar,200)).Direction = System.Data.ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        result = Convert.ToString(command.Parameters["p_RESULT"].Value);
                        
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

        public List<Usuario2> Read()
        {
            List<Usuario2> list = new List<Usuario2>();
            Usuario2 dto = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("LIST_USUARIO", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_CURSOR", OracleType.Cursor)).Direction =
                        System.Data.ParameterDirection.Output;

                        using (OracleDataReader dr = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                        {
                            while (dr.Read())
                            {
                                dto = new Usuario2();
                                dto.ID_USUARIO = Convert.ToInt32(dr["ID_USUARIO"]);
                                dto.RUT = Convert.ToInt32(dr["RUT"]);
                                dto.DV = Convert.ToChar(dr["DV"]);
                                dto.NOMBRES = Convert.ToString(dr["NOMBRES"]);
                                dto.APELLIDO_PATERNO = Convert.ToString(dr["APELLIDO_PATERNO"]);
                                dto.APELIIDO_MATERNO = Convert.ToString(dr["APELIIDO_MATERNO"]);
                                dto.CORREO = Convert.ToString(dr["CORREO"]);
                                dto.NUMERO = Convert.ToInt32(dr["NUMERO"]);
                                dto.DIRECCION = Convert.ToString(dr["DIRECCION"]);
                                dto.NOMBRE_USUARIO = Convert.ToString(dr["NOMBRE_USUARIO"]);
                                dto.CONTRASENA = Convert.ToString(dr["CONTRASENA"]);
                                dto.ID_PERFIL = Convert.ToInt32(dr["ID_PERFIL"]);
                                dto.ESTADO = Convert.ToInt32(dr["ESTADO"]);
                                dto.EMPRESA = Convert.ToInt32(dr["EMPRESA"]);

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

        public string Update(Usuario2 dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_UPDATE_USUARIO2", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_ID_USUARIO", OracleType.Number)).Value = dto.ID_USUARIO;
                        command.Parameters.Add(new OracleParameter("P_RUT", OracleType.Number)).Value = dto.RUT;
                        command.Parameters.Add(new OracleParameter("P_DV", OracleType.VarChar)).Value = dto.DV;
                        command.Parameters.Add(new OracleParameter("P_NOMBRES", OracleType.VarChar)).Value = dto.NOMBRES;
                        command.Parameters.Add(new OracleParameter("P_APATERNO", OracleType.VarChar)).Value = dto.APELLIDO_PATERNO;
                        command.Parameters.Add(new OracleParameter("P_AMATERNO", OracleType.VarChar)).Value = dto.APELIIDO_MATERNO;
                        command.Parameters.Add(new OracleParameter("P_CORREO", OracleType.VarChar)).Value = dto.CORREO;
                        command.Parameters.Add(new OracleParameter("P_NUMERO", OracleType.Number)).Value = dto.NUMERO;
                        command.Parameters.Add(new OracleParameter("P_DIRECCION", OracleType.VarChar)).Value = dto.DIRECCION;
                        command.Parameters.Add(new OracleParameter("P_USUARIO", OracleType.VarChar)).Value = dto.NOMBRE_USUARIO;
                        command.Parameters.Add(new OracleParameter("P_CONTRASENA", OracleType.VarChar)).Value = dto.CONTRASENA;
                        command.Parameters.Add(new OracleParameter("P_ID_PERFIL", OracleType.Number)).Value = dto.ID_PERFIL;
                        command.Parameters.Add(new OracleParameter("P_ESTADO", OracleType.Number)).Value = dto.ESTADO;
                        command.Parameters.Add(new OracleParameter("P_EMPRESA", OracleType.Number)).Value = dto.EMPRESA;
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
