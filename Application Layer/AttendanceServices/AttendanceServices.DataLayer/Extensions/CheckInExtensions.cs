using AttendanceServices.DataLayer.Entities;
using OnlineServices.Common.AttendanceServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceServices.DataLayer.Extensions
{
    public static class CheckInExtensions
    {
        public static CheckInEntity ToTableEntity(this CheckInTO transfertObject)
        {
            if (transfertObject is null)
                throw new ArgumentNullException(nameof(transfertObject));

            return new CheckInEntity
            {
                RowKey = transfertObject.Id.ToString(),
                PartitionKey = transfertObject.SessionId.ToString(),
                AttendeeId = transfertObject.AttendeeId,
                CheckInTime = transfertObject.CheckInTime
            };
        }

        public static CheckInTO ToTransfertObject(this CheckInEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            Guid Id;
            if (!Guid.TryParse(entity.RowKey, out Id))
                Id = Guid.Empty;

            var TO = new CheckInTO
            {
                Id = Id,
                SessionId = int.Parse(entity.PartitionKey),
                AttendeeId = entity.AttendeeId,
                CheckInTime = entity.CheckInTime
            };

            return TO;
        }
    }
}
