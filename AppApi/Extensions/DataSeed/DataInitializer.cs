using System.Linq;
using System.Threading.Tasks;
using Data1;
using Data1.DataSeed;

namespace AppApi.Extensions.DataSeed
{
    public class DataInitializer : IDataInitializer
    {
        private readonly PersonalityContext _context;

        public DataInitializer(PersonalityContext context)
        {
            _context = context;
        }

        private async Task SeedTraits()
        {
            if (!_context.Traits.Any())
            {
                _context.Traits.AddRange(DataToAdd.GetTraits());
                await _context.SaveChangesAsync();
            }
        }

        private async Task SeedParagraphs()
        {
            if (!_context.Paragraphs.Any())
            {
                _context.Paragraphs.AddRange(DataToAdd.GetParagraphs());
                await _context.SaveChangesAsync();
            }
        }

        private async Task SeedCompanies()
        {
            if (!_context.Companies.Any())
            {
                _context.Companies.AddRange(DataToAdd.GetCompanies());
                await _context.SaveChangesAsync();
            }
        }

        public async Task Seed()
        {
            await SeedTraits();
            await SeedParagraphs();
            await SeedCompanies();
        }
    }
}
