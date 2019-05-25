using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;//added by nvv 28.08.2017 20:16
using ProxSenceProject.Models.Interfaces;
using ProxSenceProject.Models;
using ProxSenceProject.Models.EntityFramework;
using System.Threading.Tasks;
using System.IO;
using ProxSenceProject.Models.PaginationModels;
using Microsoft.Net.Http.Headers;
//using Microsoft.AspNet.Http;

namespace ProxSenceProject.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private IProjectData projectData;
        EFDBContext _context;
        IHostingEnvironment _appEnvironment;
        public AdminController(IProjectData projectdata, EFDBContext context, IHostingEnvironment hostingenv)
        {
            projectData = projectdata;
            _context = context; //context = _context
            _appEnvironment = hostingenv; //hostingenv = _appEnvironment 
        }
        public ViewResult Index()
            => View(projectData.ProjectData);
        public ViewResult EditProject(int projectId)
            => View(new ProjectImagesViewModel
            {
                project = projectData.ProjectData.FirstOrDefault(a => a.ProjectId == projectId)
            });

       /* [HttpPost]
        public IActionResult EditProject(Project project)
        {
            if (ModelState.IsValid)
            {
                projectData.SaveProject(project);
                TempData["message"] = $"{project.ProjectName} был успешно сохранен";
                return RedirectToAction("Index");
            }
            else
            {
                return View(project);
            }
        }*/
        [HttpGet]
        public ViewResult CreateProject()
            => View("EditProject", new Project());
        [HttpPost]
        public IActionResult DeleteProject(int projectId)
        {
            Project deleteProject = projectData.DeleteProject(projectId);
            if(deleteProject != null)
            {
                TempData["message"] = $"{deleteProject.ProjectName} был успешно удален";
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProject(ProjectImagesViewModel projectImages)
        {
            Project project = projectImages.project;
            IFormFile Image = projectImages.ImageName;
            if (ModelState.IsValid)
            {
                if (Image != null && Image.Length > 0)
                {
                    var parsedContentDisposition = ContentDispositionHeaderValue.Parse(Image.ContentDisposition);
                    string FilePath = parsedContentDisposition.FileName.Trim('"');
                    string FileExtension = Path.GetExtension(FilePath);
                    //var uploadDir = _context.ProjectData + $@"/Images/{project.ProjectName}/";
                    var uploadDir = _appEnvironment.WebRootPath + $@"/Images/{project.ProjectName}/";
                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }
                    var imageUrl = uploadDir + project.ProjectName + FileExtension;

                    using (var stream = new FileStream(imageUrl, FileMode.Create))
                    {
                        Image.CopyTo(stream);
                    }

                    project.ImageName = Image.FileName;
                    project.ImagePath = imageUrl;
                }

                projectData.SaveProject(project);
                TempData["message"] = $"{project.ProjectName} был успешно сохранен";
                return RedirectToAction("Index");
            }
            else
            {
                return View(projectImages);
            }
        }
        /*[HttpPost]
        public IActionResult CreateProject(ProjectListViewModel pvm)
        {
            Project project = new Project { ImageName = pvm.ImageName };
            if (pvm.Image != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(pvm.Image.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)pvm.Image.Length);
                }
                // установка массива байтов
                project.Image = imageData;
            }
            _context.ProjectData.Add(project);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }*/
    }
 }