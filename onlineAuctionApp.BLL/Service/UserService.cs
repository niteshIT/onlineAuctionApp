using AutoMapper;
using onlineActionApp.DLL.IRepository;
using onlineActionApp.DLL.Models;
using onlineAuctionApp.BLL.IServices;
using OnlineAuctionApp.Dtos.Dtos;
using OnlineAuctionApp.Dtos.Dtos.onlineAuctionApp.BLL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace onlineAuctionApp.BLL.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public UserService(IUserRepository userRepository, IMapper mapper, IJwtTokenGenerator jwtTokenGenerator)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public string Authenticate(UserLoginDto userLoginDto)
        {
            var user = _userRepository.GetUserByEmailAndPassword(userLoginDto.Email, userLoginDto.Password);
            if (user == null) return null;

            // Generate JWT token
            return _jwtTokenGenerator.GenerateToken(user);
        }

        public UserDto GetUserById(int id)
        {
            var user = _userRepository.GetUserById(id);
            return _mapper.Map<UserDto>(user);
        }

        public User UpdateUser(int id,UserUpdateDto userUpdateDto)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
            {
                return null;
            }

            // Update user properties


            user.IsBaned = userUpdateDto.IsBaned;
            
            // Other properties as needed

            _userRepository.Update(user);
            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
    }
}
