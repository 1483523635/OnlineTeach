using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineTeach.Web.Data.Adult;
using OnlineTeach.Web.Data.Cource;
using OnlineTeach.Web.Models.AdultViewModels;
using OnlineTeach.Web.Models.CourceViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineTeach.Web.StartupExt
{
    public static class AutoMapperConfig
    {
        public static void MapperInit(this IServiceCollection services)
        {
            var config = new MapperConfigurationExpression();
            config.CreateMap<TeacherApply, TeacherApplyViewModel>().ConstructUsing(c => new TeacherApplyViewModel() { Id = c.key });
            config.CreateMap<CourceItem, CourceItemCreateViewModel>();
            config.CreateMap<CourceItem, CourceItemDisplayViewModel>();
            AutoMapper.Mapper.Initialize(config);
        }
    }
}
