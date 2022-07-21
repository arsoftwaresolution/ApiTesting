﻿using ApiTesting.Models;
using AutoMapper;
using ApiTesting.Treatments.Dto;

namespace ApiTesting;

public class ApiTestingApplicationAutoMapperProfile : Profile
{
    public ApiTestingApplicationAutoMapperProfile()
    {
        CreateMap<Treatment, Treatment>().ReverseMap();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
