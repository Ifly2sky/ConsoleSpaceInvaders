using System.Runtime.InteropServices;

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
        [DllImport("user32.dll")]
        static extern int GetAsyncKeyState(int key); //using this instead of Console.Readkey to get multple inputs

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

        private void CheckKey()
        {
            while (keyHandlerThread.IsAlive)
            {
                try
                {
                    foreach (FunctionKey key in keyList)
                    {
                        int i = GetAsyncKeyState((int)key.key);
                        if (i != 0)
                        {
                            key.function.Invoke();
                        }
                    }
                } catch (Exception) { }
                Thread.Sleep(1);// keyhandler is too fast for the rest of the game so it has to be slowed
            }
        }
    }
}
