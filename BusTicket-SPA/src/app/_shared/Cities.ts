export interface Cities {
  name: string;
}

export class CityList {
  city: Cities[] = [
    { name: "Chittagong" },
    { name: "Dhaka" },
    { name: "Rajshahi" }
  ];
}

export class HomeCity {
  cities: string[] = ["Dhaka", "Chittagong", "Khulna", "Bogura", "Rajshahi"];
}
