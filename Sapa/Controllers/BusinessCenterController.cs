using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapa.BLL.Interfaces;
using Sapa.BLL.Dtos;

namespace Sapa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessCenterController : ControllerBase
    {
        private readonly IBusinessCenterService _businessCenterService;
        public BusinessCenterController(IBusinessCenterService businessCenterService)
        {
            _businessCenterService = businessCenterService;
        }

        [HttpGet(Name = "BusinessCenters")]
        public async Task<BaseResponse<IEnumerable<BuildingDto>>> GetBusinessCenters()
        {
            try
            {
                return new BaseResponse<IEnumerable<BuildingDto>>(await _businessCenterService.FetchBusinessCenters());
            }
            catch (Exception exception)
            {
                return new BaseResponse<IEnumerable<BuildingDto>>(exception);
            }
        }

        [HttpGet("{id}", Name = "BusinessCenter")]
        public BaseResponse<BuildingDto> GetBusinessCenter(int id)
        {
            try
            {
                return new BaseResponse<BuildingDto>(_businessCenterService.FetchBusinessCenter(id));
            }
            catch (Exception exception)
            {
                return new BaseResponse<BuildingDto>(exception);
            }
        }

        [HttpPost]
        public async Task<BaseResponse<BaseBuildingDto>> Post([FromBody] BaseBuildingDto data)
        {
            try
            {
                return new BaseResponse<BaseBuildingDto>((BaseBuildingDto)await _businessCenterService.CreateBusinessCenter(data));
            }
            catch(Exception exception)
            {
                return new BaseResponse<BaseBuildingDto>(exception);
            }
        }

        [HttpPut("{id}")]
        public async Task<BaseResponse<bool>> Put(int id, [FromBody] BaseBuildingDto buildingDto)
        {
            try
            {
                return new BaseResponse<bool>(await _businessCenterService.UpdateBusinessCenter(id, buildingDto));
            }
            catch(Exception exception)
            {
                return new BaseResponse<bool>(exception);
            }
        }

        [HttpDelete("{id}")]
        public async Task<BaseResponse<bool>> Delete(int id)
        {
            try
            {
                return new BaseResponse<bool>(await _businessCenterService.DeleteBusinessCenter(id));
            }
            catch(Exception exception)
            {
                return new BaseResponse<bool>(exception);
            }
        }
    }
}
