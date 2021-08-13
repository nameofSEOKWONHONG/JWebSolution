using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using eXtensionSharp;
using JServiceStack.Database;
using Microsoft.Data.SqlClient;
using NuGet.Frameworks;
using NUnit.Framework;
using RepoDb;
using RepoDb.Attributes;

namespace JServiceStack.Test
{
    public class JDatabaseTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task crud_test()
        {
            var newPersons = new List<Person>();
            var newPerson = new Person() { NAME = "TEST", AGE = 18 };
            newPersons.Add(newPerson);
            var insertedRows = await JDatabaseResolver.Resolve<SqlConnection>(TransactionScopeOption.Required)
                .ExecuteAsync(async db => await db.InsertAllAsync(newPersons));
            Assert.Greater(insertedRows, 0);

            var id = await JDatabaseResolver.Resolve<SqlConnection>(TransactionScopeOption.Required)
                .ExecuteAsync(async db =>
                {
                    var p1 = new Person() { NAME = "TEST2", AGE = 18 };
                    return await db.InsertAsync(p1);
                });
            Assert.Greater(id.xSafe<int>(), 0);
            
            var persons = await JDatabaseResolver.Resolve<SqlConnection>()
                .ExecuteAsync(async db => await db.QueryAllAsync<Person>());
            Assert.NotNull(persons);
            
            var person = await JDatabaseResolver.Resolve<SqlConnection>()
                .ExecuteAsync(async db => await db.QueryAsync<Person>(m => m.ID == 1));
            Assert.NotNull(person.First());
            Assert.AreEqual(person.First().AGE, 18);
            
            var deletedRow = await JDatabaseResolver.Resolve<SqlConnection>(TransactionScopeOption.Required)
                .ExecuteAsync(async db => await db.DeleteAsync<Person>(person));
            Assert.Greater(deletedRow, 0);
        }
    }

    internal class Person
    {
        [Primary]
        [Identity]
        public long ID { get; set; }
        [NotNull]
        public string NAME { get; set; }
        public int AGE { get; set; }
    }
}