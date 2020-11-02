using DataAcces;
using Entity_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines_Layer
{
    public class NegocioPerfil
    {
        public string Update(PERFIL dto)
        {
            DaoPerfil dao = new DaoPerfil();
            return dao.Update(dto);

        }

        public string Delete(string dto)
        {
            DaoPerfil dao = new DaoPerfil();
            return dao.Delete(dto);
        }


        public string Insert(PERFIL dto)
        {
            DaoPerfil dao = new DaoPerfil();
            return dao.Insert(dto);
        }

        public List<PERFIL> Read()
        {
            DaoPerfil dao = new DaoPerfil();
            return dao.Read();
        }

    }
}
