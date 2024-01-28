namespace WordsFrequencyCalculator
{
    /// <summary>
    /// Класс с методами обработки файлов
    /// </summary>
    internal class FileProcessor
    {
        /// <summary>
        /// Метод считывает содержимое текстового файла,
        /// разбивает его на слова и возвращает их в виде массива.
        /// </summary>
        /// <param name="filePath">Путь к файлу</param>
        /// <returns>Массив слов</returns>
        internal static String[] GetWordsArray(String filePath)
        {
            String content = File.ReadAllText(filePath);
            String noPunctuation = new String(content.Where(x => !Char.IsPunctuation(x)).ToArray());

            return noPunctuation.Split(" ", StringSplitOptions.RemoveEmptyEntries);
        }

        /// <summary>
        /// Метод группирует слова в массиве,
        /// подсчитвыает количество элементов в каждой группе 
        /// и возвращает упорядоченный по количеству элементов список 10 групп
        /// в виде словаря
        /// </summary>
        /// <param name="arr">Массив слов из которго надо получить топ 10</param>
        /// <returns>Топ 10 самых часто используемых слов</returns>
        internal static Dictionary<String, Int32> GetTopTen(String[] arr)
        {
            var groups = from item in arr
                         group item by item
                         into itemGroup
                         select new
                         {
                             word = itemGroup.Key,
                             itemsCount = itemGroup.Count()
                         };

            var topTen = groups.OrderByDescending(x => x.itemsCount).Take(10);

            return topTen.ToDictionary(x => x.word, x => x.itemsCount);
        }
    }
}
