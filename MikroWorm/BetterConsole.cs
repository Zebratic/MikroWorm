using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System
{
    public class BetterConsole
    {
        public static void WritePlus(string text, int ID = 0)
        {
            if (ID == 0)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("+");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("] ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(text);
                Console.Write("\n");
                Console.ForegroundColor = color;
            }
            else
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(ID);
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.Write("] ");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write(text);
                Console.Write("\n");
                Console.ForegroundColor = color;
            }

        }

        public static void WriteWarning(string text, int ID = 0, bool newline = true, bool box = true)
        {
            if (ID == 0)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                if (box)
                {
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("-");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("] ");
                }

                Console.Write(text);

                if (newline)
                    Console.Write("\n");

                Console.ForegroundColor = color;
            }
            else
            {
                var color = Console.ForegroundColor;
                if (box)
                {
                    Console.Write("[");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("-");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.Write("] ");
                }

                Console.Write(text);

                if (newline)
                    Console.Write("\n");

                Console.ForegroundColor = color;
            }
        }

        public static void WriteMinus(string text, int ID = 0)
        {
            if (ID == 0)
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("-");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("] ");
                Console.Write(text);
                Console.Write("\n");
                Console.ForegroundColor = color;
            }
            else
            {
                var color = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(ID);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Write("] ");
                Console.Write(text);
                Console.Write("\n");
                Console.ForegroundColor = color;
            }
        }

        public static void WriteSelection(string text)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(">");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("] ");
            Console.Write(text);
            Console.ForegroundColor = color;
        }

        public static void WriteLine(string text = "\n", ConsoleColor color = ConsoleColor.Gray, bool endbox = false, int ID = -1337)
        {
            if (text == "\n")
            {
                Console.WriteLine();
            }
            else if (ID == -1337)
            {
                var oldcolor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("[");
                Console.ForegroundColor = color;
                Console.Write("#");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("] ");
                Console.ForegroundColor = color;
                Console.Write(text);
                if (endbox)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(" [");
                    Console.ForegroundColor = color;
                    Console.Write("#");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("]");
                }
                Console.Write("\n");
                Console.ForegroundColor = oldcolor;
            }
            else
            {
                var oldcolor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("[");
                Console.ForegroundColor = color;
                Console.Write(ID);
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("] ");
                Console.ForegroundColor = color;
                Console.Write(text);
                if (endbox)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write(" [");
                    Console.ForegroundColor = color;
                    Console.Write(ID);
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Write("]");
                }
                Console.Write("\n");
                Console.ForegroundColor = oldcolor;
            }
        }

        public static void WriteNumber(int nr, string text = "", ConsoleColor color = ConsoleColor.Gray, bool newline = true)
        {
            var oldcolor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            Console.ForegroundColor = color;
            Console.Write(nr);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("] ");
            Console.ForegroundColor = color;
            Console.Write(text);
            if (newline)
                Console.Write("\n");

            Console.ForegroundColor = oldcolor;
        }

        public static void WriteKey(string Key, string text = "", ConsoleColor color = ConsoleColor.Gray, bool newline = true)
        {
            var oldcolor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            Console.ForegroundColor = color;
            Console.Write(Key);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("] ");
            Console.ForegroundColor = color;
            Console.Write(text);
            if (newline)
                Console.Write("\n");

            Console.ForegroundColor = oldcolor;
        }

        public static void WriteGoodBad(string text = "", int ID = 0, bool good = true, bool newline = true)
        {
            var color = Console.ForegroundColor;
            if (good)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.Red;

            Console.Write(text);

            if (newline)
                Console.Write("\n");

            Console.ForegroundColor = color;
        }

        public static int Read()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(">");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("] ");
            Console.ForegroundColor = color;
            return Console.Read();
        }

        public static string ReadLine()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(">");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("] ");
            Console.ForegroundColor = color;
            return Console.ReadLine();
        }

        public static ConsoleKeyInfo ReadKey()
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write(">");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("] ");
            Console.ForegroundColor = color;
            return Console.ReadKey();
        }

        public static void Clear()
        {
            Console.Clear();
        }
    }
}
