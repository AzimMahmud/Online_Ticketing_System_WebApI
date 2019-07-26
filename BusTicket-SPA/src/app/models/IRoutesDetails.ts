import { IBusRoute } from "./IBusRoute";
import { IVendor } from "./IVendor";
import { IBusCategory } from "./IBusCategory";

export interface IRoutesDetails {
  Routes?: IBusRoute[];
  Vendor?: IVendor[];
  BusCategory?: IBusCategory[];
}
