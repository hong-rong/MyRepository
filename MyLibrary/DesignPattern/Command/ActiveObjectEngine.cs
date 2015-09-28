using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DesignPattern.Test.Command;

namespace DesignPattern.Command
{
    public class ActiveObjectEngine
    {
        private ArrayList itsCommands = new ArrayList();

        public void AddCommand(ICommand command)
        {
            itsCommands.Add(command);
        }

        public void Run()
        {
            while (itsCommands.Count > 0)
            {
                ICommand c = (ICommand)itsCommands[0];
                itsCommands.RemoveAt(0);
                c.Execute();
            }
        }
    }
}
