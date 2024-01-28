namespace WordsFrequencyCalculator
{
    internal class Program
    {
        static void Main(String[] args)
        {
            var arr = FileProcessor.GetWordsArray(args[0]);
            var topTenWords = FileProcessor.GetTopTen(arr);

            Console.WriteLine("Топ 10 самых используемых слов в тексте:");

            foreach (var word in topTenWords)
            {
                Console.WriteLine($"«{word.Key}» \t {word.Value}");
            }

            Console.ReadLine();
        }
    }
}