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
    public class DaoCliente : OracleConexion, ICrud<USUARIO>
    {

        public int Delete(int dto)
        {
            string result = string.Empty;
            int rt = 0;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand cmd = new OracleCommand("DELETE_USUARIO", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("p_id", OracleType.Number)).Value = dto;
                        // cmd.Parameters.Add(new OracleParameter("RUT", OracleType.Number)).Value = dto ;
                        //  cmd.Parameters.Add(new OracleParameter("RUT", OracleType.Number)).Value = dto.DV;
                        //  cmd.Parameters.Add(new OracleParameter("RUT", OracleType.Number)).Value = dto.;
                        cmd.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar, 200)).Direction =
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

            return 1;
            //throw new NotImplementedException();
        }

        public string Insert(USUARIO dto)
        {
            string result = string.Empty;
            try
            {
                int rutValue = 0;
               
                Boolean validate = RUT_UTILS.ValidaRut(dto.RUT);
                if (validate)
                {
                    int rut = RUT_UTILS.ObtenerNumeroRutSinDv(dto.RUT);
                    String rutDv = RUT_UTILS.Digito(rut);
                    using (OracleConnection cn = new OracleConnection(strOracle))
                    {
                        cn.Open();
                        using (OracleCommand cmd = new OracleCommand("INSERT_USUARIO", cn))
                        {
                            cmd.CommandType = System.Data.CommandType.StoredProcedure;
                            cmd.Parameters.Add(new OracleParameter("RUT", OracleType.Number)).Value = rut;
                            cmd.Parameters.Add(new OracleParameter("DV", OracleType.VarChar)).Value = rutDv;
                            cmd.Parameters.Add(new OracleParameter("NOMBRES", OracleType.VarChar)).Value = dto.NOMBRES;
                            cmd.Parameters.Add(new OracleParameter("APATERNO", OracleType.VarChar)).Value = dto.APELLIDO_PATERNO;
                            cmd.Parameters.Add(new OracleParameter("AMATERNO", OracleType.VarChar)).Value = dto.APELIIDO_MATERNO;
                            cmd.Parameters.Add(new OracleParameter("CORREO", OracleType.VarChar)).Value = dto.CORREO;
                            cmd.Parameters.Add(new OracleParameter("NUMERO", OracleType.Number)).Value = dto.NUMERO;
                            cmd.Parameters.Add(new OracleParameter("DIRECCION", OracleType.VarChar)).Value = dto.DIRECCION;
                            cmd.Parameters.Add(new OracleParameter("USUARIO", OracleType.VarChar)).Value = dto.NOMBRE_USUARIO;
                            cmd.Parameters.Add(new OracleParameter("CONTRASENA", OracleType.VarChar)).Value = dto.CONTRASENA;
                            cmd.Parameters.Add(new OracleParameter("ID_PERFIL", OracleType.Number)).Value = dto.ID_PERFIL;
                            cmd.Parameters.Add(new OracleParameter("ESTADO", OracleType.Number)).Value = dto.ESTADO;
                            cmd.Parameters.Add(new OracleParameter("EMPRESA", OracleType.Number)).Value = dto.EMPRESA;
                            cmd.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar, 500)).Direction = System.Data.ParameterDirection.Output;
                            cmd.ExecuteNonQuery();
                            result = Convert.ToString(cmd.Parameters["P_RESULT"].Value);
                        }
                        cn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                
                new Exception("Error en metodo insertar " + ex.Message);
            }
            return result;
        }

        public List<USUARIO> Read()
        {
            List<USUARIO> list = new List<USUARIO>();
            USUARIO usu = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {

                    
                    cn.Open();
                    using (OracleCommand cmd = new OracleCommand("LIST_USUARIO", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleType.Cursor)).Direction = System.Data.ParameterDirection.Output;
                        using (OracleDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                        {
                         
                            while (dr.Read())
                            {
                                usu = new USUARIO();
                                usu.ID = Convert.ToInt32(dr["ID_USUARIO"]);
                                usu.RUT = Convert.ToString(dr["RUT"]);
                                usu.DV = Convert.ToChar(dr["DV"]);
                                usu.NOMBRES = Convert.ToString(dr["NOMBRES"]);
                                usu.APELLIDO_PATERNO = Convert.ToString(dr["APELLIDO_PATERNO"]);
                                usu.APELIIDO_MATERNO = Convert.ToString(dr["APELIIDO_MATERNO"]);
                                usu.CORREO = Convert.ToString(dr["CORREO"]);
                                usu.NUMERO = Convert.ToInt32(dr["NUMERO"]);
                                usu.DIRECCION = Convert.ToString(dr["DIRECCION"]);
                                usu.NOMBRE_USUARIO = Convert.ToString(dr["NOMBRE_USUARIO"]);
                                usu.CONTRASENA = Convert.ToString(dr["CONTRASENA"]);
                                usu.ID_PERFIL = Convert.ToInt32(dr["ID_PERFIL"]);
                                usu.ESTADO = Convert.ToInt32(dr["ESTADO"]);
                                usu.EMPRESA = Convert.ToInt32(dr["EMPRESA"]);

                                list.Add(usu);
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

        public string Update(USUARIO dto)
        {
            string result = string.Empty;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand cmd = new OracleCommand("UPDATE_USUARIO", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure; 

                        cmd.Parameters.Add(new OracleParameter("id_usu", OracleType.Number)).Value = dto.ID;
                        cmd.Parameters.Add(new OracleParameter("P_RUT", OracleType.Number)).Value = dto.RUT;
                        cmd.Parameters.Add(new OracleParameter("P_DV", OracleType.VarChar)).Value = dto.DV;
                        cmd.Parameters.Add(new OracleParameter("P_NOMBRES", OracleType.VarChar)).Value = dto.NOMBRES;
                        cmd.Parameters.Add(new OracleParameter("P_APATERNO", OracleType.VarChar)).Value = dto.APELLIDO_PATERNO;
                        cmd.Parameters.Add(new OracleParameter("P_AMATERNO", OracleType.VarChar)).Value = dto.APELIIDO_MATERNO;
                        cmd.Parameters.Add(new OracleParameter("P_CORREO", OracleType.VarChar)).Value = dto.CORREO;
                        cmd.Parameters.Add(new OracleParameter("P_NUMERO", OracleType.Number)).Value = dto.NUMERO;
                        cmd.Parameters.Add(new OracleParameter("P_DIRECCION", OracleType.VarChar)).Value = dto.DIRECCION;
                        cmd.Parameters.Add(new OracleParameter("P_USUARIO", OracleType.VarChar)).Value = dto.NOMBRE_USUARIO;
                        cmd.Parameters.Add(new OracleParameter("P_CONTRASENA", OracleType.VarChar)).Value = dto.CONTRASENA;
                        cmd.Parameters.Add(new OracleParameter("P_ID_PERFIL", OracleType.Number)).Value = dto.ID_PERFIL;
                        cmd.Parameters.Add(new OracleParameter("P_ESTADO", OracleType.Number)).Value = dto.ESTADO;
                        cmd.Parameters.Add(new OracleParameter("P_EMPRESA", OracleType.Number)).Value = dto.EMPRESA;


                        cmd.Parameters.Add(new OracleParameter("P_RESULT", OracleType.VarChar,200)).Direction =
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

 

        public USER_INFO Login(string usu, string pass)  //( USUARIO dto)
        {


            // Boolean result = false;
            USER_INFO result = null;
            int Perfil = 0;
            //string email = "";
            //string NameRol = "";
            //int IdRol = 0;
            //DataTable Dat = new DataTable();
            try
            {
                   
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                  //  OracleCommand cmd = new OracleCommand("SELECT p.id_perfil FROM PERFIL P " +
                 //       "INNER JOIN USUARIO US ON P.ID_PERFIL = US.ID_PERFIL where US.NOMBRE_USUARIO = :usu AND CONTRASENA = :pass", cn);


                  OracleCommand comando = new OracleCommand("SELECT us.*," +
                                                              "emp.rut, " +
                                                              "emp.nombre, " +
                                                              "per.nombre " +
                                                              "FROM USUARIO us " +
                                                              "INNER JOIN empresa emp ON us.empresa = emp.id_empresa " +
                                                              "INNER JOIN perfil per ON per.id_perfil =  us.id_perfil " +
                                                              "WHERE NOMBRE_USUARIO = :usu " +
                                                              "AND CONTRASENA = :pass", cn);

                    comando.Parameters.AddWithValue(":usu", usu);
                    comando.Parameters.AddWithValue(":pass", pass);

                    //cmd.Parameters.AddWithValue(":usu", usu);
                    //cmd.Parameters.AddWithValue(":pass", pass);

                    OracleDataReader lector = comando.ExecuteReader();
                    //OracleDataReader _reader = cmd.ExecuteReader();

                    if (lector.Read() == true)
                    {
                        USER_INFO user = new USER_INFO();
                        //USUARIO usu_sesion = new USUARIO();
                        user.NOMBRE = lector.GetString(3);
                        user.APELLIDO = lector.GetString(4) + " " + lector.GetString(5);
                        user.RUT = lector.GetInt32(1);
                        user.RUT_EMPRESA = lector.GetInt32(14);
                        user.PERFIL = lector.GetInt32(11);
                        user.NOMBRE_EMPRESA = lector.GetString(15);
                        user.NOMBRE_PERFIL = lector.GetString(16);
                        result = user;
                        //usu_sesion.ID = lector.GetInt32(0);
                        //usu_sesion.NOMBRE_USUARIO = lector.GetString(9);
                        //usu_sesion.CONTRASENA = lector.GetString(10);
                       
                        //if (_reader.Read())
                        //{
                        //    //USUARIO usu1 = new USUARIO();
                        //    //usu1.ID_PERFIL = _reader.GetInt32(0);
                        //    Perfil = _reader.GetInt32(0);
                        //    //int id_per = usu1.ID_PERFIL;

                        //   /*
                        //    switch (id_per)
                        //    {
                               
                        //        case  1:
                        //            Perfil = "Administrador";
                        //            break;
                        //        case 2:
                        //            Perfil = "Supervisor";
                        //            break;
                        //        case 3:
                        //            Perfil = "Funcionario";
                        //            break;
                        //    }
                        //   */
                        //}
                     
                      
                        //result = user;

                        //Form1 formulario = new Form1();
                        //conexion.Close();
                        //formulario.Show();

                    }
                    else
                    {
                        result = null;
                        //MessageBox.Show("No se pudo ingresar");
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

        public List<PERFIL> ObtenerListaPerfiles()
        {
            List<PERFIL> list = new List<PERFIL>();
            PERFIL dto = null;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand cmd = new OracleCommand("SELECT ID_PERFIL, NOMBRE FROM PERFIL", cn))
                    {
                        OracleDataReader _reader = cmd.ExecuteReader();
                        while (_reader.Read())
                        {
                            dto = new PERFIL();
                            dto.ID_PERFIL = Convert.ToInt32(_reader["ID_PERFIL"]);
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
