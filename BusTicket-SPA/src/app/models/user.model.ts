export interface User {
  id: number;
  userName: string;
  dateOfBirth: number;
  gender: string;
  created: Date;
  address: string;
  roles?: string[];
}
