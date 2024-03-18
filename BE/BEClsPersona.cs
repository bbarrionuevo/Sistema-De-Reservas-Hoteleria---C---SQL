using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEClsPersona : Entidad
    {

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Nacionalidad { get; set; }
        public string Mail { get; set; }
        public int Telefono { get; set; }
    }
}
