import { EntityType } from '../../shared/enums/entity-type.enum';

export class CalendarHelpers {

  public static getColour(entityType: EntityType): any {
    if (entityType === EntityType.scheduleDay ||
      entityType === EntityType.callsheet ||
      entityType === EntityType.shootingDay) {
        return {
          primary: '#ad2121',
          secondary: '#FAE3E3'
        };
      }
  }
}
