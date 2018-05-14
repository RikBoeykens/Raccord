import { EntityType } from '../../shared/enums/entity-type.enum';

export class CalendarHelpers {

  public static getColour(entityType: EntityType): any {
    if (entityType === EntityType.scheduleDay ||
      entityType === EntityType.shootingDay) {
      return {
        primary: '#e3bc08',
        secondary: '#FDF1BA'
      };
    }
    if (entityType === EntityType.callsheet) {
      return {
        primary: '#1e90ff',
        secondary: '#D1E8FF'
      };
    }
    if (entityType === EntityType.scene) {
      return {
        primary: '#1e90ff',
        secondary: '#D1E8FF'
      };
    }
  }
}
