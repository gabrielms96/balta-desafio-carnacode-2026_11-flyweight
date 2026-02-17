using DesignPatternChallengeFlyweight.ConcreteFlyweight;
using DesignPatternChallengeFlyweight.Flyweight;

namespace DesignPatternChallengeFlyweight.FlyweightFactory
{
    public class CharacterFactory
    {
        private readonly Dictionary<string, ICharacter> _flyweightCache = new();
        private readonly List<(ICharacter Flyweight, int Row, int Column)> _document = new();

        private static string GetKey(char symbol, string fontFamily, int fontSize, string color,
            bool isBold, bool isItalic, bool isUnderline) =>
            $"{symbol}|{fontFamily}|{fontSize}|{color}|{isBold}|{isItalic}|{isUnderline}";

        public ICharacter GetFlyweight(char symbol, string fontFamily, int fontSize, string color,
            bool isBold, bool isItalic, bool isUnderline)
        {
            var key = GetKey(symbol, fontFamily, fontSize, color, isBold, isItalic, isUnderline);
            if (!_flyweightCache.TryGetValue(key, out var flyweight))
            {
                flyweight = new IntrinsicCharacter(symbol, fontFamily, fontSize, color, isBold, isItalic, isUnderline);
                _flyweightCache[key] = flyweight;
            }
            return flyweight;
        }

        public void AddCharacter(char symbol, string fontFamily, int fontSize, string color,
                                bool isBold, bool isItalic, bool isUnderline, int row, int column)
        {
            var flyweight = GetFlyweight(symbol, fontFamily, fontSize, color, isBold, isItalic, isUnderline);
            _document.Add((flyweight, row, column));
        }

        public void Render()
        {
            foreach (var (flyweight, row, column) in _document)
                flyweight.Render(row, column);
        }

        public void RenderFirst(int count)
        {
            foreach (var (flyweight, row, column) in _document.Take(count))
                flyweight.Render(row, column);
        }

        public void PrintMemoryUsage()
        {
            long flyweightMemory = 0;
            foreach (var fw in _flyweightCache.Values)
                flyweightMemory += fw.GetMemorySize();

            int count = _document.Count;
            long extrinsicMemory = count * (8 + 8);

            Console.WriteLine($"\n=== Uso de Memória (Flyweight) ===");
            Console.WriteLine($"Posições no documento: {count}");
            Console.WriteLine($"Flyweights únicos (compartilhados): {_flyweightCache.Count}");
            Console.WriteLine($"Memória flyweights: {flyweightMemory:N0} bytes");
            Console.WriteLine($"Memória extrínseco (refs + pos): ~{extrinsicMemory:N0} bytes");
            Console.WriteLine($"Total aproximado: {flyweightMemory + extrinsicMemory:N0} bytes ({(flyweightMemory + extrinsicMemory) / 1024.0:N2} KB)");
        }
    }
}
