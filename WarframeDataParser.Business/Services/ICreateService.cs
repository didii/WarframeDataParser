using WarframeDataParser.Business.Dtos;

namespace WarframeDataParser.Business.Services {
    public interface ICreateService<TModel, TCreateModel> where TModel: DtoBase where TCreateModel : DtoCreateBase {
        TModel Create(TCreateModel createModel);
    }
}