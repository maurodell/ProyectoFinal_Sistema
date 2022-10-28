using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEPermiso : BEComponente
    {
        public BEPermiso()
        {
            _tipo = 0;
        }
        public override IList<BEComponente> ObjenerHijos
        {
            get { return new List<BEComponente>(); }
        }

        public override void AgregarHijo(BEComponente componente) { }

        public override void VaciarHijos() { }
    }
}
