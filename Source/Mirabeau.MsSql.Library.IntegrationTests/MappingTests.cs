using System.Collections.Generic;
using System.Data;
using System.Linq;
using AutoMapper;
using Mirabeau.MsSql.Library.Automapping;
using Mirabeau.Sql.Library;
using Mirabeau.Sql.Library.Automapping;
using NUnit.Framework;

namespace Mirabeau.MsSql.Library.IntegrationTests
{
    [TestFixture, Explicit("Requires SQL-server master database.")]
    public class MappingTests
    {
        private const string Connectionstring = "Server=TEST-DB1;Database=master;Integrated Security=true";
        private readonly ISqlHelperWithModelMapping _sqlHelper = new MsSqlHelperWithModelMapping();

        [Test]
        public void ShouldPerformDynamicMapWhenMappingNotDefined()
        {
            Mapper.Reset();
            var rows = _sqlHelper.ExecuteReaderToModel<Tables>(Connectionstring, CommandType.Text,
                "SELECT * FROM INFORMATION_SCHEMA.TABLES");

            Assert.That(rows, Has.Count.GreaterThan(0));
            Assert.That(rows.First().TABLE_SCHEMA, Is.Not.Empty);
        }

        [Test]
        public void ShouldPerformMapWhenMappingDefined()
        {
            Mapper.Reset();
            Mapper.CreateMap<IDataRecord, Tables>().ForMember(dest => dest.TableName,
                options => options.MapFrom(src => src["TABLE_NAME"].GetDbValueOrNullForReferenceType<string>()));

            var rows = _sqlHelper.ExecuteReaderToModel<Tables>(Connectionstring, CommandType.Text, "SELECT * FROM INFORMATION_SCHEMA.TABLES");

            Assert.That(rows, Has.Count.GreaterThan(0));
            Tables row = rows.First();
            Assert.That(row.TABLE_SCHEMA, Is.Not.Empty);
            Assert.That(row.TableName, Is.Not.Empty);
        }

        [Test]
        public async void ShouldPerformAsyncMapWhenMappingDefined()
        {
            Mapper.Reset();
            Mapper.CreateMap<IDataRecord, Tables>().ForMember(dest => dest.TableName,
                options => options.MapFrom(src => src["TABLE_NAME"].GetDbValueOrNullForReferenceType<string>()));

            IEnumerable<Tables> rows =
                await
                    _sqlHelper.ExecuteReaderToModelAsync<Tables>(Connectionstring, CommandType.Text,
                        "SELECT * FROM INFORMATION_SCHEMA.TABLES");

            Assert.That(rows, Has.Count.GreaterThan(0));
            Tables row = rows.First();
            Assert.That(row.TABLE_SCHEMA, Is.Not.Empty);
            Assert.That(row.TableName, Is.Not.Empty);
        }
    }
}
