#Использовать ".."

Процедура ПоказатьПримеры()

	Сообщить(ТекущаяДата());
	Сообщить("Привет!");

	ПримерАннотацияXS();
	//ExampleXSAnnotation();

	Сообщить("Пока!");

КонецПроцедуры

// Источник:
// 	https://docs.microsoft.com/en-us/dotnet/api/system.xml.schema.xmlschemaappinfo
//
// Результат:
// <xs:schema xmlns:xs="http://www.w3.org/2001/XMLSchema">
// 	<xs:element name="State">
// 		<xs:annotation>
// 			<xs:documentation source="State Name"/>
// 			<xs:appinfo source="Application Information"/>
// 		</xs:annotation>
// 	</xs:element>
// </xs:schema>

Процедура ПримерАннотацияXS()

	Схема = Новый СхемаXML;

	// <xs:element name="State">
	Элемент = Новый ОбъявлениеЭлементаXS;
	Схема.Содержимое.Добавить(Элемент);
	Элемент.Имя = "State";
		
	// <xs:annotation>
	АннотацияNorthwestStates = Новый АннотацияXS;
	Элемент.Аннотация = АннотацияNorthwestStates;
		
	// <xs:documentation>State Name</xs:documentation>
	ДокументацияNorthwestStates = Новый ДокументацияXS;
	АннотацияNorthwestStates.Состав.Добавить(ДокументацияNorthwestStates);
	ДокументацияNorthwestStates.Источник = "State Name";
	//ДокументацияNorthwestStates.Markup = TextToNodeArray("State Name");
		
	// <xs:appInfo>Application Information</xs:appInfo>
	ИнформацияДляПриложения = Новый ИнформацияДляПриложенияXS;
	АннотацияNorthwestStates.Состав.Добавить(ИнформацияДляПриложения);
	ИнформацияДляПриложения.Источник = "Application Information";
	// ИнформацияДляПриложения.Markup = TextToNodeArray("Application Information");

	ТекстXML = Схема.ТекстXML();
	
	Сообщить(ТекстXML);

КонецПроцедуры

Procedure ExampleXSAnnotation()

	Schema = New XMLSchema;
	
	// <xs:element name="State">
	Element = New XSElementDeclaration;
	Schema.Content.Add(Element);
	Element.Name = "State";
	
	// <xs:annotation>
	AnnotationNorthwestStates = New XSAnnotation;
	Element.Annotation = AnnotationNorthwestStates;
	
	// <xs:documentation>State Name</xs:documentation>
	DocumentationNorthwestStates = New XSDocumentation;
	AnnotationNorthwestStates.Content.Add(DocumentationNorthwestStates);
	DocumentationNorthwestStates.Source = "State Name";
	//DocumentationNorthwestStates.Markup = TextToNodeArray("State Name");
	
	// <xs:appInfo>Application Information</xs:appInfo>
	AppInfo = New XSAppInfo;
	AnnotationNorthwestStates.Content.Add(AppInfo);
	AppInfo.Source = "Application Information";
	//AppInfo.Markup = TextToNodeArray("Application Information");
	
	XMLText = Schema.XMLText();

	Message(XMLText);

EndProcedure

ПоказатьПримеры();