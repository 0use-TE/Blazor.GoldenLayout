using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.GoldenLayout
{
    internal class GoldenLayoutEventService
    {
        public event Func<GoldenLayout,string,Task>? OnGoldenLayoutInited;

        public void Subscribe(Func<GoldenLayout,string,Task> func)
        {
            OnGoldenLayoutInited += func;
        }

        public void Publish(GoldenLayout goldenLayout,string identify)
        {
            OnGoldenLayoutInited?.Invoke(goldenLayout,identify);
        }
        public void Unsubscribe(Func<GoldenLayout,string,Task> func)
        {
            OnGoldenLayoutInited-=func;
        }
    }
}
