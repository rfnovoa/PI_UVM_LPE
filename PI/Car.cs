using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PI;

public class Car
{
    public int Id { get; set; }
    public string Make { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public int Year { get; set; } = 0;
    public string VIN { get; set; } = string.Empty;
    public double Mileage { get; set; } = double.MinValue;
    public string Color { get; set; } = string.Empty;
    public bool IsAvailable { get; set; } = true;
    public string LicensePlate { get; set; } = string.Empty;
    public DateTime DateAcquired { get; set; } = DateTime.Now;
}
