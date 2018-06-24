using System.Linq;
using Data1.Contracts;

namespace Data1.Services
{
    public class TraitData : ITraitData
    {
        private PersonalityContext _context;

        public TraitData(PersonalityContext context)
        {
            _context = context;
        }

        public int GetData()
        {
            var data = _context.Traits.Count();
            return data;
        }
    }
}
