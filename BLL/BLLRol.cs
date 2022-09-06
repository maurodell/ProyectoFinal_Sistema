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
    public class BLLRol : IRepositorio<BERol>
    {
        public BLLRol()
        {
            mppRol = new MPPRol();
        }
        MPPRol mppRol;
        BERol BERol;
        public bool Alta(int Parametro)
        {
            return mppRol.Alta(Parametro);
        }

        public bool Baja(int Parametro)
        {
            return mppRol.Baja(Parametro);
        }

        public List<BERol> Buscar(string Parametro)
        {
            return mppRol.Buscar(Parametro);
        }

        public bool Crear(BERol Parametro)
        {
            throw new NotImplementedException();
        }
        public bool Crear(string nombre, string descripcion)
        {
            BERol = new BERol();
            BERol.nombre = nombre;
            BERol.descripcion = descripcion;

            return mppRol.Crear(BERol);
        }
        public bool Eliminar(int Parametro)
        {
            return mppRol.Eliminar(Parametro);
        }

        public List<BERol> Listar()
        {
            return mppRol.Listar();
        }

        public List<BERol> ListarTodos()
        {
            return mppRol.ListarTodos();
        }

        public bool Modificar(BERol Parametro, string parametro2)
        {
            throw new NotImplementedException();
        }
        public bool Modificar(int codigo, string nombreAnterior, string nombre, string descripcion)
        {
            BERol = new BERol();
            BERol.Codigo = codigo;
            BERol.nombre = nombre;
            BERol.descripcion = descripcion;
            return mppRol.Modificar(BERol, nombreAnterior);
        }
    }
}
