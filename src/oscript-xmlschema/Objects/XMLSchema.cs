using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using ScriptEngine;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using ScriptEngine.HostedScript.Library.Xml;

// https://docs.microsoft.com/en-us/dotnet/api/system.xml.schema.xmlschema

namespace OneScript.XMLSchema
{
    [ContextClass("СхемаXML", "XMLSchema")]
    public class XMLSchema : AutoContext<XMLSchema>, IXSComponent, IXSListOwner
    {

        private readonly XmlSchema _schema;

        private XMLSchema()
        {
            _schema = new XmlSchema();
            Directives = new XSComponentList(this);
            Content = new XSComponentList(this);
            Components = new XSComponentFixedList();
        }

        private static string Schema_textxml(XmlSchema xmlSchema)
        {
            if (!xmlSchema.IsCompiled)
            {
                XmlSchemaSet schemaSet = new XmlSchemaSet();
                schemaSet.ValidationEventHandler += new ValidationEventHandler(ValidationCallbackOne);
                schemaSet.Add(xmlSchema);
                schemaSet.Compile();
            }

            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = Encoding.UTF8
            };

            StringWriter strWriter = new StringWriter();

            XmlWriter XmlWriter = XmlWriter.Create(strWriter, settings);

            xmlSchema.Write(XmlWriter);

            XmlWriter.Close();

            return strWriter.ToString();

            //StringWriter strWriter = new StringWriter();
            //xmlSchema.Write(XmlWriter);
            //return StringWriter.ToString();

        }

        private static void ValidationCallbackOne(object sender, ValidationEventArgs args)
        {
            switch (args.Severity)
            {
                case XmlSeverityType.Error:
                    throw new RuntimeException(args.Message);

                case XmlSeverityType.Warning:
                    SystemLogger.Write($"WARNING:{args.Message}");
                    break;

                default:
                    break;
            }
        }

        #region OneScript

        #region Properties

        [ContextProperty("Аннотация", "Annotation")]
        public XSAnnotation Annotation { get; }

        [ContextProperty("Компоненты", "Components")]
        public XSComponentFixedList Components { get; }

        [ContextProperty("Контейнер", "Container")]
        public IValue Container => this;

        [ContextProperty("КорневойКонтейнер", "RootContainer")]
        public IValue RootContainer => this;

        [ContextProperty("Схема", "Schema")]
        public XMLSchema Schema => this;

        [ContextProperty("ТипКомпоненты", "ComponentType")]
        public XSComponentType ComponentType => XSComponentType.Schema;
        
        [ContextProperty("ПространствоИмен", "TargetNamespace")]
        public string TargetNamespace
        {
            get => _schema.TargetNamespace;
            set => _schema.TargetNamespace = value;
        }

        [ContextProperty("URIПространстваИменСхемыДляСхемыXML", "SchemaForSchemaNamespaceURI")]
        public string Namespace => XmlSchema.Namespace;

        [ContextProperty("Директивы", "Directives")]
        public XSComponentList Directives { get; }

        [ContextProperty("Содержимое", "Content")]
        public XSComponentList Content { get; }
  
        #endregion

        #region Methods

        [ContextMethod("КлонироватьКомпоненту", "CloneComponent")]
        public IValue CloneComponent(IValue recursive = null)
        {
            throw new NotImplementedException();
        }

        [ContextMethod("ОбновитьЭлементDOM", "UpdateDOMElement")]
        public void UpdateDOMElement()
        {
            throw new NotImplementedException();
        }

        [ContextMethod("Содержит", "Contains")]
        public bool Contains(IValue component)
        {
            throw new NotImplementedException();
        }

        [ContextMethod("ТекстXML", "XMLText")]
        public string XMLText() => Schema_textxml(_schema);

        #endregion

        #region Constructors

        [ScriptConstructor(Name = "По умолчанию")]
        public static XMLSchema Constructor() => new XMLSchema();

        #endregion

        #endregion

        #region IXSComponent

        public XmlSchemaObject XmlSchemaObject => _schema;

        public void BindToContainer(IXSComponent RootContainer, IXSComponent Container) { }

        #endregion

        #region IXSListOwner

        public void OnListInsert(XSComponentList List, IXSComponent component)
        {
            component.BindToContainer(this, this);
            if (List == Directives)
            {
                _schema.Includes.Add(component.XmlSchemaObject);
            }
            else
            {
                _schema.Items.Add(component.XmlSchemaObject);
            }
        }

        public void OnListDelete(XSComponentList List, IXSComponent component) { }

        #endregion
        
    }
}
