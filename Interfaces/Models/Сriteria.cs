namespace Interfaces.Models
{
    public class Сriteria
    {
        public Сriteria(string name, string abbreviation, bool isEnabled)
        {
            Name = name;
            Abbreviation = abbreviation;
            IsEnabled = isEnabled;
        }

        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public bool IsEnabled { get; set; }
    }
}