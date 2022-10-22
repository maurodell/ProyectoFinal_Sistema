using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;
using BE;
using System.Xml.Linq;
using System.Xml;
using System.Data;
using System.IO;
using System.Reflection;

namespace MPP
{
    public class MPPBackUp
    {
        private string pathBack = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\listadoBackUp" + "\\ListadoBackUp.XML";
        public List<BEBackup> Listar()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(pathBack);

                List<BEBackup> listaBack = new List<BEBackup>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                            BEBackup backup = new BEBackup
                            {
                                Codigo = Convert.ToInt32(item["codigo"]),
                                nombreUsuario = Convert.ToString(item["nombreusuario"]),
                                direccion = Convert.ToString(item["direccion"]),
                                codigoUsuario = Convert.ToInt32(item["codigousuario"]),
                                fecha = Convert.ToDateTime(item["fecha"])
                            };
                        listaBack.Add(backup);
                    }
                }
                return listaBack;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }
    }
}
