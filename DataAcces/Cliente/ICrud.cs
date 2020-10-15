using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Cliente
{
   public interface ICrud<T>
    {
        string Insert(T dto);
        string Update(T dto);
        string Delete(String dto);
        List<T> Read();

        string Login(T dto);
    }
}
