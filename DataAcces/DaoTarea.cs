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
    public class DaoTarea : OracleConexion, ICrud<TAREA>
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

        public string Insert(TAREA dto)
        {
            throw new NotImplementedException();
        }

        public string Login(string user, string pass)
        {
            throw new NotImplementedException();
        }

        public List<TAREA> Read()
        {
            throw new NotImplementedException();
        }

        public string Update(TAREA dto)
        {
            throw new NotImplementedException();
        }
    }
}
