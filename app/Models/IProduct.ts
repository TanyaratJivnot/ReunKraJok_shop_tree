export interface IndoorProduct{
    TreeId : number;
    TreeName : string;
    TreeImg :string ;
    Cost : number;
    Temperature : string;
    Soil : string;
    Water : string;
    Sunlight : string;
    IsActive : boolean;
}
export interface OutdorProduct{
    TreeId : number;
    TreeName : string;
    TreeImg :string ;
    Cost : number;
    Temperature : string;
    Soil : string;
    Water : string;
    Sunlight : string;
    IsActive : boolean;
}
export class CategoryDropdown{
    CategoryName:string;
}
export class CategoryDropdowninout{
    CategoryName:string[];
}
export interface PriceDropdown{
    Nameprice:string;
}

export interface Category{
    CategoryId:number;
    CategoryName:string;
    IsActives:boolean;
}
export interface TypeTree{
    TypeId:number;
    TypeName:string;
    IsActives:boolean;
}

export class Product{
    treeId : number;
    treeName : string;
    treeImg :string ;
    cost : number;
    temperature : string;
    soil : string;
    water : string;
    sunlight : string;
    isActive : boolean;
}
export class Tree{
    treeId : number;
    treeName : string;
    treeImg :string ;
    cost : number;
    temperature : string;
    soil : string;
    water : string;
    sunlight : string;
    isActive : boolean;
}
export class TreeAll{
    treeId : number;
    treeName : string;
    treeImg :string ;
    cost : number;
    temperature : string;
    soil : string;
    water : string;
    sunlight : string;
    isActive : boolean;
}
export interface imgSlide{
    id:number;
    img:string;
    name:string;
}

export class editProduct{
    treeId : number;
    adminId : number;
    treeName : string;
    treeImg :string ;
    cost : number;
   typtree:number;
   catetree:number;
}
export class updateProduct{
    treeId : number;
    adminId : number;
    treeName : string;
    treeImg :string ;
    cost : number;
  sun:string;
   water:string;
   soil:string;
   isactive:boolean;
}