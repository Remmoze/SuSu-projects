namespace BeautySaloon
{
    public class Date
    {
        public string TimeOfDay { get; private set; }
        public int Hour { get; }
        public int Minutes { get; }

        public Date(int hours, int minutes)
        {
            Hour = hours;
            Minutes = minutes;

            Hour %= 24;
            if (Hour < 6)
                TimeOfDay = "Ночь";
            else if (Hour < 12)
                TimeOfDay = "Утро";
            else if (Hour < 18)
                TimeOfDay = "День";
            else
                TimeOfDay = "Вечер";
        }

        public override string ToString()
        {
            return $"{Hour:D2}:{Minutes:D2} ({TimeOfDay})";
        }
    }
}
