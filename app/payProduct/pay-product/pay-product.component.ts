import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Route } from '@angular/router';
import { switchAll } from 'rxjs';
import { Product, TreeAll } from 'src/app/Models/IProduct';
import { UserLogin } from 'src/app/Models/IUserModel';
import { ProductService } from 'src/app/services/product.service';
import { UserServiceService } from 'src/app/services/user-service.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-pay-product',
  templateUrl: './pay-product.component.html',
  styleUrls: ['./pay-product.component.css']
})
export class PayProductComponent implements OnInit {
  selectedPaymentMethodName ='';
  selectedPaymentMethod = new FormControl('');
  user: UserLogin;
  rawUser : any;
  public product : any=[];
  constructor(private productService: ProductService,private activeedRoute: ActivatedRoute,public userService: UserServiceService) { }

  ngOnInit(): void {
    this.productService.getProduct()
    .subscribe(res=>{
      this.product=res;
     })

    this.selectedPaymentMethod.valueChanges.subscribe((res: any)=>{
      if(res =='0') this.selectedPaymentMethodName='';
      else this.selectedPaymentMethodName = res.toString();

    });

    this.rawUser =localStorage.getItem('user');
    this.user = JSON.parse(this.rawUser);
    console.log("product "+this.user.AdminName);
  }
  successNotification(){
    Swal.fire('Successful Payment', 'Thank you for using the service.','success')
  }

}
