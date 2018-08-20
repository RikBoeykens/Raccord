import { ProjectSummary } from '../../../../shared/children/projects';
import { Image } from '../../../../shared/children/images';

export class AdminProjectSummary extends ProjectSummary {
  public userCount: number;
  public invitationCount: number;

  constructor(obj?: {
    id: number,
    title: string,
    primaryImage: Image,
    userCount: number,
    invitationCount: number
  }) {
    super(obj);
    if (obj) {
      this.userCount = obj.userCount;
      this.invitationCount = obj.invitationCount;
    }
  }
}
