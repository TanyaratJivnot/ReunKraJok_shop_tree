import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product, TreeAll, TypeTree } from 'src/app/Models/IProduct';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  @Input() view: 'currcartitem'|'Ordertitem'|'product'='product';
  @Input() product: Product;
  
  
  constructor(private productService: ProductService,private activeedRoute: ActivatedRoute) { }
  
  ngOnInit(): void {
    console.log(this.product);

  }

}
