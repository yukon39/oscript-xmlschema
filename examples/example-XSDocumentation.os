#Использовать ".."

Процедура ПоказатьПримеры()

	Сообщить(ТекущаяДата());
	Сообщить("Привет!");

	ПримерДокументацияXS();
	//ExampleXSDocumentation();

	Сообщить("Пока!");

КонецПроцедуры	

// Источник:
// 	https://docs.microsoft.com/en-us/dotnet/api/system.xml.schema.xmlschemadocumentation
//
// Результат:
// <xs:schema xmlns:xs="http://www.w3.org/2001/XMLSchema">
// 	<xs:simpleType name="northwestStates">
// 	<xs:annotation>
// 		<xs:documentation>States in the Pacific Northwest of US</xs:documentation>
// 	</xs:annotation>
// 	<xs:restriction base="xs:string">
// 	  <xs:enumeration value="WA">
// 		<xs:annotation>
// 		  <xs:documentation>Washington</xs:documentation>
// 		</xs:annotation>
// 	  </xs:enumeration>
// 	  <xs:enumeration value="OR">
// 		<xs:annotation>
// 		  <xs:documentation>Oregon</xs:documentation>
// 		</xs:annotation>
// 	  </xs:enumeration>
// 	  <xs:enumeration value="ID">
// 		<xs:annotation>
// 		  <xs:documentation>Idaho</xs:documentation>
// 		</xs:annotation>
// 	  </xs:enumeration>
// 	</xs:restriction>
// </xs:simpleType>
// </xs:schema>

Процедура ПримерДокументацияXS()

	Схема = Новый СхемаXML;

	// <xs:simpleType name="northwestStates">
	ПростойТип = Новый ОпределениеПростогоТипаXS;
	ПростойТип.Имя = "northwestStates";
	Схема.Содержимое.Добавить(ПростойТип);
	
	// <xs:annotation>
	АннотацияNorthwestStates = Новый АннотацияXS;
	ПростойТип.Аннотация = АннотацияNorthwestStates;

	// <xs:documentation>States in the Pacific Northwest of US</xs:documentation>
	ДокументацияNorthwestStates = Новый ДокументацияXS;
	АннотацияNorthwestStates.Состав.Добавить(ДокументацияNorthwestStates);
	ДокументацияNorthwestStates.Источник = "States in the Pacific Northwest of US";
	//ДокументацияNorthwestStates.Markup = ТекстВСписокУзлов("States in the Pacific Northwest of US");

	// <xs:restriction base="xs:string">
	ПростойТип.ИмяБазовогоТипа = Новый РасширенноеИмяXML("http://www.w3.org/2001/XMLSchema", "string");

	// <xs:enumeration value="WA">
	ПеречислениеWA = Новый ФасетПеречисленияXS;
	ПростойТип.Фасеты.Добавить(ПеречислениеWA);
	ПеречислениеWA.Значение = "WA";

	// <xs:annotation>
	АннотацияWA =  Новый АннотацияXS;
	ПеречислениеWA.Аннотация = АннотацияWA;

	// <xs:documentation>Washington</documentation>
	ДокументацияWA = Новый ДокументацияXS;
	АннотацияWA.Состав.Добавить(ДокументацияWA);
	ДокументацияWA.Источник = "Washington";
	//ДокументацияWA.Markup = ТекстВСписокУзлов("Washington");

	// <xs:enumeration value="OR">
	ПеречислениеOR = Новый ФасетПеречисленияXS;
	ПростойТип.Фасеты.Добавить(ПеречислениеOR);
	ПеречислениеOR.Значение = "OR";

	// <xs:annotation>
	АннотацияOR = Новый АннотацияXS;
	ПеречислениеOR.Аннотация = АннотацияOR;
	
	// <xs:documentation>Oregon</xs:documentation>
	ДокументацияOR = Новый ДокументацияXS;
	АннотацияOR.Состав.Добавить(ДокументацияOR);
	ДокументацияOR.Источник = "Oregon";
	//ДокументацияOR.Markup = ТекстВСписокУзлов("Oregon");
	
	// <xs:enumeration value="ID">
	ПеречислениеID = Новый ФасетПеречисленияXS;
	ПростойТип.Фасеты.Добавить(ПеречислениеID);
	ПеречислениеID.Значение = "ID";

	// <xs:annotation>
	АннотацияID = Новый АннотацияXS;
	ПеречислениеID.Аннотация = АннотацияID;

	// <xs:documentation>Idaho</xs:documentation>
	ДокументацияID = Новый ДокументацияXS;
	АннотацияID.Состав.Добавить(ДокументацияID);
	ДокументацияID.Источник = "Idaho";
	//ДокументацияID.Markup = ТекстВСписокУзлов("Idaho");
	
	ТекстXML = Схема.ТекстXML();
	
	Сообщить(ТекстXML);

КонецПроцедуры

Procedure ExampleXSDocumentation()

	Schema = New XMLSchema;

	// <xs:simpleType name="northwestStates">
	SimpleType = New XSSimpleTypeDefinition;
	SimpleType.Name = "northwestStates";
	Schema.Content.Add(SimpleType);

	// <xs:annotation>
	AnnotationNorthwestStates = New XSAnnotation;
	SimpleType.Annotation = AnnotationNorthwestStates;

	// <xs:documentation>States in the Pacific Northwest of US</xs:documentation>
	DocumentationNorthwestStates = New XSDocumentation;
	AnnotationNorthwestStates.Content.Add(DocumentationNorthwestStates);
	DocumentationNorthwestStates.Source = "States in the Pacific Northwest of US";
	//DocumentationNorthwestStates.Markup = TextToNodeArray("States in the Pacific Northwest of US");

	// <xs:restriction base="xs:string">
	SimpleType.BaseTypeName = New XMLExpandedName("http://www.w3.org/2001/XMLSchema", "string");

	// <xs:enumeration value="WA">
	EnumerationWA = New XSEnumerationFacet;
	SimpleType.Facets.Add(EnumerationWA);
	EnumerationWA.Value = "WA";

	// <xs:annotation>
	AnnotationWA = New XSAnnotation;
	EnumerationWA.Annotation = AnnotationWA;

	// <xs:documentation>Washington</documentation>
	DocumentationWA = New XSDocumentation;
	AnnotationWA.Content.Add(DocumentationWA);
	DocumentationWA.Source = "Washington";
	//DocumentationWA.Markup = TextToNodeArray("Washington");

	// <xs:enumeration value="OR">
	EnumerationOR = New XSEnumerationFacet;
	SimpleType.Facets.Add(EnumerationOR);
	EnumerationOR.Value = "OR";

	// <xs:annotation>
	AnnotationOR = New XSAnnotation;
	EnumerationOR.Annotation = AnnotationOR;

	// <xs:documentation>Oregon</xs:documentation>
	DocumentationOR = New XSDocumentation;
	AnnotationOR.Content.Add(DocumentationOR);
	DocumentationOR.Source = "Oregon";
	//DocumentationOR.Markup = TextToNodeArray("Oregon");

	// <xs:enumeration value="ID">
	EnumerationID = New XSEnumerationFacet;
	SimpleType.Facets.Add(EnumerationID);
	EnumerationID.Value = "ID";

	// <xs:annotation>
	AnnotationID = New XSAnnotation;
	EnumerationID.Annotation = AnnotationID;

	// <xs:documentation>Idaho</xs:documentation>
	DocumentationID = New XSDocumentation;
	AnnotationID.Content.Add(DocumentationID);
	DocumentationID.Source = "Idaho";
	//DocumentationID.Markup = TextToNodeArray("Idaho");
	
	XMLText = Schema.XMLText();

	Message(XMLText);

EndProcedure

ПоказатьПримеры();