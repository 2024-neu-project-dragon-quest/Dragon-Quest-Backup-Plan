using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DragonQuest.Levels;
using DragonQuest.Entities;
using DragonQuest.Misc;
using System.Security.Cryptography;

namespace DragonQuest.Game {

    public class GameInstance {
        
        private Level level;
        public Player player;

        public bool running = true;

        public GameInstance(Level level) {

            this.level = level;
            this.player = new Player(3, 3, this.level);

        }

        private void HandleUserInput() {

            while (running) {
                
                ConsoleKey key = Console.ReadKey(true).Key;

                int[] movementVector = key switch {

                    ConsoleKey.W => [0, -1],
                    ConsoleKey.S => [0, 1],
                    ConsoleKey.A => [-1, 0],
                    ConsoleKey.D => [1, 0],
                    _ => throw new NotImplementedException()

                };

                player.RelativeMove(movementVector[0], movementVector[1]);

            }

        }

        public void Run() {

            /*
            
                add the controls thread here, make it kill itself when it detects that "running" turns false
            
            */
            Thread userInputHandler = new Thread(new ThreadStart(HandleUserInput));
            userInputHandler.Start();

            while (running) {

                Thread.Sleep(20);
                level.Tick();

            }

        }

        public void ChangeLevel(Level level) {

            this.level.freeze = true;
            this.level = level;

            this.player.Kill();

            /*
            
                this here is where other classes should interfere and change the location of the player :pray:
            
            */

            Load();

        }

        public void Load() {

            Canvas.InitCanvas();
            level.DrawLevel();

        }

    }

}