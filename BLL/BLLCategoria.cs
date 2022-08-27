using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;
using Abstraccion;

namespace BLL
{
    public class BLLCategoria : IRepositorio<Categoria>
    {
        public BLLCategoria()
        {
            mppCategoria = new MPPCategoria();
        }
        MPPCategoria mppCategoria;
        public bool Alta(int Parametro)
        {
            return mppCategoria.Alta(Parametro);
        }

        public bool Baja(int Parametro)
        {
            return mppCategoria.Baja(Parametro);
        }

        public bool Crear(Categoria Parametro)
        {
            return mppCategoria.Crear(Parametro);
        }

        public List<Categoria> Listar()
        {
            return mppCategoria.Listar();
        }

        public List<Categoria> Buscar(Categoria Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Modificar(Categoria Parametro)
        {
            return mppCategoria.Modificar(Parametro);
        }

        public bool Eliminar(int Parametro)
        {
            return mppCategoria.Eliminar(Parametro);
        }
    }
}
