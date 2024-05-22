using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiteLagoon.Application.Common.DTOs;

namespace WhiteLagoon.Application.Services.Interfaces
{
    public interface IDashboardService
    {
        Task<RadialBarChartDto> GetTotalBookingRadialChartData();

        Task<RadialBarChartDto> GetRegisteredUserRadialChartData();

        Task<RadialBarChartDto> GetTotalRevenueRadialChartData();

        Task<PieChartDto> GetBookingPieChartData();

        Task<LineChartDto> GetMemberAndBookingLineChartData();
    }
}
