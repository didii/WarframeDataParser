using WarframeDataParser.Business.Dtos;

namespace WarframeDataParser.Business.Services {
    public interface IDeleteService<TModel> where TModel : DtoBase {
        TModel Delete(long id);
    }
}
