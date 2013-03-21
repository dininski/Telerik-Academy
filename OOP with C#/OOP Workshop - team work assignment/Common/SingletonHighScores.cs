using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Galaxian.Common
{
    class SingletonHighScores
    {
        private static SingletonHighScores instance;

        private SingletonHighScores() { }

        public static SingletonHighScores Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SingletonHighScores();
                }
                return instance;
            }
        }
    }
}
