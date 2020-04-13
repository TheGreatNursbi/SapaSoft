using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sapa.BLL.Dtos;

namespace Sapa.BLL.Interfaces
{
    public interface IBusinessCenterService
    {
        Task<IEnumerable<BuildingDto>> FetchBusinessCenters();
        BuildingDto FetchBusinessCenter(int id);
        Task<bool> DeleteBusinessCenter(int id);
        Task<bool> UpdateBusinessCenter(int id, BaseBuildingDto buildingDto);
        Task<object> CreateBusinessCenter(BaseBuildingDto buildingDto);
    }
}
