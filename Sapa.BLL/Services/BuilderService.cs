using Sapa.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sapa.DAL.Models;
using Sapa.DAL.UnitOfWork;
using Sapa.BLL.Dtos;
using AutoMapper;
using System.Linq;

namespace Sapa.BLL.Services
{
    public class BuilderService : IBuilderService
    {
        private readonly IUnitOFWork _uow;

        public BuilderService(IUnitOFWork uow)
        {
            _uow = uow;
        }

        public async Task<object> CreateBuilder(BaseBuilderDto builderDto)
        {
            try
            {
                if(string.IsNullOrEmpty(builderDto.Name) || string.IsNullOrEmpty(builderDto.Address) || string.IsNullOrEmpty(builderDto.BIN))
                {
                    throw new Exception("Properties should have value");
                }

                Builder builder = new Builder
                {
                    Name = builderDto.Name,
                    BIN = builderDto.BIN,
                    ActivityStartDate = DateTime.Parse(builderDto.ActivityStartDate),
                    Address = builderDto.Address,
                    IsDeleted = false
                };

                await _uow.Repository<Builder>().CreateAsync(builder);
                await _uow.CommitAsync();

                return builderDto;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<bool> DeleteBuilder(int id)
        {
            if(id == 0 || id < 0)
            {
                throw new Exception("id can not be null or 0");
            }

            Builder builder = await _uow.Repository<Builder>().GetAsync(id);
            builder.IsDeleted = true;

            _uow.Repository<Builder>().Update(builder);
            await _uow.CommitAsync();

            return true;
        }

        public BuilderDto FetchBuilder(int id)
        {
            try
            {
                if(id == 0 || id < 0)
                {
                    throw new Exception("id can not be null");
                }

                Builder builder = _uow.Repository<Builder>().Get(i => i.Id == id && i.IsDeleted == false);

                if(builder == null)
                {
                    throw new Exception("Builder Not Found!");
                }

                BuilderDto builderDto = new BuilderDto
                {
                    Id = builder.Id,
                    Name = builder.Name,
                    BIN = builder.BIN,
                    ActivityStartDate = builder.ActivityStartDate,
                    Address = builder.Address
                };

                return builderDto;
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<IEnumerable<BuilderDto>> FetchBuilders()
        {
            try
            {
                IEnumerable<Builder> builders = await _uow.Repository<Builder>().GetRangeAsync(i => i.IsDeleted == false);
                IEnumerable<BuilderDto> buildersDto = from builder in builders
                                                     select new BuilderDto
                                                     {
                                                         Id = builder.Id,
                                                         Name = builder.Name,
                                                         BIN = builder.BIN,
                                                         ActivityStartDate = builder.ActivityStartDate,
                                                         Address = builder.Address
                                                     };
                return buildersDto;
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<bool> UpdateBuilder(int id, BaseBuilderDto builderDto)
        {
            Builder builder = await _uow.Repository<Builder>().GetAsync(id);

            if(builder == null)
            {
                throw new Exception("Builder not found!");
            }

            builder.Name = builderDto.Name;
            builder.Address = builderDto.Address;
            builder.BIN = builderDto.BIN;
            builder.ActivityStartDate = DateTime.Parse(builderDto.ActivityStartDate);

            _uow.Repository<Builder>().Update(builder);
            await _uow.CommitAsync();

            return true;
        }
    }
}
