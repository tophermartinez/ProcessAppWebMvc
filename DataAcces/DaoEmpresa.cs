using DataAcces.Cliente;
using DataAcces.Conexion;
using DataAcces.Empresa;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;

namespace DataAcces
{
    public class DaoEmpresa : OracleConexion, ECrud<EMPRESA>
    {
        public string Delete(string dto)
        {
            string resultado = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_DELETE_EMPRESA", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_IDEMPRESA", OracleType.Number)).Value = dto;
                        //command.Parameters.Add(new OracleParameter("P_RUT", OracleType.Number)).Value = dto;
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar,50)).Direction = System.Data.ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        resultado = Convert.ToString(command.Parameters["P_RESULT"].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception("error al eliminar" + ex.Message);
            }
            return resultado;
        }
        public string Insert(EMPRESA dto)
        {
            string resultado = string.Empty;
            try
            {
                int rutValue = 0;
                RUT_UTILS ru = new RUT_UTILS();
                Boolean validate = ru.ValidaRut(dto.RUT);
                if (validate)
                {
                    rutValue = ru.ObtenerNumeroRutSinDv(dto.RUT);
                    using (OracleConnection cn = new OracleConnection(strOracle))
                    {
                        cn.Open();
                        using (OracleCommand command = new OracleCommand("SP_INSERT_EMPRESA", cn))
                        {
                            command.CommandType = System.Data.CommandType.StoredProcedure;
                            //command.Parameters.Add(new OracleParameter("P_IDEMPRESA", OracleType.Number)).Value = dto.ID;
                            //command.Parameters.Add(new OracleParameter("P_RUT", OracleType.Number)).Value = dto.RUT;
                            command.Parameters.Add(new OracleParameter("P_RUT", OracleType.Number)).Value = rutValue;
                            command.Parameters.Add(new OracleParameter("P_NOMBRE", OracleType.VarChar)).Value = dto.NOMBRE;
                            command.Parameters.Add(new OracleParameter("P_DIRECCION", OracleType.VarChar)).Value = dto.DIRECCION;
                            command.Parameters.Add(new OracleParameter("P_CORREO_CONTACTO", OracleType.VarChar)).Value = dto.CORREO_CONTACTO;
                            command.Parameters.Add(new OracleParameter("P_TELEFONO_CONTACTO", OracleType.Int32)).Value = dto.TELEFONO_CONTACTO;
                            command.Parameters.Add(new OracleParameter("P_ESTADO", OracleType.Number)).Value = dto.ESTADO;
                            command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar, 200)).Direction = System.Data.ParameterDirection.Output;
                            command.ExecuteNonQuery();
                            resultado = Convert.ToString(command.Parameters["P_RESULT"].Value);
                        }
                    }
                }
                
              

            }
            catch (Exception ex)
            {
                new Exception("Error al insertar" + ex.Message);
            }
            return resultado;
        }
        public List<EMPRESA> Read()
        {
            List<EMPRESA> list = new List<EMPRESA>();
            EMPRESA emp = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_SELECT_EMPRESA", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_CURSOR",OracleType.Cursor)).Direction = System.Data.ParameterDirection.Output;
                        using (OracleDataReader dr = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                        {
                            while (dr.Read())
                            {
                                emp = new EMPRESA();
                                emp.ID = Convert.ToInt32(dr["ID_EMPRESA"]);
                                emp.RUT = Convert.ToInt32(dr["RUT"]).ToString();
                                emp.NOMBRE = Convert.ToString(dr["NOMBRE"]);
                                emp.DIRECCION = Convert.ToString(dr["DIRECCION"]);
                                emp.CORREO_CONTACTO = Convert.ToString(dr["CORREO_CONTACTO"]);
                                emp.TELEFONO_CONTACTO = Convert.ToInt64(dr["TELEFONO_CONTACTO"]);
                                emp.ESTADO = Convert.ToInt32(dr["ESTADO"]);
                                emp.NOMBRE_ESTADO = Convert.ToString(dr["NOMBRE_ESTADO"]);
                                list.Add(emp);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception("Error en el metodo listar" + ex.Message);
            }
            return list;
        }

        public string Update(EMPRESA dto)
        {
            string resultado = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand command = new OracleCommand("SP_UPDATE_EMPRESA", cn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.Add(new OracleParameter("P_IDEMPRESA", OracleType.Number)).Value = dto.ID;
                        command.Parameters.Add(new OracleParameter("P_RUT", OracleType.Number)).Value = dto.RUT;
                        command.Parameters.Add(new OracleParameter("P_NOMBRE", OracleType.VarChar)).Value = dto.NOMBRE;
                        command.Parameters.Add(new OracleParameter("P_DIRECCION", OracleType.VarChar)).Value = dto.DIRECCION;
                        command.Parameters.Add(new OracleParameter("P_CORREO_CONTACTO", OracleType.VarChar)).Value = dto.CORREO_CONTACTO;
                        command.Parameters.Add(new OracleParameter("P_TELEFONO_CONTACTO", OracleType.Number)).Value = dto.TELEFONO_CONTACTO;
                        command.Parameters.Add(new OracleParameter("P_ESTADO", OracleType.Number)).Value = dto.ESTADO;
                        command.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar,50)).Direction = System.Data.ParameterDirection.Output;
                        command.ExecuteNonQuery();
                        resultado = Convert.ToString(command.Parameters["P_RESULT"].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                new Exception("error al actualizar" + ex.Message);
            }
            return resultado;
        }

        public List<EMPRESA> ListNameEmp()
        {
            List<EMPRESA> list = new List<EMPRESA>();
            EMPRESA emp = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                   // using (OracleCommand command = new OracleCommand("SP_SELECT_EMPRESA", cn))
                    {
                        OracleCommand cmd = new OracleCommand("SELECT ID_EMPRESA,NOMBRE FROM EMPRESA ", cn);

                        using (OracleDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                        {
                            while (dr.Read())
                            {
                                emp = new EMPRESA();
                                emp.ID = Convert.ToInt32(dr["ID_EMPRESA"]);
                                emp.NOMBRE = Convert.ToString(dr["NOMBRE"]);
                                list.Add(emp);
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                new Exception("Error en el metodo listar" + ex.Message);
            }
            return list;
        }

        public List<estado> ObtenerEstadoUsuario()
        {
            List<estado> list = new List<estado>();
            estado dto = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand cmd = new OracleCommand("SELECT ID_ESTADO, NOMBRE, DESCRIPCION FROM estado where Descripcion = 'Usuario'", cn))
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

        public List<EMPRESA> ObtenerListaEmpresas()
        {
            List<EMPRESA> list = new List<EMPRESA>();
            EMPRESA dto = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand cmd = new OracleCommand("SELECT ID_EMPRESA, NOMBRE FROM EMPRESA", cn))
                    {
                        OracleDataReader _reader = cmd.ExecuteReader();
                        while (_reader.Read())
                        {
                            dto = new EMPRESA();
                            dto.ID = Convert.ToInt32(_reader["ID_EMPRESA"]);
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
    }

}

