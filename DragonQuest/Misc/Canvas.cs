using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DragonQuest.Misc {

    public class Canvas {

        public static void WriteAt(int x, int y, char c, ConsoleColor? bgc, ConsoleColor? fgc) {

            (int left, int top) = Console.GetCursorPosition();
            ConsoleColor originalBGC = Console.BackgroundColor,
                         originalFGC = Console.ForegroundColor;

            Console.SetCursorPosition(x, y);
            Console.BackgroundColor = bgc == null ? originalBGC : (ConsoleColor) bgc;
            Console.ForegroundColor = fgc == null ? originalFGC : (ConsoleColor) fgc;

            Console.Write(c);

            Console.BackgroundColor = originalBGC;
            Console.ForegroundColor = originalFGC;
            Console.SetCursorPosition(left, top);

        }

        public static void Clear() => Console.Clear();

        public static void ShowCursor(bool b) => Console.CursorVisible = b;

        public static void InitCanvas() {

            Console.Clear();
            Console.CursorVisible = false;

            for (int x = 0; x < Console.WindowWidth; x++)
                for (int y = 0; y < Console.WindowHeight; y++) Canvas.WriteAt(x, y, ' ', ConsoleColor.Black, null);

        }

    }

}