export interface User {
   UserName :string;
   Email :string;
   Password :string;
   Address :string;
   Province :string;
   PostalCode :string;
   Tel :string;
   userImg :string;
   IsActive :boolean;
}
export interface UserLogin {
   adminId:number; 
   adminImg: string;
   AdminName: string;
   userId : number;
   userName :string;
   email :string;
   password :string;
   address :string;
   province :string;
   postalCode :string;
   tel :string;
   userImg :string;
   isActive :boolean;
}