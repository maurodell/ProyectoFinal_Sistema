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
    public class BLLCategoria : IRepositorio<BECategoria>
    {
        public BLLCategoria()
        {
            mppCategoria = new MPPCategoria();
        }
        MPPCategoria mppCategoria;
        BECategoria BEcategoria;
        public bool Alta(int Parametro)
        {
            return mppCategoria.Alta(Parametro);
        }

        public bool Baja(int Parametro)
        {
            return mppCategoria.Baja(Parametro);
        }

        public bool Crear(BECategoria Parametro)
        {
            throw new NotImplementedException();
        }
        public bool Insertar(string nombre, string descripcion)
        {
            BEcategoria = new BECategoria();
            BEcategoria.nombre = nombre;
            BEcategoria.descripcion = descripcion;

            return mppCategoria.Crear(BEcategoria);
        }

        public List<BECategoria> Listar()
        {
            return mppCategoria.Listar();
        }
        public List<BECategoria> ListarTodos()
        {
            return mppCategoria.ListarTodos();
        }
        public List<BECategoria> Buscar(String Parametro)
        {
            return mppCategoria.Buscar(Parametro);
        }

        public bool Modificar(int codigo, string nombreAnterior, string nombre, string descripcion)
        {
            BEcategoria = new BECategoria();
            BEcategoria.Codigo = codigo;
            BEcategoria.nombre = nombre;
            BEcategoria.descripcion = descripcion;
            return mppCategoria.Modificar(BEcategoria, nombreAnterior);
        }

        public bool Eliminar(int Parametro)
        {
            return mppCategoria.Eliminar(Parametro);
        }

        public bool Modificar(BECategoria Parametro, string parametro2)
        {
            throw new NotImplementedException();
        }
    }
}
