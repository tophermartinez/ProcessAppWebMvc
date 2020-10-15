using DataAcces.Cliente;
using DataAcces.Conexion;
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
    public class DaoCliente : OracleConexion, ICrud<Funcionario>
    {
        public string Delete(string dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand cmd = new OracleCommand("ELIMINAR_FUNCIONARIO", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("RUT", OracleType.Number)).Value = dto;
                        cmd.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar)).Direction =
                            System.Data.ParameterDirection.Output;

                        cmd.ExecuteNonQuery();
                        result = Convert.ToString(cmd.Parameters["P_RESULT"].Value);
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

        public string Insert(Funcionario dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand cmd = new OracleCommand("CREATE_FUNCIONARIO", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("RUT", OracleType.Number)).Value = dto.RUT;
                        cmd.Parameters.Add(new OracleParameter("DIGITOV", OracleType.VarChar)).Value = dto.DIGITOV;
                        cmd.Parameters.Add(new OracleParameter("NOMBRE", OracleType.VarChar)).Value = dto.NOMBRE;
                        cmd.Parameters.Add(new OracleParameter("NOMBRE2", OracleType.VarChar)).Value = dto.NOMBRE2;
                        cmd.Parameters.Add(new OracleParameter("APELLIDO", OracleType.VarChar)).Value = dto.APELLIDO;
                        cmd.Parameters.Add(new OracleParameter("APELLIDO2", OracleType.VarChar)).Value = dto.APELLIDO2;
                        cmd.Parameters.Add(new OracleParameter("TELEFONO", OracleType.Number)).Value = dto.TELEFONO;
                        cmd.Parameters.Add(new OracleParameter("EMAIL", OracleType.VarChar)).Value = dto.EMAIL;
                        cmd.Parameters.Add(new OracleParameter("ID_ROL", OracleType.Number)).Value = dto.ID_ROL;
                        cmd.Parameters.Add(new OracleParameter("ID_UNIDAD", OracleType.Number)).Value = dto.ID_UNIDAD;
                        cmd.Parameters.Add(new OracleParameter("ID_USUARIO", OracleType.Number)).Value = dto.ID_USUARIO;
                        cmd.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar)).Direction =
                            System.Data.ParameterDirection.Output;
                        
                        cmd.ExecuteNonQuery();
                        result = Convert.ToString(cmd.Parameters["P_RESULT"].Value);
                    }
                    cn.Close();
                }

            }
            catch (Exception ex)
            {

                new Exception("Error en metodo insertar " + ex.Message);
            }
            return result;
        }

        public List<Funcionario> Read()
        {
            List<Funcionario> list = new List<Funcionario>();
            Funcionario fun = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand cmd = new OracleCommand("SP_SELECT_CLIENTE", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleType.Cursor)).Direction = System.Data.ParameterDirection.Output;
                        using (OracleDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                        {
                            //   cmd.Parameters.Add(new OracleParameter
                            //   ("RUT", OracleType.Int32)).Direction = ParameterDirection.InputOutput;
                            //   cmd.Parameters.Add(new OracleParameter
                            //  ("DIGITOV", OracleType.Char, 2)).Direction = ParameterDirection.Output;
                            //   cmd.Parameters.Add(new OracleParameter
                            //  ("NOMBRE", OracleType.VarChar,50)).Direction = ParameterDirection.Output;
                            //   cmd.Parameters.Add(new OracleParameter
                            //  ("NOMBRE2", OracleType.VarChar, 50)).Direction = ParameterDirection.Output;
                            //   cmd.Parameters.Add(new OracleParameter
                            //  ("APELLIDO", OracleType.VarChar, 50)).Direction = ParameterDirection.Output;
                            //   cmd.Parameters.Add(new OracleParameter
                            //  ("APELLIDO2", OracleType.VarChar, 50)).Direction = ParameterDirection.Output;
                            //   cmd.Parameters.Add(new OracleParameter
                            //  ("TELEFONO", OracleType.Int32)).Direction = ParameterDirection.Output;
                            //   cmd.Parameters.Add(new OracleParameter
                            // ("EMAIL", OracleType.VarChar, 50)).Direction = ParameterDirection.Output;
                            //   cmd.Parameters.Add(new OracleParameter
                            //("ID_USUARIO", OracleType.Int32)).Direction = ParameterDirection.Output;
                            //   cmd.Parameters.Add(new OracleParameter
                            //("ID_ROL", OracleType.Int32)).Direction = ParameterDirection.Output;
                            //   cmd.Parameters.Add(new OracleParameter
                            //("ID_UNIDAD", OracleType.Int32)).Direction = ParameterDirection.Output;

                        //    using (OracleDataReader dr = cmd.ExecuteReader(
                        //    System.Data.CommandBehavior.CloseConnection))
                        //{
                            while (dr.Read())
                            {
                                fun = new Funcionario();
                                fun.RUT = Convert.ToInt32(dr["RUT"]);
                                fun.DIGITOV = Convert.ToChar(dr["DIGITOV"]);
                                fun.NOMBRE = Convert.ToString(dr["PNOMBRE"]);
                                fun.NOMBRE2 = Convert.ToString(dr["SNOMBRE"]);
                                fun.APELLIDO = Convert.ToString(dr["APATERNO"]);
                                fun.APELLIDO2 = Convert.ToString(dr["AMATERNO"]);
                                fun.TELEFONO = Convert.ToInt32(dr["TELEFONO"]);
                                fun.EMAIL = Convert.ToString(dr["EMAIL"]);
                                fun.ID_ROL = Convert.ToString(dr["USUARIO_IDUSUARIO"]);
                                fun.ID_UNIDAD = Convert.ToString(dr["ROL_IDROL"]);
                                fun.ID_USUARIO = Convert.ToString(dr["UNIDAD_IDUNIDAD"]);

                                list.Add(fun);
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {

                new Exception("Error en metodo listar " + ex.Message) ;
            }
            return list;
        }

        public string Update(Funcionario dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand cmd = new OracleCommand("UPDATE_FUNCIONARIO", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("RUT", OracleType.Number)).Value = dto.RUT;
                        cmd.Parameters.Add(new OracleParameter("DIGITOV", OracleType.VarChar)).Value = dto.DIGITOV;
                        cmd.Parameters.Add(new OracleParameter("NOMBRE", OracleType.VarChar)).Value = dto.NOMBRE;
                        cmd.Parameters.Add(new OracleParameter("NOMBRE2", OracleType.VarChar)).Value = dto.NOMBRE2;
                        cmd.Parameters.Add(new OracleParameter("APELLIDO", OracleType.VarChar)).Value = dto.APELLIDO;
                        cmd.Parameters.Add(new OracleParameter("APELLIDO2", OracleType.VarChar)).Value = dto.APELLIDO2;
                        cmd.Parameters.Add(new OracleParameter("TELEFONO", OracleType.Number)).Value = dto.TELEFONO;
                        cmd.Parameters.Add(new OracleParameter("EMAIL", OracleType.VarChar)).Value = dto.EMAIL;
                        cmd.Parameters.Add(new OracleParameter("ID_ROL", OracleType.Number)).Value = dto.ID_ROL;
                        cmd.Parameters.Add(new OracleParameter("ID_UNIDAD", OracleType.Number)).Value = dto.ID_UNIDAD;
                        cmd.Parameters.Add(new OracleParameter("ID_USUARIO", OracleType.Number)).Value = dto.ID_USUARIO;
                        cmd.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar)).Direction =
                            System.Data.ParameterDirection.Output;

                        cmd.ExecuteNonQuery();
                        result = Convert.ToString(cmd.Parameters["P_RESULT"].Value);
                    }
                    cn.Close();
                }

            }
            catch (Exception ex)
            {

                new Exception("Error en metodo actualizar " + ex.Message);
            }
            return result;
        }


        public string Login(Funcionario dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand cmd = new OracleCommand("SP_LOGIN", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("NOMBRE", OracleType.VarChar)).Value = dto.NOMBRE;
                        cmd.Parameters.Add(new OracleParameter("RUT", OracleType.Number)).Value = dto.RUT;
                        cmd.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar)).Direction =
                           System.Data.ParameterDirection.Output;

                        cmd.ExecuteNonQuery();
                        result = Convert.ToString(cmd.Parameters["P_RESULT"].Value);
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
