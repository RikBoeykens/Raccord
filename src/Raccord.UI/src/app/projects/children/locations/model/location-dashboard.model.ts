import { BaseModel } from '../../../../shared/model/base.model';
import { PagedData } from '../../../../shared/children/paging';
import { ScriptLocationSummary } from '../../../../shared/children/script-locations';
import { LocationSummary } from '../../..';

export class LocationDashboard extends BaseModel {
  public locations: PagedData<LocationSummary>;
  public scriptLocations: PagedData<ScriptLocationSummary>;

  constructor(
    obj?: {
      locations: PagedData<LocationSummary>,
      scriptLocations: PagedData<ScriptLocationSummary>
  }) {
    super();
    if (obj) {
      this.locations = obj.locations;
      this.scriptLocations = obj.scriptLocations;
    }
  }
}
