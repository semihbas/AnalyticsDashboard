using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnalyticsDashboard.Api.Mappings.Configuration
{
    public static class AutoMapperConfig
    {
        /// <summary>
        /// The register mappings.
        /// </summary>
        /// <returns>
        /// The <see cref="MapperConfiguration"/>.
        /// </returns>
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile(new MappingProfile());
                });
        }
    }
}