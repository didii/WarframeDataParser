using System;
using System.Collections.Generic;
using WarframeDataParser.Business.Dtos;

namespace WarframeDataParser.Business.Services {
    public interface IGetService<TModel> where TModel : DtoBase {
        TModel Get(long id);
        IEnumerable<TModel> GetAll();
        TModel Get(Func<IEnumerable<TModel>, IEnumerable<TModel>> selector);
    }
}