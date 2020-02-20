using Microsoft.WindowsAzure.Storage.Table;
using OnlineServices.Common.DataAccessHelpers;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OS.AttendanceServices.DataLayer.Entities
{
    public class CheckInEntity : TableEntity
    {
        //PARTITION KEY: public int SessionID { get; set; }
        //ROW KEY: public int Id { get; set; }
        public string AttendeeId { get; set; }
        public DateTime CheckInTime { get; set; }
    }
}