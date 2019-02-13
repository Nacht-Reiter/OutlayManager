using OutlayManager.DataAccess.Models;
using System.Threading.Tasks;

namespace OutlayManager.DataAccess.Repository
{
    public interface IUnitOfWork
    {
        IRepository<TModel> Repository<TModel>() where TModel : Model;
        Task<int> SaveAsync();
    }
}
