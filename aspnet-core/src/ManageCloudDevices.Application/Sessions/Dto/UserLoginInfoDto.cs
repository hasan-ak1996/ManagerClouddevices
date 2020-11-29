using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using ManageCloudDevices.Authorization.Users;
using output.DTO;
using System;
using System.Collections.Generic;

namespace ManageCloudDevices.Sessions.Dto
{
    [AutoMapFrom(typeof(User))]
    public class UserLoginInfoDto : EntityDto<long>
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string UserName { get; set; }

        public string EmailAddress { get; set; }
        public Guid SecretKey { get; set; }
        public  List<DeviceDto> Devices { get; set; }
    }
}
