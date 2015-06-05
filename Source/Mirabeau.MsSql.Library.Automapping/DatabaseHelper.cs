using System.Collections.Generic;
using System.Data;

namespace Mirabeau.MsSql.Library.Automapping
{
    public class DatabaseHelper : Library.DatabaseHelper
    {
        private static readonly MsSqlHelperWithModelMapping SqlHelperWithModelMapping = new MsSqlHelperWithModelMapping();

        private DatabaseHelper()
        {
        }

        // TODO: Add all static calls to SqlHelperWithModelMapping.ExecuteReaderToModel.

        public static IEnumerable<TModel> ExecuteReaderToModel<TModel>(string connectionString, CommandType commandType, string commandText)
        {
            return SqlHelperWithModelMapping.ExecuteReaderToModel<TModel>(connectionString, commandType, commandText);

        }
    }
}
