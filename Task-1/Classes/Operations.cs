namespace Main.Classes
{
    public class Operations
    {
        public static void BeginTest(string fileName, int totalScore)
        {
            var file = $"{Environment.CurrentDirectory}\\{fileName}";
            string sr = "";

            if (!File.Exists(file))
            {
                using (StreamWriter sw = File.CreateText(file))
                {
                    sw.WriteLine("#Paste the desired text in this line");
                }
            }

            try
            {
                // Open the text file using a stream reader.
                sr = File.ReadAllText(file);
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }

            CheckTextLength(sr, totalScore);
        }

        private static void CheckTextLength(string file, int totalPoint)
        {
            string[] words = file.Split(new[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            int wordCount = words.Length;
            if (wordCount < 500)
                totalPoint -= 5;
            HasUpperCase(file, totalPoint, wordCount, words);
        }

        private static void HasUpperCase(string file, int totalPoint, int wordCount, string[] words)
        {
            if (wordCount > 0 && char.IsUpper(words[0][0]))
                totalPoint -= 5;

            for (int i = 0; i < file.Length; i++)
            {
                if (!char.IsUpper(file[i]))
                    totalPoint -= 5;
                break;
            }
            RepetitionPer(words, totalPoint, wordCount);
        }

        private static void RepetitionPer(string[] words, int totalPoint, int wordCount)
        {
            var wordFrequency = words.GroupBy(w => w.ToLower())
                                    .ToDictionary(g => g.Key, g => (double)g.Count() / wordCount);
            if (wordFrequency.Values.Any(frequency => frequency > 0.20))
                totalPoint -= 5;

            IsLowercase(words, totalPoint);
        }

        private static void IsLowercase(string[] words, int totalPoint)
        {
            bool allLowercase = words.Skip(1).All(word => word.All(char.IsLower));
            if (!allLowercase)
                totalPoint -= 10;

            CheckWordLength(words, totalPoint);
        }

        private static void CheckWordLength(string[] words, int totalPoint)
        {
            bool excessiveWordLength = words.Any(word => word.Length > 20);
            if (excessiveWordLength)
                totalPoint -= 20;

            Console.WriteLine($"Essay score: {totalPoint}");
        }
    }
}