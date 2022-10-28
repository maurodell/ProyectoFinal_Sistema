using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BEFamillia : BEComponente
    {
        //representa la multiplicidad de 1 a muchos
        private IList<BEComponente> _hijos;
        public BEFamillia()
        {
            _hijos = new List<BEComponente>();
            _tipo = 1;
        }

        public override void AgregarHijo(BEComponente componente)
        {
            _hijos.Add(componente);
        }

        public override IList<BEComponente> ObjenerHijos
        {
            get { return _hijos.ToArray(); }
        }

        public override void VaciarHijos()
        {
            _hijos = new List<BEComponente>();
        }
    }
}
