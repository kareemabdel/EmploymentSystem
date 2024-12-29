using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmploymentSystem.Domain.Entities.Comman
{
    [Table("AuditTrial")]
    public class AuditTrial:BaseEntity
    {
        public Guid ID { get; set; }
        public string KeyFieldID { get; set; }
        public DateTimeOffset DateTimeStamp { get; set; }
        public string DataModel { get; set; }
        public string ValueBefore { get; set; }
        public string ValueAfter { get; set; }
        public string Changes { get; set; }
        public int AuditActionType { get; set; }
        public string TableName { get; set; }
        public Guid UserId { get; set; }
    }
}
