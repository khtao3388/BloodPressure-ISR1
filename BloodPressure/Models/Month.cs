using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BloodPressure.Models
{
    public class Month
    {
        [Key]
        public int Id { get; set; }

        public int YearNumber { get; set; }

        public int MonthNumber { get; set; }
    }
}