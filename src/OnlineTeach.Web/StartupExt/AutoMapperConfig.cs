using AutoMapper.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineTeach.Web.Data.Adult;
using OnlineTeach.Web.Models.AdultViewModels;
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
            AutoMapper.Mapper.Initialize(config);
        }
    }
}
