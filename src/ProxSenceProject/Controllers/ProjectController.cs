/*
 * Основной контроллер для обработки контента на странице Project/ProjectList 
 */

using Microsoft.AspNetCore.Mvc;
using ProxSenceProject.Models.Interfaces;
using ProxSenceProject.Models.PaginationModels;
using System.Linq;


namespace ProxSenceProject.Controllers
{
    public class ProjectController : Controller
    {
        private IProjectData _projectData;
        public int PageSize = 3;
        public ProjectController(IProjectData projectData)
        {
            _projectData = projectData;
        }
        public ViewResult ProjectList(string category, int page = 1)
            => View(new ProjectListViewModel { 
                ProjectData = _projectData.ProjectData
                .Where(a => category == null || a.ProjectCategory == category)
                    .OrderBy(a => a.ProjectId)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? _projectData.ProjectData.Count() : _projectData.ProjectData.Where(a => a.ProjectCategory == category).Count()
                },
                CurrentCategory = category
           });
    }
}
