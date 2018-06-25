using Data1;
using Data1.DataSeed;
using System.Linq;

namespace AppApi.Extensions
{
    public static class DatabaseExtension
    {
        public static void EnsureSeed(this PersonalityContext context)
        {
            if (!context.Paragraphs.Any())
            {
                context.Paragraphs.AddRange(DataToAdd.GetParagraphs());
                //context.SaveChanges();
            }
        }
    }
}
