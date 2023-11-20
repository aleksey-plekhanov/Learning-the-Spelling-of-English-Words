namespace LSEW.Models
{
    public class Word
    {
        public string English { get; set; }
        public string Russian { get; set; }

        public Word(string english, string russian)
        {
            English = english;
            Russian = russian;
        }
    }
}
