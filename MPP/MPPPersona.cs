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
    public class MPPPersona : IRepositorio<BEPersona>
    {
        private string pathProveedores = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\Proveedores.XML";
        private string pathClientes = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\archivos_xml" + "\\Clientes.XML";

        public bool Alta(int Parametro)
        {
            throw new NotImplementedException();
        }

        public bool Baja(int Parametro)
        {
            throw new NotImplementedException();
        }

        public List<BEPersona> Buscar(string Parametro)
        {
            throw new NotImplementedException();
        }
        public List<BEPersona> BuscarProveedores(string Parametro)
        {
            try
            {
                BEPersona personaBuscar;
                List<BEPersona> listaPersonasDevolver = new List<BEPersona>();

                XDocument documento = XDocument.Load(pathProveedores);

                var consulta = from proveedor in documento.Descendants("proveedor")
                               where proveedor.Element("nombre").Value.Contains(Parametro)
                               select proveedor;

                foreach (XElement EModifcar in consulta)
                {
                    personaBuscar = new BEPersona();
                    personaBuscar.Codigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);
                    personaBuscar.tipoPersona = EModifcar.Element("tipoPersona").Value;
                    personaBuscar.nombre = EModifcar.Element("nombre").Value;
                    personaBuscar.tipoDocumento = EModifcar.Element("tipoDocumento").Value;
                    personaBuscar.documento = EModifcar.Element("documento").Value;
                    personaBuscar.direccion = EModifcar.Element("direccion").Value;
                    personaBuscar.telefono = EModifcar.Element("telefono").Value;
                    personaBuscar.email = EModifcar.Element("email").Value;

                    listaPersonasDevolver.Add(personaBuscar);
                }
                return listaPersonasDevolver;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        public List<BEPersona> BuscarClientes(string Parametro)
        {
            try
            {
                BEPersona personaBuscar;
                List<BEPersona> listaPersonasDevolver = new List<BEPersona>();

                XDocument documento = XDocument.Load(pathClientes);

                var consulta = from cliente in documento.Descendants("cliente")
                               where cliente.Element("nombre").Value.Contains(Parametro)
                               select cliente;

                foreach (XElement EModifcar in consulta)
                {
                    personaBuscar = new BEPersona();
                    personaBuscar.Codigo = Convert.ToInt32(EModifcar.Attribute("codigo").Value);
                    personaBuscar.tipoPersona = EModifcar.Element("tipoPersona").Value;
                    personaBuscar.nombre = EModifcar.Element("nombre").Value;
                    personaBuscar.tipoDocumento = EModifcar.Element("tipoDocumento").Value;
                    personaBuscar.documento = EModifcar.Element("documento").Value;
                    personaBuscar.direccion = EModifcar.Element("direccion").Value;
                    personaBuscar.telefono = EModifcar.Element("telefono").Value;
                    personaBuscar.email = EModifcar.Element("email").Value;

                    listaPersonasDevolver.Add(personaBuscar);
                }
                return listaPersonasDevolver;
            }
            catch (XmlException ex)
            {
                throw ex;
            }
        }
        public bool Crear(BEPersona Parametro)
        {
            try
            {
                List<BEPersona> persona = Listar();
                int cantidadPart = persona.Count();
                string tipo = Parametro.tipoPersona;

                if (tipo.Equals("Proveedor"))
                {
                    XDocument crear = XDocument.Load(pathProveedores);
                    crear.Element("proveedores").Add(new XElement("proveedor",
                                                    new XAttribute("codigo", (cantidadPart + 1)),
                                                    new XElement("tipoPersona", Parametro.tipoPersona),
                                                    new XElement("nombre", Parametro.nombre),
                                                    new XElement("tipoDocumento", Parametro.tipoDocumento),
                                                    new XElement("documento", Parametro.documento),
                                                    new XElement("direccion", Parametro.direccion),
                                                    new XElement("telefono", Parametro.telefono),
                                                    new XElement("email", Parametro.email)));

                    if (VerificarDNI(Parametro.documento))
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
                }else if (tipo.Equals("Cliente"))
                {
                    XDocument crear = XDocument.Load(pathProveedores);
                    crear.Element("clientes").Add(new XElement("cliente",
                                                    new XAttribute("codigo", (cantidadPart + 1)),
                                                    new XElement("tipoPersona", Parametro.tipoPersona),
                                                    new XElement("nombre", Parametro.nombre),
                                                    new XElement("tipoDocumento", Parametro.tipoDocumento),
                                                    new XElement("documento", Parametro.documento),
                                                    new XElement("direccion", Parametro.direccion),
                                                    new XElement("telefono", Parametro.telefono),
                                                    new XElement("email", Parametro.email)));

                    if (VerificarDNI(Parametro.documento))
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
        public bool Eliminar(int Parametro)
        { 
            throw new NotImplementedException(); 
        }

            public bool Eliminar(int Parametro, string tipoPersona)
        {
            try
            {
                XDocument documento;
                if (tipoPersona.Equals("Cliente"))
                {
                    documento = XDocument.Load(pathClientes);
                }
                else
                {
                    documento = XDocument.Load(pathProveedores);
                }

                var consulta = from persona in documento.Descendants("persona")
                               where persona.Attribute("codigo").Value == Parametro.ToString()
                               select persona;
                consulta.Remove();

                if (tipoPersona.Equals("Cliente"))
                {
                    documento.Save(pathClientes);
                    return true;
                }
                else if(tipoPersona.Equals("Proveedor"))
                {
                    documento.Save(pathProveedores);
                    return true;
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

        public List<BEPersona> Listar()
        {
            throw new NotImplementedException();
        }
        public List<BEPersona> ListarProveedores()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(pathProveedores);

                List<BEPersona> personas = new List<BEPersona>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        BEPersona persona = new BEPersona
                        {
                            Codigo = Convert.ToInt32(item["codigo"]),
                            tipoPersona = Convert.ToString(item["tipoPersona"]),
                            nombre = Convert.ToString(item["nombre"]),
                            tipoDocumento = Convert.ToString(item["tipoDocumento"]),
                            documento = Convert.ToString(item["documento"]),
                            direccion = Convert.ToString(item["direccion"]),
                            telefono = Convert.ToString(item["telefono"]),
                            email = Convert.ToString(item["email"])
                        };
                        personas.Add(persona);
                    }
                }
                return personas;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }
        public List<BEPersona> ListarClientes()
        {
            try
            {
                DataSet DS = new DataSet();
                DS.ReadXml(pathClientes);

                List<BEPersona> personas = new List<BEPersona>();

                if (DS.Tables.Count > 0)
                {
                    foreach (DataRow item in DS.Tables[0].Rows)
                    {
                        BEPersona persona = new BEPersona
                        {
                            Codigo = Convert.ToInt32(item["codigo"]),
                            tipoPersona = Convert.ToString(item["tipoPersona"]),
                            nombre = Convert.ToString(item["nombre"]),
                            tipoDocumento = Convert.ToString(item["tipoDocumento"]),
                            documento = Convert.ToString(item["documento"]),
                            direccion = Convert.ToString(item["direccion"]),
                            telefono = Convert.ToString(item["telefono"]),
                            email = Convert.ToString(item["email"])
                        };
                        personas.Add(persona);
                    }
                }
                return personas;
            }
            catch (XmlException)
            {
                throw new XmlException();
            }
        }
        public List<BEPersona> ListarTodos()
        {
            throw new NotImplementedException();
        }
        public bool Modificar(BEPersona Parametro, string emailAnterior)
        {
            throw new NotImplementedException();
        }
            public bool ModificarProveedor(BEPersona Parametro, string emailAnterior)
        {
            try
            {
                XDocument documento = XDocument.Load(pathProveedores);

                var consulta = from proveedor in documento.Descendants("proveedor")
                               where proveedor.Attribute("codigo").Value == Parametro.Codigo.ToString()
                               select proveedor;

                //Busca en el usuario por ID para luego comprobar si hay que cambiar el DNI
                BEPersona personaXML = Listar().Find(x => x.documento == Parametro.documento);

                //Verifica si existe el DNI, si existe retona false, sino existe true.
                if (VerificarDNI(Parametro.documento))
                {
                    if (VerificarExistencia(emailAnterior))
                    {
                        foreach (XElement EModifcar in consulta)
                        {
                            EModifcar.Element("email").Value = Parametro.email;
                            EModifcar.Element("nombre").Value = Parametro.nombre;
                            EModifcar.Element("tipoPersona").Value = Parametro.tipoPersona;
                            EModifcar.Element("tipoDocumento").Value = Parametro.tipoDocumento;
                            EModifcar.Element("documento").Value = Parametro.documento;
                            EModifcar.Element("direccion").Value = Parametro.direccion;
                            EModifcar.Element("telefono").Value = Parametro.telefono;
                        }
                        documento.Save(pathProveedores);
                        return true;
                    }
                    else
                    {
                        foreach (XElement EModifcar in consulta)
                        {
                            EModifcar.Element("nombre").Value = Parametro.nombre;
                            EModifcar.Element("tipoPersona").Value = Parametro.tipoPersona;
                            EModifcar.Element("tipoDocumento").Value = Parametro.tipoDocumento;
                            EModifcar.Element("documento").Value = Parametro.documento;
                            EModifcar.Element("direccion").Value = Parametro.direccion;
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
                            EModifcar.Element("nombre").Value = Parametro.nombre;
                            EModifcar.Element("tipoPersona").Value = Parametro.tipoPersona;
                            EModifcar.Element("direccion").Value = Parametro.direccion;
                            EModifcar.Element("telefono").Value = Parametro.telefono;
                        }
                        documento.Save(pathProveedores);
                        return true;
                    }
                    else
                    {
                        foreach (XElement EModifcar in consulta)
                        {
                            EModifcar.Element("nombre").Value = Parametro.nombre;
                            EModifcar.Element("tipoPersona").Value = Parametro.tipoPersona;
                            EModifcar.Element("direccion").Value = Parametro.direccion;
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
        public bool ModificarCliente(BEPersona Parametro, string emailAnterior)
        {
            try
            {
                XDocument documento = XDocument.Load(pathClientes);

                var consulta = from cliente in documento.Descendants("cliente")
                               where cliente.Attribute("codigo").Value == Parametro.Codigo.ToString()
                               select cliente;

                //Busca en el usuario por ID para luego comprobar si hay que cambiar el DNI
                BEPersona personaXML = Listar().Find(x => x.documento == Parametro.documento);

                //Verifica si existe el DNI, si existe retona false, sino existe true.
                if (VerificarDNI(Parametro.documento))
                {
                    if (VerificarExistencia(emailAnterior))
                    {
                        foreach (XElement EModifcar in consulta)
                        {
                            EModifcar.Element("email").Value = Parametro.email;
                            EModifcar.Element("nombre").Value = Parametro.nombre;
                            EModifcar.Element("tipoPersona").Value = Parametro.tipoPersona;
                            EModifcar.Element("tipoDocumento").Value = Parametro.tipoDocumento;
                            EModifcar.Element("documento").Value = Parametro.documento;
                            EModifcar.Element("direccion").Value = Parametro.direccion;
                            EModifcar.Element("telefono").Value = Parametro.telefono;
                        }
                        documento.Save(pathClientes);
                        return true;
                    }
                    else
                    {
                        foreach (XElement EModifcar in consulta)
                        {
                            EModifcar.Element("nombre").Value = Parametro.nombre;
                            EModifcar.Element("tipoPersona").Value = Parametro.tipoPersona;
                            EModifcar.Element("tipoDocumento").Value = Parametro.tipoDocumento;
                            EModifcar.Element("documento").Value = Parametro.documento;
                            EModifcar.Element("direccion").Value = Parametro.direccion;
                            EModifcar.Element("telefono").Value = Parametro.telefono;
                        }

                        documento.Save(pathClientes);
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
                            EModifcar.Element("nombre").Value = Parametro.nombre;
                            EModifcar.Element("tipoPersona").Value = Parametro.tipoPersona;
                            EModifcar.Element("direccion").Value = Parametro.direccion;
                            EModifcar.Element("telefono").Value = Parametro.telefono;
                        }
                        documento.Save(pathClientes);
                        return true;
                    }
                    else
                    {
                        foreach (XElement EModifcar in consulta)
                        {
                            EModifcar.Element("nombre").Value = Parametro.nombre;
                            EModifcar.Element("tipoPersona").Value = Parametro.tipoPersona;
                            EModifcar.Element("direccion").Value = Parametro.direccion;
                            EModifcar.Element("telefono").Value = Parametro.telefono;
                        }

                        documento.Save(pathClientes);
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
            List<BEPersona> personas = ListarTodos();

            if (personas.Count() > 0)
            {
                foreach (BEPersona item in personas)
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
        bool VerificarDNI(string documento)
        {
            bool resp = true;
            List<BEPersona> personas = ListarTodos();

            if (personas.Count() > 0)
            {
                foreach (BEPersona item in personas)
                {
                    if (item.documento == documento)
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
