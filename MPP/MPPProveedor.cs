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
    public class MPPProveedor : IRepositorio<BEProveedor>
    {
        private string pathProveedores = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\Proveedores.XML";
        public bool Alta(int Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int Parametro)
        {
            throw new NotImplementedException();
        }

        public List<BEProveedor> Buscar(string Parametro)
        {
            try
            {
                BEProveedor proveedorBuscar;
                List<BEProveedor> listaProveedoresDevolver = new List<BEProveedor>();

                XDocument documento = XDocument.Load(pathProveedores);

                var consulta = from proveedor in documento.Descendants("proveedor")
                               where proveedor.Element("nombre").Value.Contains(Parametro)
                               select proveedor;

                foreach (XElement EModifcar in consulta)
                {
                    proveedorBuscar = new BEProveedor();
                    proveedorBuscar.Codigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);
                    proveedorBuscar.condicion = EModifcar.Element("condicion").Value;
                    proveedorBuscar.razonSocial = EModifcar.Element("razonSocial").Value;
                    proveedorBuscar.cuit = Convert.ToInt32(EModifcar.Element("cuit").Value);
                    proveedorBuscar.provincia = EModifcar.Element("provincia").Value;
                    proveedorBuscar.domicilio = EModifcar.Element("domicilio").Value;
                    proveedorBuscar.telefono = EModifcar.Element("telefono").Value;
                    proveedorBuscar.email = EModifcar.Element("email").Value;

                    listaProveedoresDevolver.Add(proveedorBuscar);
                }
                return listaProveedoresDevolver;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }

        public bool Crear(BEProveedor Parametro)
        {
            {
                try
                {
                    List<BEProveedor> persona = Listar();
                    int cantidadPart = persona.Count();

                        XDocument crear = XDocument.Load(pathProveedores);
                        crear.Element("proveedores").Add(new XElement("proveedor",
                                                        new XAttribute("codigo", (cantidadPart + 1)),
                                                        new XElement("condicion", Parametro.condicion),
                                                        new XElement("razonSocial", Parametro.razonSocial),
                                                        new XElement("provincia", Parametro.provincia),
                                                        new XElement("cuit", Parametro.cuit),
                                                        new XElement("domicilio", Parametro.domicilio),
                                                        new XElement("telefono", Parametro.telefono),
                                                        new XElement("email", Parametro.email)));

                    if (VerificarCUIT(Parametro.cuit))
                    {
                        if (VerificarExistencia(Parametro.email))
                        {
                            crear.Save(pathProveedores);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (XmlException ex)
                {
                    throw ex;
                }
            }
        }

        public bool Eliminar(int Parametro)
        {
            try
            {
                XDocument documento = XDocument.Load(pathProveedores);

                var consulta = from proveedor in documento.Descendants("proveedor")
                               where proveedor.Attribute("codigo").Value == Parametro.ToString()
                               select proveedor;
                consulta.Remove();

                documento.Save(pathProveedores);
                return true;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }

        public List<BEProveedor> Listar()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(pathProveedores);

                List<BEProveedor> proveedores = new List<BEProveedor>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        string estado = item["estado"].ToString(); //-->listo los que tengan el estado en true
                        if (estado.Equals("1"))
                        {
                            BEProveedor proveedor = new BEProveedor
                            {
                                Codigo = Convert.ToInt32(item["codigo"]),
                                condicion = Convert.ToString(item["condicion"]),
                                razonSocial = Convert.ToString(item["razonSocial"]),
                                provincia = Convert.ToString(item["provincia"]),
                                cuit = Convert.ToInt32(item["cuit"]),
                                domicilio = Convert.ToString(item["domicilio"]),
                                telefono = Convert.ToString(item["telefono"]),
                                email = Convert.ToString(item["email"])
                            };
                            proveedores.Add(proveedor);
                        }
                    }
                }
                return proveedores;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }

        public List<BEProveedor> ListarTodos()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(pathProveedores);

                List<BEProveedor> proveedores = new List<BEProveedor>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        BEProveedor proveedor = new BEProveedor
                        {
                            Codigo = Convert.ToInt32(item["codigo"]),
                            condicion = Convert.ToString(item["condicion"]),
                            razonSocial = Convert.ToString(item["razonSocial"]),
                            provincia = Convert.ToString(item["provincia"]),
                            cuit = Convert.ToInt32(item["cuit"]),
                            domicilio = Convert.ToString(item["domicilio"]),
                            telefono = Convert.ToString(item["telefono"]),
                            email = Convert.ToString(item["email"])
                        };
                        proveedores.Add(proveedor);
                    }
                }
                return proveedores;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }

        public bool Modificar(BEProveedor Parametro, string emailAnterior)
        {
            try
            {
                XDocument documento = XDocument.Load(pathProveedores);

                var consulta = from proveedor in documento.Descendants("proveedor")
                               where proveedor.Attribute("codigo").Value == Parametro.Codigo.ToString()
                               select proveedor;

                //Busca en el usuario por ID para luego comprobar si hay que cambiar el DNI
                BEProveedor userXML = ListarTodos().Find(x => x.cuit == Parametro.cuit);

                //Verifica si existe el DNI, si existe retona false(va por el else), y luego en ambos casos verifica si existe el email.
                if (VerificarCUIT(Parametro.cuit))
                {
                    if (VerificarExistencia(emailAnterior))
                    {
                        foreach (XElement EModifcar in consulta)
                        {
                            EModifcar.Element("email").Value = Parametro.email;
                            EModifcar.Element("condicion").Value = Parametro.condicion;
                            EModifcar.Element("razonSocial").Value = Parametro.razonSocial;
                            EModifcar.Element("provincia").Value = Parametro.provincia;
                            EModifcar.Element("cuit").Value = Convert.ToString(Parametro.cuit);
                            EModifcar.Element("domicilio").Value = Parametro.domicilio;
                            EModifcar.Element("telefono").Value = Parametro.telefono;
                        }
                        documento.Save(pathProveedores);
                        return true;
                    }
                    else
                    {
                        foreach (XElement EModifcar in consulta)
                        {
                            EModifcar.Element("condicion").Value = Parametro.condicion;
                            EModifcar.Element("razonSocial").Value = Parametro.razonSocial;
                            EModifcar.Element("provincia").Value = Parametro.provincia;
                            EModifcar.Element("cuit").Value = Convert.ToString(Parametro.cuit);
                            EModifcar.Element("domicilio").Value = Parametro.domicilio;
                            EModifcar.Element("telefono").Value = Parametro.telefono;
                        }

                        documento.Save(pathProveedores);
                        return true;
                    }
                }
                else
                {
                    if (VerificarExistencia(emailAnterior))
                    {
                        foreach (XElement EModifcar in consulta)
                        {
                            EModifcar.Element("email").Value = Parametro.email;
                            EModifcar.Element("condicion").Value = Parametro.condicion;
                            EModifcar.Element("razonSocial").Value = Parametro.razonSocial;
                            EModifcar.Element("provincia").Value = Parametro.provincia;
                            EModifcar.Element("domicilio").Value = Parametro.domicilio;
                            EModifcar.Element("telefono").Value = Parametro.telefono;
                        }
                        documento.Save(pathProveedores);
                        return true;
                    }
                    else
                    {
                        foreach (XElement EModifcar in consulta)
                        {
                            EModifcar.Element("condicion").Value = Parametro.condicion;
                            EModifcar.Element("razonSocial").Value = Parametro.razonSocial;
                            EModifcar.Element("provincia").Value = Parametro.provincia;
                            EModifcar.Element("domicilio").Value = Parametro.domicilio;
                            EModifcar.Element("telefono").Value = Parametro.telefono;
                        }

                        documento.Save(pathProveedores);
                        return true;
                    }
                }

            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        bool VerificarExistencia(string email)
        {
            bool resp = true;
            List<BEProveedor> proveedores = ListarTodos();

            if (proveedores.Count() > 0)
            {
                foreach (BEProveedor item in proveedores)
                {
                    if (item.email == email)
                    {
                        resp = false;
                        break;
                    }
                }
            }
            return resp;
        }
        bool VerificarCUIT(int cuit)
        {
            bool resp = true;
            List<BEProveedor> proveedores = ListarTodos();

            if (proveedores.Count() > 0)
            {
                foreach (BEProveedor item in proveedores)
                {
                    if (item.cuit == cuit)
                    {
                        resp = false;
                        break;
                    }
                }
            }
            return resp;
        }
    }
}
