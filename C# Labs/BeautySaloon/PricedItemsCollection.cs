using System;
using System.Collections;
using System.Collections.Generic;

namespace BeautySaloon
{
    public class PricedItemsCollection<T> : ICollection<T> where T : IPricedItem
    {
        protected ArrayList Storage;
        public PricedItemsCollection()
        {
            var hello = new List<string>();
            hello.Sort((x, y) => {
                return x.Length - y.Length;
            });

            Storage = new ArrayList();
        }

        public virtual bool IsReadOnly => false;

        public virtual T this[int index]
        {
            get
            {
                return (T)Storage[index];
            }
            set
            {
                Storage[index] = value;
            }
        }
        public virtual int Count => Storage.Count;
        public virtual void Add(T item) => Storage.Add(item);
        public virtual bool Remove(T item)
        {
            for (int i = 0; i < Storage.Count; i++) {
                var curItem = (T)Storage[i];
                if (curItem.Equals(item)) {
                    Storage.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public virtual void Clear() => Storage.Clear();
        public virtual bool Contains(T item)
        {
            for (int i = 0; i < Storage.Count; i++) {
                var curItem = (T)Storage[i];
                if (curItem.Equals(item)) {
                    return true;
                }
            }
            return false;
        }
        public virtual void CopyTo(T[] PricedItemsArray, int index)
        {
            throw new Exception("CopyTo is unimplemented.");
        }
        public virtual IEnumerator<T> GetEnumerator() => new PricedItemsEnumerator<T>(this);
        IEnumerator IEnumerable.GetEnumerator() => new PricedItemsEnumerator<T>(this);

        public void Sort(Func<T, T, int> comparison)
        {
            for (int i = 0; i < Storage.Count; i++) {
                var item = Storage[i];
                var currentIndex = i;

                while (currentIndex > 0 && comparison((T)Storage[currentIndex - 1], (T)item) > 0) {
                    Storage[currentIndex] = Storage[currentIndex - 1];
                    currentIndex--;
                }

                Storage[currentIndex] = item;
            }
        }
    }

    public class PricedItemsEnumerator<T> : IEnumerator<T> where T : IPricedItem
    {
        protected PricedItemsCollection<T> Collection;
        protected int CurrentIndex;
        protected T CurrentItem;

        public PricedItemsEnumerator() { }

        public PricedItemsEnumerator(PricedItemsCollection<T> collection)
        {
            Collection = collection;
            CurrentIndex = -1;
            CurrentItem = default;
        }

        public virtual T Current => CurrentItem;
        object IEnumerator.Current => CurrentItem;
        public virtual void Dispose()
        {
            Collection = null;
            CurrentIndex = -1;
            CurrentItem = default;
        }

        public virtual bool MoveNext()
        {
            CurrentIndex++;
            if (CurrentIndex >= Collection.Count)
                return false;

            CurrentItem = Collection[CurrentIndex];
            return true;
        }

        public virtual void Reset()
        {
            CurrentItem = default;
            CurrentIndex = -1;
        }
    }
}
