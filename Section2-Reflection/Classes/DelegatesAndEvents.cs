using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Section2_Reflection.Classes
{
    internal class DelegatesAndEvents
    {
        public event EventHandler<int> MyEvent;

        public void Handler(object sender, int arg)
        {
            Actions.writeLine($"Arg is : {arg} from {sender?.GetType().Name}");
        }

        public static void FirsFunction()
        {
            var demo = new DelegatesAndEvents();

            var eventInfo = typeof(DelegatesAndEvents).GetEvent("MyEvent");
            var handlerMethod = demo.GetType().GetMethod("Handler");

            // we need a delegate of a particular type
            var handler = Delegate.CreateDelegate(
              eventInfo.EventHandlerType,
              null, // object that is the first argument of the method the delegate represents
              handlerMethod
            );
            eventInfo.AddEventHandler(demo, handler);

            demo.MyEvent?.Invoke(null, 312);
        }
    }
}
