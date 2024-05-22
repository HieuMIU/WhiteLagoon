namespace WhiteLagoon.Application.Common.DTOs
{
    public class RadialBarChartDto
    {
        public decimal TotalCount { get; set; }

        public decimal CountInCurrentMonth { get; set; }

        public bool HasRatioIncreased { get; set; }

        public decimal[] Series { get; set; } 
    }
}
