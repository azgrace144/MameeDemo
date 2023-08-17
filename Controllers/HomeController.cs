// ----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.
// ----------------------------------------------------------------------------

namespace AppOwnsData.Controllers
{
    using AppOwnsData.DB;
    using AppOwnsData.Models;
    using AppOwnsData.ViewModels;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.PowerBI.Api.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class HomeController : Controller
    {
        public readonly AppDbcontext _dbcontext;

        public HomeController(AppDbcontext dbcontext)
        {
            this._dbcontext = dbcontext;
            Console.WriteLine("HomeController");
        }

        //public IActionResult Index()
        //{
        //    //int role_id = (int)TempData["roleId"];
        //    //var reportLists = await dbcontext.Reports.Where(report => report.role_id == roleId).ToListAsync();
        //    var reportLists = GetReportsByRole(1);
        //    Console.WriteLine(reportLists);

        //    return View();
        //}
        public IActionResult EmbedNewReport()
        {
            // Return the view, optionally passing the model
            return View();
        }

        public IActionResult Index(string email)
        {

            //var reports = await _dbcontext.Reports.Where(report => report.role_id == userId).ToListAsync();

            //Get Detail (Report and Role)
            var reportsAndRoles = _dbcontext.Reports
            .Join(
                _dbcontext.RoleReports,
                report => report.reportId,
                roleReport => roleReport.report_id,
                (report, roleReport) => new { Report = report, RoleReport = roleReport }
            )
            .Join(
                _dbcontext.Roles,
                joinedData => joinedData.RoleReport.role_id,
                role => role.rid,
                (joinedData, role) => new DetailReports { Reports = joinedData.Report, Roles = role }
            )
            .Where(joinedData => _dbcontext.UserRole
                .Where(ur => ur.user_id == email)
                .Select(ur => ur.role_id)
                .Contains(joinedData.Roles.rid)
            )
            .ToList();



            Console.WriteLine(reportsAndRoles);

            return View(reportsAndRoles);
        }

        public async Task<IActionResult> GetReportsByRole(int roleId)
        {
            using (var dbContext = _dbcontext)
            {
                try
                {
                    var reports = await dbContext.Reports.ToListAsync();

                    return (IActionResult)reports;
                }
                catch (Exception ex)
                {
                    // Handle exceptions or log errors here
                    // For example, return an error view or a custom error message
                    throw new Exception("Failed to retrieve reports: " + ex.Message);
                }
            }
        }

    }
}
