using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using LSEW.Models;
using Spelling_of_words.Properties;

namespace LSEW.ParsingText
{
    internal class ParsingTXT
    {
        private static Random rand = new Random();

        public static List<Word> ReadFile()
        {
            string pathFile = Settings.Default.PathFileWords;

            List<Word> words = new List<Word>();
            if (!File.Exists(pathFile)) return words;

            using (StreamReader sr = new StreamReader(pathFile))
            {
                string currentLine;
                string[] currentFields;

                while ((currentLine = sr.ReadLine()) != null)
                {
                    currentFields = currentLine.Split(',');

                    Word currentUser = new Word
                    (
                        currentFields[0].TrimStart(),
                        currentFields[1].TrimStart()
                    );

                    words.Add(currentUser);
                }
            }

            if (words.Count == 0) return words;

            if (Settings.Default.GenerateRandomWords)
            {
                words = words.OrderBy(a => rand.Next()).ToList();
            }

            MessageBox.Show($"Загружено {words.Count} слов(а)", "Слова из файла");


            return words;
        }
    }
}
