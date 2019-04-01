using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace AlienShooter
{
    class ShooterGame
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            byte screenWidth = 90;
            byte screenHeight = 50;
            int projectileX = 0;
            int projectileY = 0;
            bool gameIsOn = true;
            bool isShotMade = false;

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Clear();                                
            Console.SetWindowSize(screenWidth, screenHeight);
            Console.SetBufferSize(screenWidth, screenHeight);

            int playerX = screenWidth / 2;                  // Setting initial player position
            int playerY = screenHeight - 1;

            while (gameIsOn)
            {
                if (Console.KeyAvailable)  // Console.KeyAvailable indicates when a keyboard button is pressed. Only then we pull the info about that key from the buffer
                {                          // реално с него и без него същия хуй
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("^");

                var pressedKey = Console.ReadKey();
                switch (pressedKey.Key)
                {
                    case ConsoleKey.RightArrow:
                        if (playerX < screenWidth - 2) { playerX += 1; } // ей тука защо не става с playerX < screenWidth ?!?!?
                            break;   
                    case ConsoleKey.LeftArrow:
                        if (playerX > 0) { playerX -= 1; }
                        break;
                    case ConsoleKey.Spacebar:
                        {
                            projectileX = playerX;
                            projectileY = playerY - 1;
                            isShotMade = true;
                            ShotMade(isShotMade, projectileX, projectileY, playerX, playerY); break;
                        }
                }
                Console.Clear();
                Console.SetCursorPosition(playerX, playerY);
                Console.Write("^");

                }
            }
        }
        static void ShotMade(bool isShotMade, int projectileX, int projectileY, int playerX, int playerY)
        {
            while (isShotMade == true)
            {
                Console.SetCursorPosition(projectileX, projectileY);
                Console.Write("*");
                if (projectileY > 0)
                {
                    Thread.Sleep(40);
                    projectileY--;
                    Console.Clear();
                    Console.SetCursorPosition(playerX, playerY);
                    Console.Write("^");
                }
                else isShotMade = !isShotMade;
            }
        }
        static void Enemy(int screenHeight, int screenWidth) // да се зададе време 1-4 сек между появяването на нов враг?!
                                                             // врагът да не се трие заедно в с движението на човечето. 
                                                             // врагът да се движи по хоризонтала към нас
                                                             // да изчезва като го оцелим.
        {   
            Thread.Sleep(200); //Added now
            Random rnd = new Random();
            int enemyX = rnd.Next(1, screenWidth);
            int enemyY = screenHeight - screenHeight;
            Console.SetCursorPosition(enemyX, enemyY);
            Console.Write('@');
        }
    }
}
