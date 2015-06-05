using System.Data.Common;
using Mirabeau.Sql.Library.Automapping;

namespace Mirabeau.MySql.Library.Automapping
{
    public class MySqlHelperWithModelMapping : SqlHelperWithModelMapping
    {
        private readonly MySqlHelper _msSqlHelper = new MySqlHelper();

        public override DbConnection CreateConnection(string connectionString)
        {
            return _msSqlHelper.CreateConnection(connectionString);
        }

        public override DbCommand CreateCommand()
        {
            return _msSqlHelper.CreateCommand();
        }

        public override DbDataAdapter CreateDataAdapter(DbCommand command)
        {
            return _msSqlHelper.CreateDataAdapter(command);
        }
    }
}
