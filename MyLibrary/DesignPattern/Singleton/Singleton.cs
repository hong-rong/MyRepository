using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DesignPattern.Singleton
{
    public class Singleton
    {
        private static Singleton _theInstance = null;

        private Singleton()
        { }

        public static Singleton Instance
        {
            get
            {
                if (_theInstance == null)
                    _theInstance = new Singleton();

                return _theInstance;
            }
        }
    }
}
