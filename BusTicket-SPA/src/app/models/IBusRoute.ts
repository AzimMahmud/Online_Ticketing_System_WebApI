import { IBusDetails } from "./IBusDetails";

export interface IBusRoute {
  routeId: number;
  boardPoint: string;
  boardTime: any;
  dropPoint: string;
  dropTime: any;
  busDetailId: number;
  fare: any;
  busDetails: IBusDetails[];
}
