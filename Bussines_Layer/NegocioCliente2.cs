using DataAcces;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines_Layer
{
    public class NegocioCliente2
    {
        public string Update(Usuario2 dto)
        {
            DaoCliente2 dao = new DaoCliente2();
            return dao.Update(dto);

        }

        public string Delete(string dto)
        {
            DaoCliente2 dao = new DaoCliente2();
            return dao.Delete(dto);
        }


        public string Insert(Usuario2 dto)
        {
            DaoCliente2 dao = new DaoCliente2();
            return dao.Insert(dto);
        }

        public List<Usuario2> Read()
        {
            DaoCliente2 dao = new DaoCliente2();
            return dao.Read();
        }
    }
}
