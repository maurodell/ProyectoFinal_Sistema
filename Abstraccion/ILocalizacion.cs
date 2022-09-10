using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{
    public interface ILocalizacion
    {
        string domicilio { get; set; }
        string telefono { get; set; }
        string email { get; set; }
    }
}
