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
