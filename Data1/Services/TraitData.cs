using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Data1.Contracts;
using Data1.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Data1.Services
{
    public class TraitData : ITraitData
    {
        private readonly PersonalityContext _context;

        public TraitData(PersonalityContext context)
        {
            _context = context;
        }

        public async Task<List<TraitDto>> GetTraits()
        {
            return await _context.Traits.ProjectTo<TraitDto>().ToListAsync();
        }

        public async Task<ParagraphDto> GetParagraphs(ParagraphType paragraphType)
        {
            return await _context.Paragraphs.Where(x => x.TypeId == paragraphType).ProjectTo<ParagraphDto>()
                .FirstOrDefaultAsync();
        }
    }
}
