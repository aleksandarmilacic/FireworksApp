using System;
using System.Collections.Generic;
namespace FireworksApp
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Fireworks Show!");
            Console.WindowHeight = 40;
            Console.WindowWidth = 150;
            bool isRed = true;
            while (true)
            {
                DisplayMessage(isRed);
                DrawFirework();
                Thread.Sleep(2000); // Delay between fireworks
                isRed = !isRed;
            }
        }

        static void DisplayMessage(bool isRed)
        {
            Console.SetCursorPosition(0, 0); 
            Console.ForegroundColor = isRed ? ConsoleColor.Red : ConsoleColor.Green;
            Console.Write("Happy 2024!");
            Console.ResetColor(); // Reset to default color
        }


        static void DrawFirework()
        {
            Random rnd = new Random();
            int groundLevel = Console.WindowHeight - 1;
            int quarterHeight = groundLevel / 4;
            int halfHeight = groundLevel / 2;
            int fireworkHeight = rnd.Next(quarterHeight, halfHeight); // Fireworks explode in the upper quarter to half of the screen

            int fireworkX = rnd.Next(0, Console.WindowWidth);

            // Launch the firework
            for (int y = groundLevel; y > fireworkHeight; y--)
            {
                DrawPoint(fireworkX, y, ConsoleColor.White);
                Thread.Sleep(50);
                ClearPoint(fireworkX, y);
            }

            // Explosion
            int explosionRadius = rnd.Next(3, 6);
            int explosionDensity = rnd.Next(20, 30);
            ConsoleColor[] colors = { ConsoleColor.Red, ConsoleColor.Green, ConsoleColor.Yellow, ConsoleColor.Cyan, ConsoleColor.Magenta };

            for (int i = 0; i < explosionDensity; i++)
            {
                int x = rnd.Next(fireworkX - explosionRadius, fireworkX + explosionRadius);
                int y = rnd.Next(fireworkHeight - explosionRadius, fireworkHeight + explosionRadius);

                if (x >= 0 && x < Console.WindowWidth && y >= 0 && y < Console.WindowHeight)
                {
                    DrawPoint(x, y, colors[rnd.Next(colors.Length)]);
                }
            }

            Thread.Sleep(300);
            Console.Clear(); // Clear after the explosion
        }

        static void DrawPoint(int x, int y, ConsoleColor color)
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = color;
            Console.Write("*");
        }

        static void ClearPoint(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }
    }

}
