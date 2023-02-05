import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Product, TreeAll } from 'src/app/Models/IProduct';
import { ProductService } from 'src/app/services/product.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-adminproduct',
  templateUrl: './adminproduct.component.html',
  styleUrls: ['./adminproduct.component.css']
})
export class AdminproductComponent implements OnInit {
  products: Product[]=[];
  constructor(private productService: ProductService,private http: HttpClient,private activeedRoute: ActivatedRoute) { }

  ngOnInit(): void {
    this.productService.getTreeAll().subscribe((tree: TreeAll[])=>
    {
      this.products=tree;
      console.log(this.products);
    }
    );
   
    /* delete */
    
  }
  del(id:any){
    this.http.delete('https://localhost:7078/Product/deleteProduct?treeId='+id).subscribe(
      res=>{
        Swal.fire("Are you sure you want",
        "to delete this product?",);
      }
    )
  }
  edit(product : any){
    this.activeedRoute.params.subscribe(
      res => {
        this.productService.Buyproduct(product);
      }
    )
    console.log(product);
    
  }

}
