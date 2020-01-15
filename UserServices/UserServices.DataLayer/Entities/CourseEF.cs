using OnlineServices.Common.DataAccessHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistrationServices.DataLayer.Entities
{
    [Table("Course")]
    public class CourseEF : IEntity<int>
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}