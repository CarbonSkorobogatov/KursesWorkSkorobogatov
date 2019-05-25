using Microsoft.AspNetCore.Mvc;
using System.Linq;
using ProxSenceProject.Models.Interfaces;

namespace ProxSenceProject.Components
{
    public class NavigationViewComponent : ViewComponent
    {
            private IProjectData _projectData;

            public NavigationViewComponent(IProjectData projectData)
            {
                _projectData = projectData;
            }

            public IViewComponentResult Invoke()
            {
                ViewBag.SelectedCategory = RouteData?.Values["category"];
                return View(_projectData.ProjectData
                    .Select(x => x.ProjectCategory)
                    .Distinct()
                    .OrderBy(x => x));
            }
    }
}
