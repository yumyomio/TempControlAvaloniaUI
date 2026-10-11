using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
namespace TempControlAvaloniaUI.Model
{
    public class ClimateData
    {
        public int ID { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Pressure { get; set; }
        public DateTime TimeStamp { get; set; } = DateTime.Now;
    }
    public class ClimateDbContext: DbContext
    {
        public DbSet<ClimateData> ClimateDatas {  get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Climate.db");
        }

    }
}
