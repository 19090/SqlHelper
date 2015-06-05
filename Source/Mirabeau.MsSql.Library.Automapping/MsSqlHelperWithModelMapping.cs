using System.Data.Common;
using Mirabeau.Sql.Library.Automapping;

namespace Mirabeau.MsSql.Library.Automapping
{
    public class MsSqlHelperWithModelMapping : SqlHelperWithModelMapping
    {
        private readonly MsSqlHelper _msSqlHelper = new MsSqlHelper();

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
