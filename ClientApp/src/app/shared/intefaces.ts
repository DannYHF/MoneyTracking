export interface Cost {
  id?:string;
  categoryName:string;
  amountOfMoney:number;
  CreateDate:Date;
}

export interface DonutChartCategory {
  name:string;
  value:number;
}

export interface LastCostsItem {
  categoryName:string;
  amount:number;
}
//Entity
export interface Transaction {
  id:string;
  spent:number;
  creationTime:Date;
  category:Category
}
export interface Category {
  id:string;
  imageName:string;
  name:string;
}
// Auth models
export interface AuthorizationResponse {
  id:string;
  token:string;
}

export interface LoginRequest {
  email:string;
  password:string;
}

export interface RegisterRequest {
  email:string;
  password:string;
  confirmPassword:string;
  lastName:string;
  firstName:string;
}
