import { IBusDetails } from "./IBusDetails";
import { IBrand } from "./IBrand";
import { IBusCategory } from "./IBusCategory";
import { IVendor } from "./IVendor";

export interface IBusRoute {
  routeId: number;
  boardPoint: string;
  boardTime: any;
  dropPoint: string;
  dropTime: any;
  busDetailId: number;
  fare: any;
}
