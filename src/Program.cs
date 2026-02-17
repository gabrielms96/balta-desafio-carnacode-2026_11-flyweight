using DesignPatternChallengeFlyweight.FlyweightFactory;

namespace DesignPatternChallengeFlyweight
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Editor de Texto - Problema de Memória ===\n");

            var characterFactory = new CharacterFactory();

            // Simulando documento com texto formatado
            // Problema: Repetição massiva de dados compartilháveis

            // Linha 1: "Hello World" em Arial 12pt preto
            string text1 = "Hello World";
            for (int i = 0; i < text1.Length; i++)
            {

                characterFactory.AddCharacter(
                    text1[i],
                    "Arial",
                    12,
                    "Black",
                    false,
                    false,
                    false,
                    1,
                    i + 1
                );
            }

            // Linha 2: "IMPORTANT" em Arial 12pt vermelho, negrito
            string text2 = "IMPORTANT";
            for (int i = 0; i < text2.Length; i++)
            {
                characterFactory.AddCharacter(
                    text2[i],
                    "Arial",      // Repetido novamente!
                    12,
                    "Red",
                    true,
                    false,
                    false,
                    2,
                    i + 1
                );
            }

            // Linha 3: Mais texto normal
            string text3 = "This is a sample text";
            for (int i = 0; i < text3.Length; i++)
            {
                characterFactory.AddCharacter(
                    text3[i],
                    "Arial",
                    12,
                    "Black",
                    false,
                    false,
                    false,
                    3,
                    i + 1
                );
            }

            Console.WriteLine("Renderizando primeiros 5 caracteres:\n");
            characterFactory.RenderFirst(5);

            characterFactory.PrintMemoryUsage();
        }
    }
}