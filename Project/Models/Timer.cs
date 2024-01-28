using System;

namespace Spelling_of_words.Models
{
    public class SecCounter
    {
        public int totalSeconds { get; private set; }

        public SecCounter(int total_seconds = 0)
        {
            SetTotalSeconds(total_seconds);
        }

        public void SetTotalSeconds(int total_seconds) {
            if (total_seconds < 0) throw new Exception("Total Seconds less zero");
            if (totalSeconds == int.MaxValue - 1) throw new Exception("Total Seconds greater than or equal to INT-value");
            totalSeconds = total_seconds;
        }

        public int GetMinutes()
        {
            if (totalSeconds < 60) return 0;
            return totalSeconds / 60;
        }
        
        // Выдает кол-во секунд с вычетом минут
        public int GetSeconds()
        {
            return totalSeconds - GetMinutes() * 60;
        }

        public static SecCounter operator++(SecCounter timer)
        {
            if (timer.totalSeconds == int.MaxValue - 1) throw new Exception("Total Seconds equal to INT-value");
            timer.totalSeconds++;
            return timer;
        }

        public static SecCounter operator--(SecCounter timer)
        {
            if (timer.totalSeconds < 0) throw new Exception("Total Seconds less zero");
            timer.totalSeconds--;
            return timer;
        }
    }
}
