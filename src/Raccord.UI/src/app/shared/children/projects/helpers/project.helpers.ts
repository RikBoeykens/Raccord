import { ProjectSummary } from '../model/project-summary.model';
import { StorageSettings } from '../../../settings/storage.settings';

export class ProjectHelpers {

  public static setCurrentProject(project: ProjectSummary) {
    localStorage.setItem(StorageSettings.CURRENTPROJECT, JSON.stringify(project));
  }

  public static getCurrentProject(): ProjectSummary {
    const currentProjectString = localStorage.getItem(StorageSettings.CURRENTPROJECT);
    if (currentProjectString) {
      return JSON.parse(currentProjectString);
    }
    return null;
  }

  public static resetCurrentProject() {
    localStorage.removeItem(StorageSettings.CURRENTPROJECT);
  }
}
