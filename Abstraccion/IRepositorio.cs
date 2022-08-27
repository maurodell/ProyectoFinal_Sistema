using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{
    public interface IRepositorio<T> where T : IEntidad
    {
        bool Crear(T Parametro);
        bool Baja(int Parametro);
        bool Alta(int Parametro);
        bool Modificar(T Parametro);
        bool Eliminar(int Parametro);
        List<T> Listar();
        List<T> Buscar(T Parametro);
    }
}
