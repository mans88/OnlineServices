using OS.AttendanceServices.DataLayer.Entities;
using OnlineServices.Common.AttendanceServices.TransfertObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace OS.AttendanceServices.DataLayer.Extensions
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
                AttendeeId = transfertObject.AttendeeId.ToString(),
                CheckInTime = transfertObject.CheckInTime
            };
        }

        public static CheckInTO ToTransfertObject(this CheckInEntity entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            Guid LocalId;
            if (!Guid.TryParse(entity.RowKey, out LocalId))
                LocalId = Guid.Empty;

            var TO = new CheckInTO
            {
                Id = LocalId,
                SessionId = int.Parse(entity.PartitionKey),
                AttendeeId = int.Parse(entity.AttendeeId),
                CheckInTime = entity.CheckInTime
            };

            return TO;
        }
    }
}
