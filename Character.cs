namespace CharacterGame
{
    class Character
    {
        public readonly string name;
        public readonly CharacterType type;
        public readonly string[] hints;

        public Character(string name, CharacterType type, string[] hints)
        {
            this.name = name;
            this.type = type;
            this.hints = hints;
        }
    }

    enum CharacterType { ACTOR, POLITICIAN, ATHLETE }
}