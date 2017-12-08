using WarframeDataParser.Business.Dtos;
using Microsoft.AspNetCore.JsonPatch;

namespace WarframeDataParser.Business.Services {
    public interface IPatchService<TModel, TUpdateModel> where TModel : DtoBase where TUpdateModel : DtoUpdateBase {
        TModel Patch(int id, JsonPatchDocument<TUpdateModel> updateDocument);
    }
}

