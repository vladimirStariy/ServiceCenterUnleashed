using ServiceCenter.Domain.Entity;
using ServiceCenter.Domain.Response;
using ServiceCenter.Domain.Viewmodel.Abonent;
using ServiceCenter.Domain.Viewmodel.Material;
using ServiceCenter.Domain.Viewmodel.Order;

namespace ServiceCenter.Service.Interfaces
{
    public interface IMaterialService
    {
        Task<IBaseResponce<Material>> Create(MaterialViewModel model);
        Task<IBaseResponce<Material>> Update(MaterialViewModel model);
        Task<IBaseResponce<Material>> Remove(uint id);

        IBaseResponce<List<Material>> Get();
        IBaseResponce<List<MaterialListViewModel>> GetMaterialView();
        IBaseResponce<Material> GetById(uint id);
    }
}
