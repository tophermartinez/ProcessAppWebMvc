using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces;
using Entity_Layer;



namespace Bussines_Layer
{
    public class NegocioUNIDADDET
    {

        public string Update(UNIDAD_DETALLE dto)
        {
            DaoUNIDADDET dao = new DaoUNIDADDET();
            return dao.Update(dto);

        }

        public string Delete(string dto)
        {
            DaoUNIDADDET dao = new DaoUNIDADDET();
            return dao.Delete(dto);
        }


        public string Insert(UNIDAD_DETALLE dto)
        {
            DaoUNIDADDET dao = new DaoUNIDADDET();
            return dao.Insert(dto);
        }

        public List<UNIDAD_DETALLE> Read()
        {
            DaoUNIDADDET dao = new DaoUNIDADDET();
            return dao.Read();
        }

    }
}
