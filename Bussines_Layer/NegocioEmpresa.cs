using DataAcces;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines_Layer
{
    public class NegocioEmpresa
    {
        public string Delete(string dto) {
            DaoEmpresa emp = new DaoEmpresa();
            return emp.Delete(dto);
        }
        public string Insert(EMPRESA dto) {
            DaoEmpresa emp = new DaoEmpresa();
            return emp.Insert(dto);
        }
        public string Update(EMPRESA dto) {
            DaoEmpresa emp = new DaoEmpresa();
            return emp.Update(dto);
        }
        public List<EMPRESA> Read() {
            DaoEmpresa emp = new DaoEmpresa();
            return emp.Read();
        }
    }
}
