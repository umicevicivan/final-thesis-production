using AutoMapper;
using Production.Domen;
using Production.Domen.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Production.API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductToUpdateDTO, Product>();
            CreateMap<AnnualProductionPlanDTO, AnnualProductionPlan>();
            CreateMap<PlanItemDTO, PlanItem>();
            CreateMap<ProductToSaveDTO, Product>();
        }
    }
}
