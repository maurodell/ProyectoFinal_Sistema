using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{
    public interface Repositorio<T> where T : IEntidad
    {
        bool Crear(T Parametro);
        bool Baja(T Parametro);
        bool Alta(T Parametro);
        bool Modificar(T Parametro);
        List<T> Listar(T Parametro);
        T Leer(int Parametro);
    }
}
