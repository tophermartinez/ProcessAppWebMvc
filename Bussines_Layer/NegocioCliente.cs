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

        public int Delete(int dto)
        {
            DaoCliente dao = new DaoCliente();
            return dao.Delete(dto);
        }

        public string Insert(USUARIO dto)
        {
            DaoCliente dao = new DaoCliente();
            return dao.Insert(dto);
        }

        public List<USUARIO> Read()
        {
            DaoCliente dao = new DaoCliente();
            return dao.Read();
        }


        public USER_INFO Login(string usu, string pass)
        {
            DaoCliente dao = new DaoCliente();
            USER_INFO log = dao.Login(usu, pass);
            return log;

        }
    }
}
