using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAcces;

namespace Bussines_Layer
{
   public class ConexionEntity
    {
        private static EntitiesPro _ProcessModelo;

        public static EntitiesPro ProcessModelo
        {
            get
            {
                if (ProcessModelo == null)
                {
                    _ProcessModelo = new EntitiesPro();
                }
                return ProcessModelo;

            }
        
        }
        public ConexionEntity()
        {

        }
    }
}
