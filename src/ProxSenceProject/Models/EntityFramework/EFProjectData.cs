/*
 * Класс-хранилище
 */

using System.Collections.Generic;
using ProxSenceProject.Models.Interfaces;
using System.Linq;

namespace ProxSenceProject.Models.EntityFramework
{
    public class EFProjectData : IProjectData
    {
        private EFDBContext _context;
        public EFProjectData(EFDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Project> ProjectData 
            => _context.ProjectData;
        public void SaveProject(Project project)
        {
            if(project.ProjectId == 0)
            {
                _context.ProjectData.Add(project);
            }
            else
            {
                Project dbEntry = _context.ProjectData
                    .FirstOrDefault(a => a.ProjectId == project.ProjectId);
                if(dbEntry != null)
                {
                    dbEntry.ProjectName = project.ProjectName;
                    dbEntry.ProjectDescription = project.ProjectDescription;
                    dbEntry.ProjectPrice = project.ProjectPrice;
                    dbEntry.ProjectCategory = project.ProjectCategory;
                }
            }
            _context.SaveChanges();
        }
        public Project DeleteProject(int projectId)
        {
            Project dbEntry = _context.ProjectData
                    .FirstOrDefault(a => a.ProjectId == projectId);
            if(dbEntry != null)
            {
                _context.ProjectData.Remove(dbEntry);
                _context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
