using System.Collections.Generic;
using System.Threading.Tasks;
using Data1.Dtos;

namespace Data1.Contracts
{
    public interface ITraitData
    {
        Task<List<TraitDto>> GetTraits();
        Task<ParagraphDto> GetParagraphs(ParagraphType paragraphType);
        Task<string> GetTraitText(string id, decimal value);
    }
}
