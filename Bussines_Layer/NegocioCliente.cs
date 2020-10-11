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
        public string Update(Funcionario dto)
        {
            DaoCliente dao = new DaoCliente();
            return dao.Update(dto);

        }

        public string delete(string dto)
        {
            DaoCliente dao = new DaoCliente();
            return dao.Delete(dto);
        }

        public string insert(Funcionario dto)
        {
            DaoCliente dao = new DaoCliente();
            return dao.Insert(dto);
        }

        public List<Funcionario> read()
        {
            DaoCliente dao = new DaoCliente();
            return dao.Read();
        }
    }
}
