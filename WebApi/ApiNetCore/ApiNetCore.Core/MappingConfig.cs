using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ApiNetCore.Core
{
    public class MappingConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(config => config.AddProfile(new MappingProfile()));
        }
    }
}
