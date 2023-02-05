import { Component, Input, OnInit } from '@angular/core';
import { CategoryDropdowninout, OutdorProduct, PriceDropdown, Product, Tree, TreeAll, TypeTree } from 'src/app/Models/IProduct';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { BsDropdownConfig } from 'ngx-bootstrap/dropdown';
import { ProductService } from 'src/app/services/product.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-outdoor-product',
  templateUrl: './outdoor-product.component.html',
  styleUrls: ['./outdoor-product.component.css']
})
export class OutdoorProductComponent implements OnInit {
  categorylist:any;
  selected: string;
  TreeOutdoor:any;
  serch: Tree[]=[];
  checkSearch = false;
  changCate(e:any){
    this.selected=e.target.value;
    console.log(this.selected);
    this.productService.getProductsOutdoor(this.selected).subscribe(
      (res: any)=> {
        this.products=res;
        this.TreeOutdoor=[]
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
  constructor(private productService: ProductService,private http: HttpClient) { }

  ngOnInit(): void {
    this.productService.getTypeList().subscribe((list: TypeTree[])=>{
      this.categorylist=list; 
      console.log(this.categorylist);
    });

    this.productService.getTreOutdoor().subscribe((tree: TreeAll[])=>
    {
      this.TreeOutdoor=tree;
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
