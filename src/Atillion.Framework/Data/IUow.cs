using System.Threading.Tasks;
namespace Atillion.Framework.Data
{
    public interface IUow
    {
        Task<int> CommitAsync();
        int Commit();
    }
}
