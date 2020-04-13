using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Sapa.DAL.Models;
using Sapa.BLL.Dtos;

namespace Sapa.BLL.Interfaces
{
    public interface IBuilderService
    {
        Task<IEnumerable<BuilderDto>> FetchBuilders();
        BuilderDto FetchBuilder(int id);
        Task<object> CreateBuilder(BaseBuilderDto builderDto);
        Task<bool> DeleteBuilder(int id);
        Task<bool> UpdateBuilder(int id, BaseBuilderDto builderDto);
    }
}
