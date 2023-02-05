import { Component, Input, OnInit } from '@angular/core';
import { CategoryDropdown, CategoryDropdowninout, IndoorProduct, PriceDropdown, Product, Tree, TreeAll, TypeTree } from 'src/app/Models/IProduct';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { BsDropdownConfig } from 'ngx-bootstrap/dropdown';
import { ProductService } from 'src/app/services/product.service';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-indoor-product',
  templateUrl: './indoor-product.component.html',
  styleUrls: ['./indoor-product.component.css']
})
export class IndoorProductComponent implements OnInit {
  categorylist:any;
  selected: string;
  TreeIndoor:any;
  serch: Tree[]=[];
  checkSearch = false;
  changCate(e:any){
    this.selected=e.target.value;
    console.log(this.selected);
    this.productService.getProductsIndoor(this.selected).subscribe(
      (res: any)=> {
        this.products=res;
        this.TreeIndoor=[]
        console.log(this.products);
      }
    )
  }
  price:PriceDropdown[]=[
    {Nameprice:"ราคาปกติ"},
    {Nameprice:"ราคาสูง"},
    {Nameprice:"ราคาต่ำ"}
  ];
  @Input() TreeType : TypeTree ={
    TypeId: 0,
    TypeName: '',
    IsActives: false
  }
  @Input() count: number=3;
  products: Product[]=[];

  constructor(private productService: ProductService,private activeedRoute: ActivatedRoute,private http: HttpClient) { }
  
  ngOnInit(): void {
    this.productService.getTypeList().subscribe((list: TypeTree[])=>{
      this.categorylist=list; 
      console.log(this.categorylist);
    });

    this.productService.getTreIndoor().subscribe((tree: TreeAll[])=>
    {
      this.TreeIndoor=tree;
    }
    );
  }
  serchTree(nameTree : string){
    this.http.get<Tree[]>('https://localhost:7078/Product/serchProductAll?treeName='+nameTree).subscribe(
      res=>{
        this.serch = res;
        this.checkSearch= true;
        console.log(this.serch);
        console.log(this.checkSearch);
      }
    )
  }
  

}
