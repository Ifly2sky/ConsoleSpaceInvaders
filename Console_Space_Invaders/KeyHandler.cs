using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_Space_Invaders
{
    internal class FunctionKey
    {
        internal FunctionKey(ConsoleKey key, Action function)
        {
            this.key = key;
            this.function = function;
        }
        internal ConsoleKey key { get; set; }
        internal Action function { get; set; }
    }
    public class KeyHandler
    {
        Thread keyHandlerThread;
        static List<FunctionKey> keyList = new List<FunctionKey>();
        public KeyHandler()
        {
            keyHandlerThread = new Thread(new ThreadStart(CheckKey));
            keyHandlerThread.Start();
        }

        /// <summary>
        /// sets key to be listened to and the function called when the key is heard
        /// </summary>
        /// <param name="key"></param>
        /// <param name="function"></param>
        public void ListenToKey(ConsoleKey key, Action function)
        {
            keyList.Add(new FunctionKey(key, function));
        }
        internal void ListenToKey(FunctionKey functionKey)
        {
            keyList.Add(functionKey);
        }

        private void CheckKey()
        {
            while(keyHandlerThread.IsAlive)
            {
                ConsoleKeyInfo keyPressed = Console.ReadKey(true);
                foreach (FunctionKey key in keyList)
                {
                    if(keyPressed.Key == key.key)
                    {
                        key.function.Invoke();
                    }
                }
            }
        }
    }
}
