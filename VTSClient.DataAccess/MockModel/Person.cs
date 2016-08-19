using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTSClient.DataAccess.MockModel
{
    [Table("Person")]
    public class Person
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }

        public string FullName { get; set; }

        public float VacationDays { get; set; }

        public float SickDays { get; set; }

        public float Overtime { get; set; }

    }
}
