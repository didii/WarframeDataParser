using WarframeDataParser.Business.Dtos;

namespace WarframeDataParser.Business.Services {
    public interface IUpdateService<TModel, TUpdateModel> where TModel : DtoBase where TUpdateModel : DtoUpdateBase {
        TModel Update(long id, TUpdateModel newModel);
    }
}
