namespace DesignPatternChallengeFlyweight.Flyweight
{
    public interface ICharacter
    {
        void Render(int row, int column);
        int GetMemorySize();
    }
}
