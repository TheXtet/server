using Interfaces.Models;

namespace Interfaces.DTO
{
    public class CriteriaDTO : Сriteria
    {
        public CriteriaDTO(string name, string abbreviation, bool isEnabled, int count) : base(name, abbreviation, isEnabled)
        {
            Score = count;
        }

        public int Score { get; set; }
    }
}