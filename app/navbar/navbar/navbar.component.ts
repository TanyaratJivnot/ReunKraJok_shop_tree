import { Component, ElementRef, OnInit, Type, ViewChild, ViewContainerRef } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { LoginComponent } from 'src/app/Login/login/login.component';
import { User, UserLogin } from 'src/app/Models/IUserModel';
import { RegisterComponent } from 'src/app/Register/register/register.component';
import { UserServiceService } from 'src/app/services/user-service.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  @ViewChild('modal-title') modalTitle!: ElementRef;
  @ViewChild('container', {read: ViewContainerRef, static: true})
  container!: ViewContainerRef;
  login!: FormGroup;
  cartItems: number = 0;
  model: UserLogin={
    adminId: 0,
    adminImg: '',
    AdminName: '',
    userId: 0,
    userName: '',
    email: '',
    password: '',
    address: '',
    province: '',
    postalCode: '',
    tel: '',
    userImg: '',
    isActive: false
  };
  rawUser: any;

  loggedIn=false;
  logAdmin = false;
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

    if(localStorage.getItem('user') != null || localStorage.getItem('user') != undefined){
      this.rawUser =localStorage.getItem('user');
      this.model = JSON.parse(this.rawUser);
      if(this.model.userImg != null || this.model.userImg != undefined || this.model.adminImg != null || this.model.adminImg != undefined)
      {
        this.loggedIn = true;
      }else{
        
        this.model.adminId=0;
        console.log(this.model.adminId);
      }

      console.log("product "+this.model);
    }
  }
  
  openModel(name: string){
    this.container.clear(); 
    let componentType!: Type<any>;
    if(name == 'register')componentType=RegisterComponent;
    this.container.createComponent(componentType);
  }
  loginbtn(){
    console.log(this.Email.value+this.Password.value);
    this.userService.loginUser(this.Email.value,this.Password.value).subscribe((res: any)=>{
      console.log(res);
      if(res !== 'invalid'){
        this.loggedIn=true;
        this.model=JSON.parse(res);
        localStorage.setItem('user' , JSON.stringify(this.model))
        console.log(this.model.userImg);
        console.log(this.model);
      }else{
      }
    })
  }
  logout(){
    this.loggedIn = false;
    localStorage.removeItem('user');
    window.location.reload();
  }
  get Email(): FormControl{
    return this.login.get('Email') as FormControl;
  }
  get Password(): FormControl{
    return this.login.get('Password') as FormControl;
  }
}
