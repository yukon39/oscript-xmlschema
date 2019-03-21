#Использовать ".."

Процедура ПоказатьПримеры()

	Сообщить(ТекущаяДата());
	Сообщить("Привет!");

	ПримерВключениеXS();
	//ExampleXSInclude();

	Сообщить("Пока!");

КонецПроцедуры

// Источник:
// 	https://docs.microsoft.com/en-us/dotnet/api/system.xml.schema.xmlschemainclude
//
// Результат:
// <schema elementFormDefault="qualified" targetNamespace="http://www.w3.org/2001/05/XMLInfoset" xmlns="http://www.w3.org/2001/XMLSchema">
// 	<import namespace="http://www.example.com/IPO" />
// 	<include schemaLocation="example.xsd" />
// </schema>

Процедура ПримерВключениеXS()

	Схема = Новый СхемаXML;
	//Схема.ФормаЭлементовПоУмолчанию = ФормаПредставленияXS.Квалифицированная;
	Схема.ПространствоИмен = "http://www.w3.org/2001/05/XMLInfoset";
	
	// <xs:import namespace="http://www.example.com/IPO" />
	Импорт = Новый ИмпортXS;
	Импорт.ПространствоИмен = "http://www.example.com/IPO";
	Схема.Директивы.Добавить(Импорт);
	
	// <xs:include schemaLocation="example.xsd" />
	Включение = Новый ВключениеXS;
	Включение.РасположениеСхемы = "example.xsd";
	Схема.Директивы.Добавить(Включение);
	
	ТекстXML = Схема.ТекстXML();
	
	Сообщить(ТекстXML);
	
КонецПроцедуры	

Procedure ExampleXSInclude()

	Schema = new XMLSchema;
	//Schema.ElementFormDefault = XSForm.Qualified;
    Schema.TargetNamespace = "http://www.w3.org/2001/05/XMLInfoset";

	// <xs:import namespace="http://www.example.com/IPO" />
	Import = new XSImport;
	Import.Namespace = "http://www.example.com/IPO";
	Schema.Directives.Add(Import);

	// <xs:include schemaLocation="example.xsd" />
	Include = new XSInclude;
	Include.SchemaLocation = "example.xsd";
	Schema.Directives.Add(Include);
	
	XMLText = Schema.XMLText();

	Message(XMLText);

EndProcedure

ПоказатьПримеры();