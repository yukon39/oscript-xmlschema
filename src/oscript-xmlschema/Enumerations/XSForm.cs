using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ScriptEngine;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;
using System.Xml.Schema;

namespace OneScript.XMLSchema
{
    [ContextClass("ФормаПредставленияXSСсылка", "XSFormReference")]
    public class XSFormReference : EnumerationValue
    {
        public XSFormReference(EnumerationContext owner) : base(owner)
        {
        }
    }

    // https://docs.microsoft.com/en-us/dotnet/api/system.xml.schema.xmlschemaform

    [SystemEnum("ФормаПредставленияXS", "XSForm")]
    public class XSForm : EnumerationContext
    {

        [EnumValue("Квалифицированная", "Qualified")]
        public XSFormReference Qualified => (XSFormReference)this["Qualified"];

        [EnumValue("Неквалифицированная", "Unqualified")]
        public XSFormReference Unqualified => (XSFormReference)this["Unqualified"];

        //public XSFormReference FromNativeValue(XmlSchemaForm native)
        //{
        //    XSFormReference val;

        //    if (native == XmlSchemaForm.None)
        //    {
        //        val = null;
        //    }
        //    else
        //    {
        //        val = (XSFormReference)this.ValuesInternal.First(x => ((XSFormReference)x).UnderlyingValue == native);
        //    }

        //    return val;
        //}

        public static XSForm CreateInstance() => EnumContextHelper.CreateEnumInstance((t, v) => new XSForm(t, v));

        public XSForm(TypeDescriptor typeRepresentation, TypeDescriptor valuesType) : base(typeRepresentation, valuesType)
        {
        }
    }
}
