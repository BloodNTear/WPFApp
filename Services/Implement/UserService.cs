using AutoMapper;
using Repository.Entity;
using Repository.Interface;
using Services.BusinessModel;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implement
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public UserModel Login(string username, string password)
        {
            var result =  _mapper.Map<User, UserModel>(_userRepository.Login(username, password));
            return result;
        }
    }
}
