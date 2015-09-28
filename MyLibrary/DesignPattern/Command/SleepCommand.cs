using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPattern.Test.Command;

namespace DesignPattern.Command
{
    public class SleepCommand : ICommand
    {
        private ICommand wakeUpCommand = null;
        private ActiveObjectEngine engine = null;
        private long sleepTime = 0;
        private DateTime startTime;
        private bool started = false;

        public SleepCommand(long milliSeconds, ActiveObjectEngine e, ICommand wakeUpCommand)
        {
            sleepTime = milliSeconds;
            engine = e;
            this.wakeUpCommand = wakeUpCommand;
        }

        public void Execute()
        {
            DateTime currentTime = DateTime.Now;

            if (!started)
            {
                started = true;
                startTime = currentTime;
                engine.AddCommand(this);
            }
            else
            {
                TimeSpan elapsedTime = currentTime - startTime;
                if (elapsedTime.TotalMilliseconds < sleepTime)
                {
                    engine.AddCommand(this);
                }
                else
                {
                    engine.AddCommand(wakeUpCommand);
                }
            }
        }
    }
}
