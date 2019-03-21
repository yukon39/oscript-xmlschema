using System;
using System.Collections;
using System.Collections.Generic;
using ScriptEngine.Machine;
using ScriptEngine.Machine.Contexts;

namespace OneScript.XMLSchema
{
    [ContextClass("ФиксированныйСписокКомпонентXS", "XSComponentFixedList")]
    public class XSComponentFixedList : AutoContext<XSComponentFixedList>, ICollectionContext, IEnumerable<IXSComponent>
    {

        #region OneScript

        [ContextMethod("Количество", "Count")]
        public int Count() => Items.Count;

        [ContextMethod("Получить", "Get")]
        public IXSComponent Get(int index) => Items[index];

        [ContextMethod("Содержит", "Contains")]
        public bool Contains(IValue value)
        {
             throw new NotImplementedException();
        }

        #endregion

        #region ICollectionContext

        public CollectionEnumerator GetManagedIterator() => new CollectionEnumerator((IEnumerator<IValue>)GetEnumerator());

        #endregion

        #region IEnumerable

        public IEnumerator<IXSComponent> GetEnumerator() => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        #endregion

        private readonly List<IXSComponent> Items;

        internal XSComponentFixedList() => Items = new List<IXSComponent>();

        internal void Add(IXSComponent value) => Items.Add(value);
        internal void Clear() => Items.Clear();

    }
}
