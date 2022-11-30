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
        public Array TraerTodosLosPermisos()
        {
            return mppPermiso.TraerTodosLosPermisos();
        }
        public IList<BEPermiso> TraerTodosPermisosConNombre()
        {
            return mppPermiso.TraerTodosPermisosConNombre();
        }
        public IList<BEFamillia> TraerTodosRolesFamilia()
        {
            return mppPermiso.TraerTodosRolesFamilia();
        }
        public bool GuardarComponente(BEComponente componente, bool tipo)
        {
            return mppPermiso.GuardarComponente(componente, tipo);
        }
        public bool BorrarRol(BEComponente componente)
        {
            return mppPermiso.BorrarRol(componente);
        }
        public void CompletarRolDeUsuario(BEUsuario beUsuario)
        {
            mppPermiso.CompletarRolDeUsuario(beUsuario);
        }
        public void CompletarPermisos(BEComponente componente)
        {
            mppPermiso.CompletarPermisos(componente);
        }
        public IList<BEComponente> TraerPermisosTodos2(int codigoRol)
        {
            return mppPermiso.TraerPermisosTodos2(codigoRol);
        }
        public bool Existe(BEComponente componente, int codigo)
        {
            return mppPermiso.Existe(componente, codigo);
        }
        public bool ExistePermisosUsuario(BEUsuario beUsuario, int codigo)
        {
            return mppPermiso.ExistePermisosUsuario(beUsuario, codigo);
        }
        public bool GuardarPermisos(BEUsuario usuario)
        {
            return mppPermiso.GuardarPermisos(usuario);
        }
        public bool GuardarFamilia(BEFamillia beFamilia)
        {
            return mppPermiso.GuardarFamilia(beFamilia);
        }
        public bool ExisteRolEnUsuario2(BEUsuario beUsuario, int codigoRol)
        {
            return mppPermiso.ExisteRolEnUsuario2(beUsuario, codigoRol);
        }
        public bool EliminarPermisosUsuario(int codigoUsuario)
        {
            return mppPermiso.EliminarPermisosUsuario(codigoUsuario);
        }
    }
}
