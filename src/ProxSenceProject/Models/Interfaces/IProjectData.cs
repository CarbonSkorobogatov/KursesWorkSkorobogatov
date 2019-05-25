/*
 * Данный интерфейс необходим для получения информации из БД.
 * Данный итерфейс включает в себя логику для сохранения и извлечения данных из хранилища.
 */

using System.Collections.Generic;

namespace ProxSenceProject.Models.Interfaces
{
    public interface IProjectData
    {
        // Получаем последовательность объектов, не извлекая какие-нибудь данные.
        IEnumerable<Project> ProjectData { get; }
        void SaveProject(Project project);
        Project DeleteProject(int projectId);
    }
}
