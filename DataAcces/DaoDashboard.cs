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
    public class DaoDashboard : OracleConexion
    {

        public List<Dashboard_Gen> DashBoard(int rut, string rut_empresa)
        {
            List<Dashboard_Gen> list = new List<Dashboard_Gen>();
            Dashboard_Gen uni;
            try
            {
                using (OracleConnection cn = new OracleConnection(strOracle))
                {
                    cn.Open();
                    using (OracleCommand cmd = new OracleCommand("SP_DASHBOARD_GENERICO", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.Add(new OracleParameter("P_RUT", OracleType.Number)).Value = rut;
                        cmd.Parameters.Add(new OracleParameter("P_EMPRESA", OracleType.Number)).Value = rut_empresa;
                        //cmd.Parameters.Add(new OracleParameter("P_RUT", OracleType.Cursor)).Direction = System.Data.ParameterDirection.Input;
                        cmd.Parameters.Add(new OracleParameter("P_CURSOR", OracleType.Cursor)).Direction = System.Data.ParameterDirection.Output;
                        using (OracleDataReader dr = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                        {
                            while (dr.Read())
                            {
                                uni = new Dashboard_Gen();
                                uni.NOMBRE_UNIDAD = Convert.ToString(dr["NOMBRE_UNIDAD"]);
                                uni.FECHACREACION = Convert.ToDateTime(dr["FECHACREACION"]);
                                uni.FECHA_ESTIMADA = Convert.ToString(dr["FECHA_ESTIMADA"]);
                                uni.FECHA_TERMINO = Convert.ToString(dr["FECHA_TERMINO"]);
                                uni.Tareas_ter = Convert.ToInt32(dr["Cant_tareas_Ter"]);
                                uni.Cant_tareas_tot = Convert.ToInt32(dr["Cant_tareas_tot"]);
                                uni.procentaje = Convert.ToInt32(dr["Porcentaje"]);
                                uni.ESTADO = Convert.ToString(dr["ESTADO"]);
                                uni.ATRASO = Convert.ToInt32(dr["Atraso"]);
                                uni.nombre_usurio = Convert.ToString(dr["nombre_usuario"]);

                                list.Add(uni);
                            }
                        }

                    }
                }

            }
                catch (Exception ex)
            {

                new Exception("Error en metodo dashboard " + ex.Message);
            }
            return list;
        }

    }
}
