namespace CharacterGame
{
    class Program
    {
        private bool isRunning = false;
        private bool hasPlayed = false;
        private readonly CharacterManager characterManager = new CharacterManager();
        private readonly List<GameResult> results = new List<GameResult>();

        public void start()
        {
            isRunning = true;
            run();
        }

        private void run()
        {
            while (isRunning)
            {
                var selection = runMenu();
                switch (selection)
                {
                    case 1:
                        var difficulty = getDifficulty()!;
                        var character = characterManager.getRandomCharacter();
                        var result = Game.play(character, difficulty);
                        Console.WriteLine("\nPress any key to return to main menu.");

                        Console.ReadLine();
                        results.Add(result);
                        hasPlayed = true;

                        break;
                    case 2:
                        if (!hasPlayed)
                        {
                            Console.Clear();
                            Console.WriteLine("You haven't played any games yet.");
                            Console.WriteLine("Press any key to return to main menu.");
                            Console.ReadKey();

                            break;
                        }

                        Console.Clear();
                        Console.WriteLine($"You have played {results.Count} games.\n");
                        foreach (var gameResult in results)
                        {
                            var state = gameResult.wonGame ? "Won" : "Lost";
                            Console.WriteLine($"{gameResult.character.name} -> {state}, {gameResult.guesses} guesses, Difficulty: {gameResult.difficulty.name}");
                        }

                        Console.WriteLine("\nPress any key to return to main menu.");
                        Console.ReadKey();

                        break;
                    case 3:
                        isRunning = false;

                        break;
                }
            }

            Console.Clear();

            if (results.Count > 0)
            {
                Console.WriteLine($"You have played {results.Count} games.\n");
                foreach (var gameResult in results)
                {
                    var state = gameResult.wonGame ? "Won" : "Lost";
                    Console.WriteLine($"{gameResult.character.name} -> {state}, {gameResult.guesses} guesses");
                }
            }

            Console.WriteLine("\nThanks for playing the Character Guessing Game.");
            Console.WriteLine("made by Brock Mowry - 200475649");
        }

        private int runMenu()
        {
            var selection = 0;
            while (selection == 0)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Character Guessing Game.\n");
                Console.WriteLine("Please select from one of the following options:");
                Console.WriteLine("1. Play game");
                Console.WriteLine("2. View current score");
                Console.WriteLine("3. Quit");

                var temp = 0;
                bool result = int.TryParse(Console.ReadLine(), out temp);
                if (!result)
                    continue;

                if (temp < 1 || temp > 3)
                    continue;

                selection = temp;
            }

            return selection;
        }

        private Difficulty? getDifficulty()
        {
            Difficulty? difficulty = null;
            while (difficulty == null)
            {
                Console.Clear();
                Console.WriteLine("Please select a difficulty:");
                Console.WriteLine("1. Easy - 5 guesses, 5 hints");
                Console.WriteLine("2. Medium - 3 guesses, 3 hints");
                Console.WriteLine("3. Hard - 2 guesses, 2 hints");

                var temp = 0;
                bool result = int.TryParse(Console.ReadLine(), out temp);
                if (!result)
                    continue;

                if (temp < 1 || temp > 3)
                    continue;

                switch (temp)
                {
                    case 1:
                        difficulty = new Difficulty("Easy", 5, 5);

                        break;

                    case 2:
                        difficulty = new Difficulty("Medium", 3, 3);

                        break;

                    case 3:
                        difficulty = new Difficulty("Hard", 2, 2);

                        break;
                }
            }

            return difficulty;
        }

        static void Main(string[] args)
        {
            new Program().start();
        }
    }
}