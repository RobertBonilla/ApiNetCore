using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace ApiNetCore.Core
{
    class MappingProfile: Profile
    {
        public MappingProfile()
        {
            //Domain -> Dto
            CreateMap<Domain.Responses.ResponseStatus, Dtos.Responses.ResponseStatus>();
            CreateMap<Domain.Responses.CustomerResponse, Dtos.Responses.CustomerResponse>();
            CreateMap<Domain.Entities.Customer, Dtos.Entities.Customer>();

            //Dto -> Domain
            CreateMap<Dtos.Responses.ResponseStatus, Domain.Responses.ResponseStatus>();
            CreateMap<Dtos.Responses.CustomerResponse, Domain.Responses.CustomerResponse>();
            CreateMap<Dtos.Entities.Customer, Domain.Entities.Customer>();
        }

    }
}
