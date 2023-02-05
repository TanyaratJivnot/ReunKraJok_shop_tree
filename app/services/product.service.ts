import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { editProduct, Product, TreeAll, TypeTree, updateProduct } from '../Models/IProduct';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  baseApiUrl: string = environment.baseApiUrl; 
  public cartItemList: any=[];
  user: editProduct[]=[];
  public productList = new BehaviorSubject<any>([]);

  constructor(private http: HttpClient) { }
  /* ประเภทต้นไม้ */
  getTypeList() {
    let url=this.baseApiUrl+'/Product/GetTreeTypeAll';
    return this.http.get<any[]>(url).pipe(
      map((treetyps)=>
      treetyps.map((treetyp)=>{
        let mapped : TypeTree={
          TypeId: treetyp.typeId,
          TypeName: treetyp.typeName,
          IsActives: treetyp.isActives,
        };
        return mapped;
      })
      )
    );
  }
  /* ต้นไม้ทั้งหมดเ */
  getTreeAll() {
    let url=this.baseApiUrl+'/Product/GetAllTree';
    return this.http.get<any[]>(url).pipe(
      map((treeAll)=>
      treeAll.map((tree)=>{
        let mapped : TreeAll={
          treeId: tree.treeId,
          treeName: tree.treeName,
          treeImg: tree.treeImg,
          cost: tree.cost,
          temperature: tree.temperature,
          soil: tree.soil,
          water: tree.waterd,
          sunlight: tree.sunlight,
          isActive: tree.isActive
        };
        return mapped;
      })
      )
    );
  }
  getTreIndoor() {
    let url=this.baseApiUrl+'/Product/GetDataTreeCatIndoor';
    return this.http.get<any[]>(url).pipe(
      map((treeAll)=>
      treeAll.map((tree)=>{
        let mapped : TreeAll={
          treeId: tree.treeId,
          treeName: tree.treeName,
          treeImg: tree.treeImg,
          cost: tree.cost,
          temperature: tree.temperature,
          soil: tree.soil,
          water: tree.waterd,
          sunlight: tree.sunlight,
          isActive: tree.isActive
        };
        return mapped;
      })
      )
    );
  }
  getTreOutdoor() {
    let url=this.baseApiUrl+'/Product/GetDataTreeHaveCatOutdoor';
    return this.http.get<any[]>(url).pipe(
      map((treeAll)=>
      treeAll.map((tree)=>{
        let mapped : TreeAll={
          treeId: tree.treeId,
          treeName: tree.treeName,
          treeImg: tree.treeImg,
          cost: tree.cost,
          temperature: tree.temperature,
          soil: tree.soil,
          water: tree.waterd,
          sunlight: tree.sunlight,
          isActive: tree.isActive
        };
        return mapped;
      })
      )
    );
  }
  /* ต้นไม้เเต่ละประเภท */
  getProductsAll(TypeName: string)
  {
    return this.http.get<any[]>(this.baseApiUrl+'/Product/GetProductsAll',{
      params: new HttpParams()
      .set('TypeName', TypeName)
    });
  }
  getProductsIndoor(TypeName: string)
  {
    return this.http.get<any[]>(this.baseApiUrl+'/Product/GetTreeTypeIndoo',{
      params: new HttpParams()
      .set('TypeName', TypeName)
    });
  }
  getProductsOutdoor(TypeName: string)
  {
    return this.http.get<any[]>(this.baseApiUrl+'/Product/GetTreeTypeOutdoor',{
      params: new HttpParams()
      .set('TypeName', TypeName)
    });
  }
 getProductAll(TreeId: number){
    let url = this.baseApiUrl +'/Product/GetProductTODetail/'+ TreeId;
    return this.http.get(url);
  }
  
  /* cart */
  getProduct(){
    return this.productList.asObservable();
  }
  setProduct(product: any){
    this.cartItemList.push(...product);
    this.productList.next(product);
  }
  addtoCart(product: any){
    this.cartItemList.push(product);
    this.productList.next(this.cartItemList);
  }
  Buyproduct(product: any){
    this.cartItemList.push(product);
    this.productList.next(this.cartItemList);
  }
  removeCart(product: any){
    this.cartItemList.map((a:any, index:any)=>{
      if(product.id==a.id){
        this.cartItemList.splice(index,1);
      }
    })
  }
  EditProduct(tree: editProduct){
    let url = this.baseApiUrl+"/Product/UpdateEditProduct";
    return this.http.put(url, tree,{responseType:'text'});
  }
  updateproduct(tree: updateProduct){
    let url = this.baseApiUrl+"/Product/CreateProductAdmin";
    return this.http.post(url, tree,{responseType:'text'});
  }
}
