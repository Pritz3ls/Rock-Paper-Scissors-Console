using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace Application{
    // Handles Game Variables
    class GameVars{
        public static int inputindex = 0; /* 3 index is null input/invalid */
        public static bool turn = true;
        public static int PScore = 0;
        public static int AScore = 0;
    }
    class Main_Game{
        // Handles kickstart of the application
        Master gameMaster = new Master();
        public void Boot(){
            // Initialize Buffer and Window Elements
            Console.SetWindowSize(38,17);
            Console.SetBufferSize(Console.WindowWidth,Console.WindowHeight);
            Console.Title = "Rock Paper Scissors";
            // Start the Game
            Input();
        }
        public void Render(){
            string[] options = {"Q - Rock", "W - Paper", "E - Scissors"};
            // Display Turn
            if(GameVars.turn){
                // Display what player move is using the index / Connect with Master
                WriteLine("┌────────────────────────────────────┐");
                WriteLine($"\tPlayer: {GameVars.PScore}\tAi: {GameVars.AScore}");
                WriteLine(" ------------------------------------ ");
                for (int i = 0; i < options.Length; i++){WriteLine($" {options[i]}");}
                WriteLine("└────────────────────────────────────┘");
            }
            // Display End Turn
            if(!GameVars.turn){
                int winner = 0;
                // Process who wins then return an integer
                winner = gameMaster.Think(GameVars.inputindex);
                switch (winner){
                    case 1:
                        GameVars.PScore += 1;
                    break;
                    case 2:
                        GameVars.AScore += 1;
                    break;
                }
                WriteLine("┌────────────────────────────────────┐");
                // Print out the updated scores
                WriteLine($"\tPlayer: {GameVars.PScore}\tAi: {GameVars.AScore}");
                // Print out who wins
                WriteLine(" ------------------------------------ ");
                string space = "      ";
                if(winner == 1){WriteLine($"\t{space}PLAYER wins!");}else if(winner == 2){WriteLine($"\t{space}  AI wins!");}else{WriteLine($"\t{space}   DRAW!");}
                WriteLine(" ------------------------------------ ");
                // Print out what move did both side chose
                WriteLine($"\tPlayer {gameMaster.Turn(GameVars.inputindex)}\n\tAi {gameMaster.Turn(gameMaster.AiIndex)}");
                WriteLine(" ------------------------------------ ");
                WriteLine("└────────────────────────────────────┘");
                WriteLine("Press any key to continue...");
                ReadKey(true);
                GameVars.turn = true;
                // Loop Gameplay
                Input();
            }
        }
        
        private void Input(){
            ConsoleKey keypressed;
            do{
                Clear();
                Render();
                ConsoleKeyInfo keyInfo = ReadKey(true);
                keypressed = keyInfo.Key;
                // Rock Paper Scissors
                if(keypressed == ConsoleKey.Q){
                    GameVars.inputindex = -1;
                    GameVars.turn = false;
                }else if(keypressed == ConsoleKey.W){
                    GameVars.inputindex = 0;
                    GameVars.turn = false;
                }else if(keypressed == ConsoleKey.E){
                    GameVars.inputindex = 1;
                    GameVars.turn = false;
                }
                // Quit Game
                if(keypressed == ConsoleKey.Backspace){
                    Console.WriteLine("Press any key to exit....");
                    ReadKey(true);
                    return;
                }
            } while (GameVars.turn == true);
            Clear();
            Render();
        }
    }
}