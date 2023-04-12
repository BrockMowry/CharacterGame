namespace CharacterGame
{
    class CharacterManager
    {
        private readonly List<Character> characters = new List<Character>() {
            new Character("Donald Trump", CharacterType.POLITICIAN, new string[] {
                "He has 5 children",
                "He was a guest star in Home Alone 2",
                "There is a hotel named after him in New York",
                "He was once the leader of the U.S. Republican Party",
                "He was the 45th president of the U.S"
            }),
        };

        public Character getRandomCharacter()
        {
            return characters[new Random().Next(0, characters.Count)];
        }
    }
}