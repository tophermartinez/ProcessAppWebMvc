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
        int Delete(int dto);


        

        List<T> Read();
        string Login(string user, string pass);
    }
}

