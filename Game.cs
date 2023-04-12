using System.Reflection.PortableExecutable;

namespace CharacterGame
{
    class Game
    {
        public static GameResult play(Character character, Difficulty difficulty)
        {
            var guesses = 0;

            while (guesses < difficulty.guesses)
            {
                Console.Clear();
                Console.WriteLine($"Your category: {character.type}");
                Console.WriteLine($"Your difficulty: {difficulty.name}\n");
                Console.WriteLine($"You have {difficulty.guesses - guesses} to guess(es) remaining...\n");
                Console.WriteLine("Hints:");
                for (var i = 0; i < difficulty.guesses; i++)
                    Console.WriteLine(character.hints[i]);
                Console.WriteLine("\nPlease enter your guess:");

                var guess = getGuess();
                guesses++;

                if (guess.ToLower() == character.name.ToLower())
                {
                    Console.Clear();
                    Console.WriteLine($"Congratulations! You've won in {guesses} guess(es).");
                    Console.WriteLine($"Your character was {character.name}.");
                    return new GameResult(character, difficulty, true, guesses);
                }

                Console.Clear();
                Console.WriteLine("That guess was incorrect.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }

            Console.Clear();
            Console.WriteLine($"Oh no! You lost in {guesses} guess(es).");
            Console.WriteLine($"Your character was {character.name}.");
            return new GameResult(character, difficulty, false, guesses);
        }

        private static String getGuess()
        {
            var guess = "";
            while (guess == "")
            {
                var temp = Console.ReadLine();
                if (temp == null || temp.Trim() == "")
                    continue;
                
                guess = temp;
            }

            return guess;
        }
    }

    class GameResult
    {
        public readonly Character character;
        public readonly Difficulty difficulty;
        public readonly bool wonGame;
        public readonly int guesses;

        public GameResult(Character character, Difficulty difficulty, bool wonGame, int guesses)
        {
            this.character = character;
            this.difficulty = difficulty;
            this.wonGame = wonGame;
            this.guesses = guesses;
        }
    }
}