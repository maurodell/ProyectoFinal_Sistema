using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class BEComponente
    {
        public int _codigo { get; set; }
        public string _nombre { get; set; }
        public abstract void AgregarHijo(BEComponente componente);
        public abstract IList<BEComponente> ObjenerHijos { get; }
        public abstract void VaciarHijos();

        public override string ToString()
        {
            return _nombre;
        }
    }
}
