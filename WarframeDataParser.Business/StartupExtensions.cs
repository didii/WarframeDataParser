﻿using AutoMapper;
using WarframeDataParser.Business.Dtos;
using WarframeDataParser.Business.Services;
using WarframeDataParser.Db;
using WarframeDataParser.Db.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WarframeDataParser.Business.Builders;
using WarframeDataParser.Business.Fetcher;
using WarframeDataParser.Business.Parsers;
using WarframeDataParser.Business.Selectors;

namespace WarframeDataParser.Business {
    public static class StartupExtensions {
        public static void AddBusinessServices(this IServiceCollection services, IConfiguration configuration) {
            // Fetchers
            services.AddScoped<IDataFetcher, LocalDataFetcher>();

            // Selectors
            services.AddTransient<ISelector<IRewardSelection>, RewardSelector>();
            services.AddTransient<ISelector<IMissionSelection>, MissionSelector>();

            // Parsers
            services.AddTransient<IParser<IRewardSelection>, RewardParser>();
            services.AddTransient<IParser<IMissionSelection>, MissionParser>();

            // Builders
            services.AddTransient<IBuilder, Builder>();
            services.AddTransient(typeof(IBuilderService<>), typeof(BuilderService<>));

            //Mapper
            services.AddTransient<IMapper>(provider => new MapperConfiguration(cfg => cfg.AddProfile<AutomapperProfile>()).CreateMapper());

            // TODO: define model-entity relation here
            //services.AddBusinessService<Dto, DtoCreate, DtoUpdate, Entity>();

            services.AddTransient(typeof(IModelValidator<>), typeof(ModelValidator<>));
            services.AddDbServices(configuration);
        }

        private static void AddBusinessService<TModel, TCreateModel, TUpdateModel, TEntity>(this IServiceCollection services)
            where TModel : DtoBase
            where TCreateModel : DtoCreateBase
            where TUpdateModel : DtoUpdateBase
            where TEntity : class, IDbItem {
            services.AddTransient<IGetService<TModel>, GetService<TModel, TEntity>>();
            services.AddTransient<ICreateService<TModel,TCreateModel>, CreateService<TModel, TCreateModel, TEntity>>();
            services.AddTransient<IUpdateService<TModel, TUpdateModel>, UpdateService<TModel, TUpdateModel, TEntity>>();
            services.AddTransient<IPatchService<TModel, TUpdateModel>, PatchService<TModel, TUpdateModel, TEntity>>();
            services.AddTransient<IDeleteService<TModel>, DeleteService<TModel, TEntity>>();
        }
    }
}