using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;
using Abstraccion;

namespace BLL
{
    public class BLLPermiso
    {
        public BLLPermiso()
        {
            mppPermiso = new MPPPermiso();
        }
        MPPPermiso mppPermiso;
        public List<BEPermiso> ListarMenu()
        {
            return mppPermiso.ListarMenu();
        }
        public IList<BEComponente> TraerPermisosTodos(int codigoRol)
        {
            return mppPermiso.TraerPermisosTodos(codigoRol);
        }
        public bool Existe(BEComponente componente, int codigo)
        {
            return mppPermiso.Existe(componente, codigo);
        }
        public bool GuardarFamilia(BEFamillia beFamilia)
        {
            return mppPermiso.GuardarFamilia(beFamilia);
        }
        public bool ExisteMenu(string nombreMenu)
        {
            return mppPermiso.ExisteMenu(nombreMenu);
        }
    }
}
