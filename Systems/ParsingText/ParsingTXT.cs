using System;
using System.Collections.Generic;
using System.IO;
using LSEW.Models;

namespace LSEW.ParsingText
{
    internal class ParsingTXT
    {
        public static List<Word> ReadTXTFile(string fileName)
        {
            // TODO Проверить исключения
            if(!File.Exists(fileName)) { throw new ArgumentException("Загружаемый файл не найден!"); }

            List<Word> words = new List<Word>();
            using (StreamReader sr = new StreamReader(fileName))
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

            return words;
        }
    }
}
