using System;
using System.Xml.Schema;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace OneScript.XMLSchema
{
    [ContextClass("ДокументацияXS", "XSDocumentation")]
    public class XSDocumentation : AutoContext<XSDocumentation>, IXSComponent, IXSAnnotation
    {

        private readonly XmlSchemaDocumentation _documentation;
        private IXSComponent _container;
        private IXSComponent _rootContainer;

        private XSDocumentation() => _documentation = new XmlSchemaDocumentation();

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
        public XSComponentType ComponentType => XSComponentType.Documentation;

        [ContextProperty("Источник", "Source")]
        public string Source
        {
            get => _documentation.Source;
            set => _documentation.Source = value;
        }

        [ContextProperty("Язык", "Language")]
        public string Language
        {
            get => _documentation.Language;
            set => _documentation.Language = value;
        }

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
        public static XSDocumentation Constructor() => new XSDocumentation();

        #endregion

        #endregion

        #region IXComponent

        public XmlSchemaObject XmlSchemaObject => _documentation;

        public void BindToContainer(IXSComponent rootContainer, IXSComponent container)
        {
            _rootContainer = rootContainer;
            _container     = container;
        }

        #endregion

    }
}
