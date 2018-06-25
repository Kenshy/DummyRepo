using System.Threading.Tasks;

namespace AppApi.Extensions.DataSeed
{
    public interface IDataInitializer
    {
        Task Seed();
    }
}
