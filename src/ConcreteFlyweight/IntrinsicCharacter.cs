using DesignPatternChallengeFlyweight.Flyweight;

namespace DesignPatternChallengeFlyweight.ConcreteFlyweight
{
    public class IntrinsicCharacter : ICharacter
    {
        public char Symbol { get; }
        public string FontFamily { get; }
        public int FontSize { get; }
        public string Color { get; }
        public bool IsBold { get; }
        public bool IsItalic { get; }
        public bool IsUnderline { get; }

        public IntrinsicCharacter(char symbol, string fontFamily, int fontSize, string color,
                                  bool isBold, bool isItalic, bool isUnderline)
        {
            Symbol = symbol;
            FontFamily = fontFamily;
            FontSize = fontSize;
            Color = color;
            IsBold = isBold;
            IsItalic = isItalic;
            IsUnderline = isUnderline;
        }

        public void Render(int row, int column)
        {
            var style = "";
            if (IsBold) style += "B";
            if (IsItalic) style += "I";
            if (IsUnderline) style += "U";

            Console.WriteLine($"[{row},{column}] '{Symbol}' {FontFamily} {FontSize}pt {Color} {style}");
        }

        public int GetMemorySize()
        {
            return sizeof(char) +
                   32 +                   // FontFamily
                   sizeof(int) +
                   32 +                   // Color
                   3 * sizeof(bool);
        }
    }
}
