namespace CharacterGame
{
    class Difficulty
    {
        public readonly string name;
        public readonly int hints;
        public readonly int guesses;

        public Difficulty(string name, int hints, int guesses)
        {
            this.name = name;
            this.hints = hints;
            this.guesses = guesses;
        }
    }
}