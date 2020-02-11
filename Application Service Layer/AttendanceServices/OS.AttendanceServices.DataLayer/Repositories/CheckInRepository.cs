using OS.AttendanceServices.DataLayer.Entities;
using OS.AttendanceServices.DataLayer.Extensions;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Table;
using OnlineServices.Common.AttendanceServices.Interfaces;
using OnlineServices.Common.AttendanceServices.TransfertObjects;
using OnlineServices.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OS.AttendanceServices.DataLayer.Repositories
{
    public class CheckInRepository : ICheckInRepository
    {
        private AzureStorageCredentials azureStorageCredentials;
        public CheckInRepository(AzureStorageCredentials azureStorageCredentials)
        {

            this.azureStorageCredentials = azureStorageCredentials ?? throw new ArgumentNullException(nameof(azureStorageCredentials));
        }

        public CloudTable CheckInTable()
        {
            try
            {
                StorageCredentials creds = new StorageCredentials(azureStorageCredentials.AccountName.Base64Decode(), azureStorageCredentials.AccountKey.Base64Decode());
                CloudStorageAccount account = new CloudStorageAccount(creds, useHttps: true);

                CloudTableClient client = account.CreateCloudTableClient();

                CloudTable table = client.GetTableReference("AttendanceCheckIn");

                return table;
            }
            catch
            {
                return null;
            }
        }

        public CheckInTO Add(CheckInTO transfertObject)
        {
            if (transfertObject is null)
                throw new ArgumentNullException(nameof(transfertObject));

            var table = this.CheckInTable();
            if (table is null)
                throw new ArgumentNullException(nameof(table));

            transfertObject.Id = Guid.NewGuid();
            var entity = transfertObject.ToTableEntity();

            TableOperation insert = TableOperation.Insert(entity);

            try
            {

                table.ExecuteAsync(insert);
                return entity.ToTransfertObject();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        public bool Remove(CheckInTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Remove(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CheckInTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<CheckInTO> GetCheckInsInSession(int SessionId)
        {
            var condition = TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, $"{SessionId}");
            var query = new TableQuery<CheckInEntity>().Where(condition);

            var table = this.CheckInTable();
            if (table is null)
                throw new ArgumentNullException(nameof(table));

            var lst = table.ExecuteQuerySegmentedAsync(query, new TableContinuationToken()).Result.Results;

            return lst.Select(x => x.ToTransfertObject()).ToList();
        }

        public List<CheckInTO> GetAttendeeCheckIns(int AttendeeId)
        {
            var condition = TableQuery.GenerateFilterCondition("AttendeeId", QueryComparisons.Equal, $"{AttendeeId}");
            var query = new TableQuery<CheckInEntity>().Where(condition);
            //var query = new TableQuery<CheckInEntity>().Where($"AttendeeId <> {AttendeeId}");

            var table = this.CheckInTable();
            if (table is null)
                throw new ArgumentNullException(nameof(table));

            var lst = table.ExecuteQuerySegmentedAsync(query, new TableContinuationToken()).Result.Results;

            return lst.Select(x => x.ToTransfertObject()).ToList();
        }

        public CheckInTO Update(CheckInTO Entity)
        {
            throw new NotImplementedException();
        }


        //private static bool DoesUsernameExist(string username, CloudTable table)
        //{
        //    TableOperation entity = TableOperation.Retrieve("Username", username);

        //    var result = table.Execute(entity);

        //    if (result.Result != null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //public static string ValidateUsername(string username, string email)
        //{
        //    var table = AuthTable();

        //    var exists = DoesUsernameExist(username, table);

        //    if (exists)
        //    {
        //        return "Username Taken";
        //    }

        //    var success = CreateEntity(email, username, table);

        //    if (success)
        //    {
        //        return "Username Registered";
        //    }
        //    else
        //    {
        //        return "Error";
        //    }

        //}
    }
}
