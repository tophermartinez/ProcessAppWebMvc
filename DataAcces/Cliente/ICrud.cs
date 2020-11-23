
using System.Collections.Generic;
using Entity_Layer;

namespace DataAcces.Cliente
{
   public interface ICrud<T>
    {
        string Insert(T dto);
        string Update(T dto);
        int Delete(int dto);

        List<T> Read();
        USER_INFO Login(string user, string pass);
    }
}

