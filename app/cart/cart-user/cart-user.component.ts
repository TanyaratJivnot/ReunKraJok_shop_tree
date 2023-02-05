import { ThisReceiver } from '@angular/compiler';
import { Component, Input, OnInit } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-cart-user',
  templateUrl: './cart-user.component.html',
  styleUrls: ['./cart-user.component.css']
})
export class CartUserComponent implements OnInit {
  public product : any=[];
  constructor(private cartServicr: ProductService) { }
  ngOnInit(): void {
  this.cartServicr.getProduct()
  .subscribe(res=>{
    this.product=res;
  })
  }
  removeProduct(products: any){
    this.cartServicr.removeCart(products);
  }

}
