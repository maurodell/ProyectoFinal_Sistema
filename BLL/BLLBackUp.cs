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
        public List<BEBackup> Listar()
        {
            return mppBackUp.Listar();
        }
    }
}
