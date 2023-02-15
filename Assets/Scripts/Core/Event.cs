using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Core
{
    /// <summary>
    /// An event allows execution of some logic to be defferred for a period time
    /// </summary>
    /// <typeparam name="Event"></typeparam>
    public abstract class Event : System.IComparable<Event>
    {
        public virtual void Execute() { }

        internal float tick;


        public int CompareTo(Event other)
        {
            return tick.CompareTo(other.tick);
        }


        internal virtual void ExecuteEvent() => Execute();

        
        internal virtual void CleanUp()
        {

        }
    }


    public abstract class Event<T> : Event where T : Event<T>
    {
        public static System.Action<T> OnExecute;

        internal override void ExecuteEvent()
        {
            Execute();
            OnExecute?.Invoke((T)this);
        }
    }
}

