import { HttpClient } from '@angular/common/http';
import { Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { RatingConfig } from 'ngx-bootstrap/rating';
import { Product, TreeAll } from 'src/app/Models/IProduct';
import { UserLogin } from 'src/app/Models/IUserModel';
import { ProductService } from 'src/app/services/product.service';
import { UserServiceService } from 'src/app/services/user-service.service';
@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css'],
})
export class ProductDetailsComponent implements OnInit {
  user: UserLogin;
  product:TreeAll={
    treeId: 0,
    treeName: '',
    treeImg: '',
    cost: 0,
    temperature: '',
    soil: '',
    water: '',
    sunlight: '',
    isActive: false
  };
  datailTree:any;
  countProduct=1;
  @Input() categoryName='ต้นไม้ยืนต้น ยืนต้น';
  max = 5;
  counter =1;
  reviweControl = new FormControl('');
  showError = false;
  reviweSaved = false;
  
  
  decrease(){
    if(this.counter-1 <100){
      this.counter=this.counter+1;
    }
   
  }
  Increase(){
     if(this.counter-1>=0){
      this.counter=this.counter-1;

    } 

  }
  constructor(private productService: ProductService,private activeedRoute: ActivatedRoute,private http:HttpClient,public userService: UserServiceService) { 
  }
  productList: any;
  rawUser : any;
  ngOnInit(): void {

    this.activeedRoute.queryParams.subscribe((params: any)=>{
      let id = params['id'];
      this.productService.getProductAll(id).subscribe((res: any)=>{
        this.product = res[0];
        console.log(this.product);
      }) 
    })
    this.rawUser =localStorage.getItem('user');
    this.user = JSON.parse(this.rawUser);
    console.log("product "+this.user.AdminName);
    this.productService.getProduct().subscribe(
      res=>{
        this.productList=res;
        this.productList.forEach((a:any) => {
          Object.assign(a,{quantity:1,total:a.cost});
        });
      }
    )
  } 
  addtocart(product : any){
    this.productService.addtoCart(product);
    console.log(product);
    
  }
  buy(product : any){
    this.activeedRoute.params.subscribe(
      res => {
        this.productService.Buyproduct(product);
      }
    )
    console.log(product);
    
  }
  sendReviwe(){
    let reviwe = this.reviweControl.value;
    if(reviwe == '' || reviwe == null){
      this.showError = true;
      return;
    }
    let userid = this.user.userId;
    this.userService.submitComment(userid,reviwe)
    .subscribe((res)=>{
      this.reviweSaved = true;
      this.reviweControl.setValue("");
      console.log(res);
    });
   
  }

}
/* https://localhost:7078/Product/GetTreeTypeAll */