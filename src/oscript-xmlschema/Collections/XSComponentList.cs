using System;
using System.Collections;
using System.Collections.Generic;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace OneScript.XMLSchema
{
    [ContextClass("СписокКомпонентXS", "XSComponentList")]
    public class XSComponentList : AutoContext<XSComponentList>, ICollectionContext, IEnumerable<IXSComponent>
    {

        #region publicOneScriptInterface

        #region Methods

        [ContextMethod("Вставить", "Insert")]
        public void Insert(int index, IXSComponent value) {
            //=> _items.Insert(index, value);
            throw new NotImplementedException();
        }

        [ContextMethod("Добавить", "Add")]
        public void Add(IValue value)
        {
            IXSComponent Value = (IXSComponent)value;

            if (!(Value is IXSComponent))
                throw RuntimeException.InvalidArgumentType();

            _items.Add(Value);
            _owner.OnListInsert(this, Value);
            
        }

        [ContextMethod("Количество", "Count")]
        public int Count() => _items.Count;

        [ContextMethod("Очистить", "Clear")]
        public void Clear() => _items.Clear();

        [ContextMethod("Получить", "Get")]
        public IXSComponent Get(int index)
        {
            //=> _items[index];
            throw new NotImplementedException();
        }

        [ContextMethod("Содержит", "Contains")]
        public Boolean Contains(IXSComponent value)
        {
            throw new NotImplementedException();
        }

        [ContextMethod("Удалить", "Delete")]
        public void Delete(int index)
        {
            throw new NotImplementedException();
        }

        [ContextMethod("Установить", "Set")]
        public void Set(int index, IXSComponent value)
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region ICollectionContext

        public CollectionEnumerator GetManagedIterator() => new CollectionEnumerator((IEnumerator<IValue>)GetEnumerator());

        #endregion

        #region IEnumerable

        public IEnumerator<IXSComponent> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        private readonly IXSListOwner _owner;

        private readonly List<IXSComponent> _items;

        internal XSComponentList(IXSListOwner owner)
        {
            _items = new List<IXSComponent>();
            _owner = owner;
        }
    }

}
