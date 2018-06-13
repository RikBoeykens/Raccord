import { RouteInfo, EntityType, RouteSettings } from '..';

export class RouteHelpers {

  public static getRouteArray(routeInfo: RouteInfo): any[] {
    if (routeInfo.type === EntityType.project) {
      return [
        RouteSettings.PROJECTS,
        routeInfo.routeIDs[0]
      ];
    }
    if (routeInfo.type === EntityType.scene) {
      return [
        RouteSettings.PROJECTS,
        routeInfo.routeIDs[0],
        RouteSettings.SCENES,
        routeInfo.routeIDs[1]
      ];
    }
    if (routeInfo.type === EntityType.scriptLocation) {
      return [
        RouteSettings.PROJECTS,
        routeInfo.routeIDs[0],
        RouteSettings.SCRIPTLOCATIONS,
        routeInfo.routeIDs[1]
      ];
    }
    if (routeInfo.type === EntityType.image) {
      return [
        RouteSettings.PROJECTS,
        routeInfo.routeIDs[0],
        RouteSettings.IMAGES,
        routeInfo.routeIDs[1]
      ];
    }
    if (routeInfo.type === EntityType.character) {
      return [
        RouteSettings.PROJECTS,
        routeInfo.routeIDs[0],
        RouteSettings.CHARACTERS,
        routeInfo.routeIDs[1]
      ];
    }
    if (routeInfo.type === EntityType.breakdownItem) {
      return [
        RouteSettings.PROJECTS,
        routeInfo.routeIDs[0],
        RouteSettings.BREAKDOWNS,
        routeInfo.routeIDs[1],
        RouteSettings.ITEMS,
        routeInfo.routeIDs[2]
      ];
    }
    if (routeInfo.type === EntityType.location) {
      return [
        RouteSettings.PROJECTS,
        routeInfo.routeIDs[0],
        RouteSettings.LOCATIONS,
        routeInfo.routeIDs[1]];
    }
    if (routeInfo.type === EntityType.slate) {
      return [
        RouteSettings.PROJECTS,
        routeInfo.routeIDs[0],
        RouteSettings.SLATES,
        routeInfo.routeIDs[1]
      ];
    }
    if (routeInfo.type === EntityType.crewMember) {
      return [
        RouteSettings.PROJECTS,
        routeInfo.routeIDs[0],
        RouteSettings.UNITLISTS,
        routeInfo.routeIDs[1]
      ];
    }
    if (routeInfo.type === EntityType.castMember) {
      return [
        RouteSettings.PROJECTS,
        routeInfo.routeIDs[0],
        RouteSettings.CAST,
        routeInfo.routeIDs[1]
      ];
    }
    if (routeInfo.type === EntityType.scheduleDay) {
      return [
        RouteSettings.PROJECTS,
        routeInfo.routeIDs[0],
        RouteSettings.SCHEDULING,
        routeInfo.routeIDs[1]
      ];
    }
    if (routeInfo.type === EntityType.callsheet) {
      return [
        RouteSettings.PROJECTS,
        routeInfo.routeIDs[0],
        RouteSettings.CALLSHEETS,
        routeInfo.routeIDs[1]
      ];
    }
    if (routeInfo.type === EntityType.shootingDay) {
      return [
        RouteSettings.PROJECTS,
        routeInfo.routeIDs[0],
        RouteSettings.SHOOTINGDAYS,
        routeInfo.routeIDs[1]
      ];
    }
  }
}
