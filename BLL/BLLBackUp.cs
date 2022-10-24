using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;

namespace BLL
{
    public class BLLBackUp
    {
        public BLLBackUp()
        {
            mppBackUp = new MPPBackUp();
        }
        MPPBackUp mppBackUp;
        BEBackup backup;
        public List<BEBackup> Listar()
        {
            return mppBackUp.Listar();
        }
        public bool Crear(int codigoUsuario, string nombreUsuario)
        {
            DateTime hoy = DateTime.Today;

            backup = new BEBackup();
            backup.fecha = hoy;
            backup.codigoUsuario = codigoUsuario;
            backup.nombreUsuario = nombreUsuario;
            return mppBackUp.Crear(backup);
        }
        public bool Restore(int codigoBack)
        {
            return mppBackUp.Restore(codigoBack);
        }
    }
}
