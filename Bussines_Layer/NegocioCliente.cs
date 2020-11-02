using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces;
using Entity_Layer;

namespace Bussines_Layer
{
    public class NegocioCliente
    {
        public string Update(USUARIO dto)
        {
            DaoCliente dao = new DaoCliente();
            return dao.Update(dto);

        }

        public int delete(int dto)
        {
            DaoCliente dao = new DaoCliente();
            return dao.Delete(dto);
        }

        public string insert(USUARIO dto)
        {
            DaoCliente dao = new DaoCliente();
            return dao.Insert(dto);
        }

        public List<USUARIO> read()
        {
            DaoCliente dao = new DaoCliente();
            return dao.Read();
        }


        public string Login(string usu, string pass)
        {
            DaoCliente dao = new DaoCliente();
            string log = dao.Login(usu, pass);
            return log;

        }
    }
}
