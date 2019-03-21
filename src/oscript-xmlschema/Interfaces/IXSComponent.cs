using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Xml.Schema;

namespace OneScript.XMLSchema
{
    public interface IXSComponent
    {

        #region OneScript

        XSAnnotation         Annotation    { get; }
        XSComponentFixedList Components    { get; }
        IValue               Container     { get; }
        IValue               RootContainer { get; }
        XMLSchema            Schema        { get; }
        XSComponentType      ComponentType { get; }
        //DOMElement

        IValue CloneComponent(IValue recursive = null);
        void UpdateDOMElement();
        bool Contains(IValue component);

        #endregion

        XmlSchemaObject XmlSchemaObject { get; }
        void BindToContainer(IXSComponent RootContainer, IXSComponent Container);

    }
}