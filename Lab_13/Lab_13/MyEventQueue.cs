using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab_13
{
    public class MyEventQueue<T>: MyQueue<T>
    {
        // Объявляем делегат
        public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
        // Создаём события
        public event CollectionHandler CollectionReferenceChanged;
        public event CollectionHandler Sorted;
        public event CollectionHandler CollectionCountChanged;

        public string collecionName { get; set; }
        public MyEventQueue(string name) : base()
        {
            this.collecionName = name;
        }



        public override T this[int index]
        {
            set
            {
                if (index < 0 || index >= list.Count)
                    throw new IndexOutOfRangeException();
                list[index] = value;
                // call an event handler
                OnCollectionReferenceChanged(this, list[index]);
            }
        }
        // overriden methods with events
        public override void Generate(int cap)
        {
            // используем метод, на который ссылается делегат
            list = genList(cap);
            OnCollectionCountChanged($"generated {cap} elements", this, this);
        }
        public override void Sort()
        {
            sortList(list);
            OnSorted(this);
        }
        public override void Clear()
        {
            list.Clear();
            OnCollectionCountChanged("clear", this, this);
        }
        public override T Dequeue()
        {
            T first = list[0];
            list.RemoveAt(0);
            OnCollectionCountChanged("dequeue", this, list[0]);
            return first;
        }
        public override void Enqueue(T v)
        {
            list.Add(v);
            OnCollectionCountChanged("enqueue", this, v);
        }
        public bool Remove(int j)
        {
            OnCollectionCountChanged("remove at", this, list[j]);
            return list.Remove(list[j]);
        }
        public override string ToString()
        {
            return collecionName;
        }

        // event hadlers
        protected void OnCollectionReferenceChanged(MyEventQueue<T> queue, object changedItem)
        {
            if (CollectionReferenceChanged != null)
                CollectionReferenceChanged(queue, new CollectionHandlerEventArgs(collecionName, "link changed", changedItem));
        }
        protected void OnSorted(object queue)
        {
            if (Sorted != null)
                Sorted(queue, new CollectionHandlerEventArgs(collecionName, "sort", queue));
        }
        protected void OnCollectionCountChanged(string changeType, MyEventQueue<T> queue, object changedItem)
        {
            if (CollectionCountChanged != null)
                CollectionCountChanged(queue, new CollectionHandlerEventArgs(collecionName, changeType, changedItem));
        }
    }
}
