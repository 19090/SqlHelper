using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;
using AutoMapper;

namespace Mirabeau.Sql.Library
{
    public interface IModelMapper
    {
        TModel MapTo<TModel>(IDataRecord record);
        Task<IEnumerable<TModel>> MapAsync<TModel>(DbDataReader reader);
    }

    public class ModelMapper : IModelMapper
    {
        public TModel MapTo<TModel>(IDataRecord record)
        {
            var mapper = Mapper.FindTypeMapFor<IDataRecord, TModel>();
            if (mapper != null)
            {
                return Mapper.Map<IDataRecord, TModel>(record);
            }

            return Mapper.DynamicMap<IDataRecord, TModel>(record);
        }

        public async Task<IEnumerable<TModel>> MapAsync<TModel>(DbDataReader reader)
        {
            IList<TModel> list = new List<TModel>();
            while (await reader.ReadAsync())
            {
                list.Add(MapTo<TModel>(reader));
            }
            return list;
        }
    }
}
