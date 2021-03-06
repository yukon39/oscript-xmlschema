#Использовать ".."
#Использовать asserts

Перем ЮнитТест;

#Область ОбработчикиТестирования

Процедура ТестИстина() Экспорт

	Ожидаем.Что(1).Равно(1);

КонецПроцедуры

Процедура ТестКонструктор() Экспорт

	Переопределение = Новый ПереопределениеXS;
	
	Ожидаем.Что(Переопределение.ТипКомпоненты).Равно(ТипКомпонентыXS.Переопределение);
	
	ОсвободитьОбъект(Переопределение);

КонецПроцедуры

Procedure TestConstructor() Export

	Redefine = new XSRedefine;

	Ожидаем.Что(Redefine.ComponentType).Равно(XSComponentType.Redefine);
	
	FreeObject(Redefine);

EndProcedure

#Область ОбработчикиСобытийМодуля

Функция ПолучитьСписокТестов(МенеджерТестирования) Экспорт
	
	ЮнитТест = МенеджерТестирования;

	МенеджерТестирования.ДобавитьТест("ТестИстина");
	МенеджерТестирования.ДобавитьТест("ТестКонструктор");
	МенеджерТестирования.ДобавитьТест("TestConstructor");

	Возврат Неопределено;

КонецФункции

#КонецОбласти