using Sapa.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Sapa.DAL.Models;
using Sapa.DAL.UnitOfWork;
using Sapa.BLL.Dtos;

namespace Sapa.BLL.Services
{
    public class BusinessCenterService : IBusinessCenterService
    {
        private readonly IUnitOFWork _uow;

        public BusinessCenterService(IUnitOFWork uow)
        {
            _uow = uow;
        }

        public async Task<object> CreateBusinessCenter(BaseBuildingDto buildingDto)
        {
            try
            {
                Building building = new Building
                {
                    Name = buildingDto.Name,
                    Height = buildingDto.Height,
                    Floors = buildingDto.Floors,
                    Address = buildingDto.Address,
                    Price = buildingDto.Price,
                    BuilderId = buildingDto.BuilderId
                };

                await _uow.Repository<Building>().CreateAsync(building);
                await _uow.CommitAsync();

                return buildingDto;
            }
            catch(Exception exception)
            {
                throw new Exception(exception.Message);
            }
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteBusinessCenter(int id)
        {
            if (id == 0 || id < 0)
            {
                throw new Exception("id can not be 0 or null");
            }

            Building building = await _uow.Repository<Building>().GetAsync(id);
            building.IsDeleted = true;

            _uow.Repository<Building>().Update(building);
            await _uow.CommitAsync();

            return true;
        }

        public BuildingDto FetchBusinessCenter(int id)
        {
            try
            {
                Building building = _uow.Repository<Building>().Get(i => i.Id == id && i.IsDeleted == false);
                Builder builder = _uow.Repository<Builder>().Get(i => i.Id == id && i.IsDeleted == false);

                if(building == null)
                {
                    throw new Exception("Building Not Found!");
                }

                BuildingDto buildingDto = new BuildingDto
                {
                    Id = building.Id,
                    Name = building.Name,
                    Height = building.Height,
                    Floors = building.Floors,
                    Address = building.Address,
                    Price = building.Price,
                    Builder = builder
                };

                return buildingDto;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<IEnumerable<BuildingDto>> FetchBusinessCenters()
        {
            try
            {
                IEnumerable<Building> buildings = await _uow.Repository<Building>().GetRangeAsync(i => i.IsDeleted == false);

                IEnumerable<BuildingDto> buildingsDto = from building in buildings
                                                         select new BuildingDto
                                                         {
                                                             Id = building.Id,
                                                             Name = building.Name,
                                                             Address = building.Address,
                                                             Price = building.Price,
                                                             Builder = (_uow.Repository<Builder>().Get(i => i.Id == building.BuilderId && i.IsDeleted == false)),
                                                             Height = building.Height,
                                                             Floors = building.Floors,
                                                         };
                return buildingsDto;
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        public async Task<bool> UpdateBusinessCenter(int id, BaseBuildingDto buildingDto)
        {
            Building building = await _uow.Repository<Building>().GetAsync(id);
            building.Name = buildingDto.Name;
            building.Address = buildingDto.Address;
            building.Height = buildingDto.Height;
            building.Floors = buildingDto.Floors;
            building.BuilderId = buildingDto.BuilderId;
            building.Price = buildingDto.Price;

            _uow.Repository<Building>().Update(building);
            await _uow.CommitAsync();

            return true;
        }
    }
}
