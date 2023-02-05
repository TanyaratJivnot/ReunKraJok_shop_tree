import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { User } from 'src/app/Models/IUserModel';
import { UserServiceService } from 'src/app/services/user-service.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  register!: FormGroup;
  constructor(private fb: FormBuilder,private userService: UserServiceService) { }

  ngOnInit(): void {
    this.register = this.fb.group({
      Name:[
        '',
        [
          Validators.required,
          Validators.minLength(2),
          Validators.pattern('[a-zA-A].*'),
        ]
      ],
      Email:['',[Validators.required, Validators.email]],
      Password:[
        '',
        [
          Validators.required,
          Validators.minLength(1),
          Validators.maxLength(10),
        ],
      ],
      Address:['',Validators.required],
      Zip:[
        '',
        [
          Validators.required,
          Validators.minLength(1),
          Validators.maxLength(5),
        ],
      ],
      Province:['',Validators.required],
      Tel:[
        '',
        [
          Validators.required,
          Validators.minLength(1),
          Validators.maxLength(10),
        ],
      ],
      Picture:['',Validators.required]
    });
  }
  regisbtn(){
    let user: User ={
      UserName: this.Fname.value,
      Email: this.Email.value,
      Password: this.Password.value,
      Address: this.Address.value,
      Province: this.Province.value,
      PostalCode: this.ZipCode.value,
      Tel: this.Telephone.value,
      userImg: this.Profile.value,
      IsActive: true
    };
    this.userService.registerUser(user).subscribe((res: any) =>{
      console.log(res);
    });
    
  }
  /* register geter */
  get Fname(): FormControl{
    return this.register.get('Name') as FormControl;
  }
  get Email(): FormControl{
    return this.register.get('Email') as FormControl;
  }
  get Password(): FormControl{
    return this.register.get('Password') as FormControl;
  }
  get Address(): FormControl{
    return this.register.get('Address') as FormControl;
  }
  get ZipCode(): FormControl{
    return this.register.get('Zip') as FormControl;
  }
  get Province(): FormControl{
    return this.register.get('Province') as FormControl;
  }
  get Telephone(): FormControl{
    return this.register.get('Tel') as FormControl;
  }
  get Profile(): FormControl{
    return this.register.get('Picture') as FormControl;
  }
   
  /* endregion */

}
