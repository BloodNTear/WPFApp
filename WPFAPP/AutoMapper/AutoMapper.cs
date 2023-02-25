using AutoMapper;
using Repository.Entity;
using Services.BusinessModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.AutoMapper
{
    public class AutoMapper : Profile
    {
        public AutoMapper() {
            CreateMap<User, UserModel>().ReverseMap();
        }
    }
}
