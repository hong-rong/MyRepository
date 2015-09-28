using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.State.SwitchCase
{
    public interface TurnstileController
    {
        void Lock();
        void Unlock();
        void Thankyou();
        void Alarm();
    }
}
