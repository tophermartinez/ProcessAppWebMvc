using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Empresa
{
    public interface ECrud<T>
    {
        string Insert(T dto);
        string Update(T dto);
        string Delete(string dto);
        List<T> Read();
        List<T> ListNameEmp();
    }
}
