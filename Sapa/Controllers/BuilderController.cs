using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sapa.BLL.Interfaces;
using Sapa.BLL.Dtos;
using Newtonsoft.Json;

namespace Sapa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuilderController : ControllerBase
    {
        private readonly IBuilderService _builderService;
        public BuilderController(IBuilderService builerService)
        {
            _builderService = builerService;
        }

        [HttpGet]
        public async Task<BaseResponse<IEnumerable<BuilderDto>>> GetBuilders()
        {
            try
            {
                return new BaseResponse<IEnumerable<BuilderDto>>(await _builderService.FetchBuilders());
            }
            catch(Exception exception)
            {
                return new BaseResponse<IEnumerable<BuilderDto>>(exception);
            }
        }

        [HttpGet("{id}", Name = "Builder")]
        public BaseResponse<BuilderDto> GetBuilder(int id)
        {
            try
            {
                return new BaseResponse<BuilderDto>(_builderService.FetchBuilder(id));
            }
            catch(Exception exception)
            {
                return new BaseResponse<BuilderDto>(exception);
            }
        }

        [HttpPost]
        public async Task<BaseResponse<BaseBuilderDto>> Post([FromBody] BaseBuilderDto data)
        {
            try
            {
                return new BaseResponse<BaseBuilderDto>((BaseBuilderDto)await _builderService.CreateBuilder(data));
            }
            catch(Exception exception)
            {
                return new BaseResponse<BaseBuilderDto>(exception);
            }
        }

        [HttpPut("{id}")]
        public async Task<BaseResponse<bool>> Put(int id, [FromBody] BaseBuilderDto builderDto)
        {
            try
            {
                return new BaseResponse<bool>(await _builderService.UpdateBuilder(id, builderDto));
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
                return new BaseResponse<bool>(await _builderService.DeleteBuilder(id));
            }
            catch(Exception exception)
            {
                return new BaseResponse<bool>(exception);
            }
        }
    }
}
