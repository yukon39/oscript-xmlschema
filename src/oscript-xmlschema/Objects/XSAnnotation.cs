using System;
using System.Xml.Schema;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace OneScript.XMLSchema
{
    [ContextClass("АннотацияXS", "XSAnnotation")]
    public class XSAnnotation : AutoContext<XSAnnotation>, IXSComponent, IXSListOwner
    {

        internal readonly XmlSchemaAnnotation InternalObject;
        private IXSComponent _container;
        private IXSComponent _rootContainer;

        public XSAnnotation()
        {
            InternalObject = new XmlSchemaAnnotation();
            Content = new XSComponentList(this);
            Components = new XSComponentFixedList();
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
        public XSComponentType ComponentType => XSComponentType.Annotation;
        
        [ContextProperty("Состав", "Content")]
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
            if (component is IXSAnnotation)
            {
                return true;
            }
            else if (component is IXSComponent)
                return false;
            else
                throw RuntimeException.InvalidArgumentType();
        }

        #region Constructors

        [ScriptConstructor(Name = "По умолчанию")]
        public static XSAnnotation Constructor() => new XSAnnotation();

        #endregion

        #endregion

        #endregion

        #region IXSComponent

        public XmlSchemaObject XmlSchemaObject => InternalObject;

        public void BindToContainer(IXSComponent rootContainer, IXSComponent container)
        {
            _rootContainer = rootContainer;
            _container     = container;
        }

        #endregion

        #region IXSListOwner

        public void OnListInsert(XSComponentList List, IXSComponent component)
        {
            component.BindToContainer(_rootContainer, this);
            InternalObject.Items.Add(component.XmlSchemaObject);
            Components.Add(component);
        }

        public void OnListDelete(XSComponentList List, IXSComponent component) { }

        #endregion
                
    }
}
