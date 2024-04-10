using Infrastructure.Entites;
using Infrastructure.Factories;
using Infrastructure.Helpers;
using Infrastructure.Models;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;
        private readonly AddressService _addressService;

        public UserService(UserRepository repository, AddressService addressService)
        {
            _repository = repository;
            _addressService = addressService;
        }
        public async Task<ResponseResult> CreateUserAsync(SignUpModel model)
        {

            try
            {
                var exists = await _repository.ExistesAsync(x => x.Email == model.Eamil);
                if (exists.StausCode == StatusCode.Existes)
                
                    return exists;
                  var  result = await _repository.CreateAsync(UserFactory.Create(model));
                    if (result.StausCode != StatusCode.Ok)
                    return result;
                
                return ResponseFactory.Ok("created successfuly");
                   
            
            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }
        public async Task<ResponseResult> SignInUserAsync(SignInModel model)
        {

            try
            {
                var user = await _repository.GetOneAsync(x => x.Email == model.Eamil);
                if (user.StausCode == StatusCode.Ok && user.ContentResult != null)

                {
                    //var userentity=(UserEntity)user.ContentResult;
                    //if (PasswordHasher.validateSecurePassword(model.Password, userentity.Password, userentity.SecurityKey)) ;
                    //return ResponseFactory.Ok();
                }
                return ResponseFactory.Error("Incorrect email or password");

                


            }
            catch (Exception ex)
            {
                return ResponseFactory.Error(ex.Message);
            }
        }
    }
}
