﻿using AutoMapper;
using Business.Abstract;
using Business.DTOs.Request;
using Business.DTOs.Response;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Rules;
using DataAccess.Abstract;
using Entities.Concrete.Client;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IMapper _mapper;
        UserBusinessRules _businessRules;

        public UserManager(UserBusinessRules businessRules, IUserDal userDal, IMapper mapper)
        {
            _businessRules = businessRules;
            _userDal = userDal;
            _mapper = mapper;
        }

        public async Task<CreatedUserResponse> Add(CreateUserRequest createUserRequest)
        {
            User user = _mapper.Map<User>(createUserRequest);
            User createdUser = await _userDal.AddAsync(user);
            CreatedUserResponse createdUserResponse = _mapper.Map<CreatedUserResponse>(createdUser);
            return createdUserResponse;
        }

        public async Task<DeletedUserResponse> Delete(DeleteUserRequest deleteUserRequest)
        {
            var data = await _userDal.GetAsync(i => i.Id == deleteUserRequest.Id);
            _mapper.Map(deleteUserRequest, data);
            data.DeletedDate = DateTime.Now;
            var result = await _userDal.DeleteAsync(data, true);
            var result2 = _mapper.Map<DeletedUserResponse>(result);
            return result2;
        }

        public async Task<CreatedUserResponse> GetById(Guid id)
        {
            var result = await _userDal.GetAsync(c => c.Id == id);
            User mappedUser = _mapper.Map<User>(result);

            CreatedUserResponse createdUserResponse = _mapper.Map<CreatedUserResponse>(mappedUser);

            return createdUserResponse;
        }

        public async Task<IPaginate<GetListUserResponse>> GetListAsync(PageRequest pageRequest)
        {
            var data = await _userDal.GetListAsync(
                index: pageRequest.PageIndex,
                size: pageRequest.PageSize
            );
            var result = _mapper.Map<Paginate<GetListUserResponse>>(data);
            return result;
        }

        public async Task<UpdatedUserResponse> Update(UpdateUserRequest updateUserRequest)
        {
            var data = await _userDal.GetAsync(i => i.Id == updateUserRequest.Id);
            _mapper.Map(updateUserRequest, data);
            data.UpdatedDate = DateTime.Now;
            await _userDal.UpdateAsync(data);
            var result = _mapper.Map<UpdatedUserResponse>(data);
            return result;
        }
    }
}
