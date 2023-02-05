import { Component, Input, OnInit } from '@angular/core';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { BsDropdownConfig } from 'ngx-bootstrap/dropdown';
import { CategoryDropdown, CategoryDropdowninout, PriceDropdown, Product, Tree, TreeAll, TypeTree } from 'src/app/Models/IProduct';
import { ProductService } from 'src/app/services/product.service';
import { ActivatedRoute } from '@angular/router';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-all-product',
  templateUrl: './all-product.component.html',
  styleUrls: ['./all-product.component.css'],
  providers: [{ provide: BsDropdownConfig, useValue: { isAnimated: true, autoClose: true } }]
})
export class AllProductComponent implements OnInit {
  categorylist:any;
  TreeAll:any;
  selected: string;
  serch: Tree[]=[];
  checkSearch = false;
  changCate(e:any){
    this.selected=e.target.value;
    this.productService.getProductsAll(this.selected).subscribe(
      (res: any)=> {
        this.products=res;
        this.TreeAll=[];
        
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
  constructor(private productService: ProductService,private activeedRoute: ActivatedRoute,private http: HttpClient) {
   }

  ngOnInit(): void {
    this.productService.getTypeList().subscribe((list: TypeTree[])=>{
      this.categorylist=list; 
    });

    this.productService.getTreeAll().subscribe((tree: TreeAll[])=>
    {
      this.TreeAll=tree;
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
