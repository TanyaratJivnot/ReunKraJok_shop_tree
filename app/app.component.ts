import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { User } from './Models/IUserModel';
import { UserServiceService } from './services/user-service.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
 title = 'ClentProjectReunKraJok';
/*  users: any; */
 constructor(private http: HttpClient,private userService: UserServiceService){

 }
  ngOnInit(): void {
  /*  this.getUser();
   this.setCurrenUser(); */
  }
 /*  getUser(){
    this.http.get('').subscribe({
      next: respon=>this.users = respon,
      error: error=> console.log(error),
      complete:()=>console.log('request has complete')
    })
  }
 setCurrenUser(){
  const userString=localStorage.getItem('user');
  if(!userString) return;
  const user: User=JSON.parse(userString);
  this.userService.setCurrentUser(user);
 } */

 
}
