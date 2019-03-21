using System;
using System.Xml.Schema;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace OneScript.XMLSchema
{
    [ContextClass("ПереопределениеXS", "XSRedefine")]
    public class XSRedefine : AutoContext<XSRedefine>, IXSComponent, IXSDirective, IXSListOwner
    {

        private readonly XmlSchemaRedefine _redefine;
        private IXSComponent _container;
        private IXSComponent _rootContainer;

        private XSRedefine()
        {
            _redefine = new XmlSchemaRedefine();
            Content = new XSComponentList(this);
        }

        #region OneScript

        #region Properties

        [ContextProperty("Аннотация", "Annotation")]
        public XSAnnotation Annotation { get; }

        [ContextProperty("Компоненты", "Components")]
        public XSComponentFixedList Components { get; }

        [ContextProperty("Контейнер", "Container")]
        public IValue Container => (IValue)_container;

        [ContextProperty("КорневойКонтейнер", "RootContainer")]
        public IValue RootContainer => (IValue)_rootContainer;

        [ContextProperty("Схема", "Schema")]
        public XMLSchema Schema => _rootContainer.Schema;

        [ContextProperty("ТипКомпоненты", "ComponentType")]
        public XSComponentType ComponentType => XSComponentType.Redefine;

        [ContextProperty("РазрешеннаяСхема", "ResolvedSchema")]
        public XMLSchema ResolvedSchema
        {
            get => ResolvedSchema;
            set => ResolvedSchema = value;
        }

        [ContextProperty("РасположениеСхемы", "SchemaLocation")]
        public string SchemaLocation
        {
            get => _redefine.SchemaLocation;
            set => _redefine.SchemaLocation = value;
        }

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
        public bool Contains(IValue component) => (component == this);

        #endregion

        #region Constructors

        [ScriptConstructor(Name = "По умолчанию")]
        public static XSRedefine Constructor() => new XSRedefine();

        #endregion

        #endregion

        #region IXComponent

        public void BindToContainer(IXSComponent rootContainer, IXSComponent container)
        {
            _rootContainer = rootContainer;
            _container     = container;
        }
        #endregion

        #region IXSDirective

        public XmlSchemaObject XmlSchemaObject => _redefine;

        #endregion

        #region IXSListOwner

        public void OnListInsert(XSComponentList List, IXSComponent component)
        {
            component.BindToContainer(this, this);
            _redefine.Items.Add(component.XmlSchemaObject);
            Components.Add(component);
        }

        public void OnListDelete(XSComponentList List, IXSComponent component) { }

        #endregion

    }
}
