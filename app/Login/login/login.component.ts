import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { map } from 'rxjs';
import { User } from 'src/app/Models/IUserModel';
import { UserServiceService } from 'src/app/services/user-service.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  login!: FormGroup;
  message='';
  constructor(private fb: FormBuilder,private userService: UserServiceService) { }

  ngOnInit(): void {
    this.login = this.fb.group({
      Email:['',[Validators.required, Validators.email]],
      Password:[
        '',
        [
          Validators.required,
          Validators.minLength(1),
          Validators.maxLength(10),
        ],
      ],
    });
  }
 /*  loginbtn(){
    this.userService.loginUser()
    .subscribe((res:any)=>{
      if(res !== 'invalid'){
        this.message='Login Success.';
        console.log(res);
      }else{
        this.message='invalid Credentials.';
      }
    });
  } */
  get Email(): FormControl{
    return this.login.get('Email') as FormControl;
  }
  get Password(): FormControl{
    return this.login.get('Password') as FormControl;
  }

}
