import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../Models/IUserModel';

@Injectable({
  providedIn: 'root'
})
export class UserServiceService {
  baseApiUrl: string = environment.baseApiUrl; 
 user: User[]=[];

  constructor(private http: HttpClient) { }
  registerUser(user: User){
    let url = this.baseApiUrl+"/User/RegisterUser";
    return this.http.post(url, user,{responseType: 'text'});
  }
  
  loginUser(email: string, password: string){
    let url = this.baseApiUrl+"/User/LoginUser";
    return this.http.post(url,{email: email,password:password},{responseType:'text'});
  }
  
  
  submitComment(userid: number, comment: string){
    let obj: any ={
      UserId:{
        Id: userid,
      },
      Comment: comment,
    };
    let url = this.baseApiUrl+'/User/commentProduct';
    return this.http.post(url,obj,{responseType: 'text'});
  }
}
