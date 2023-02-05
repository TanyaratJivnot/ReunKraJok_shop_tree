import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { editProduct } from '../Models/IProduct';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-admin-editproduct',
  templateUrl: './admin-editproduct.component.html',
  styleUrls: ['./admin-editproduct.component.css']
})
export class AdminEditproductComponent implements OnInit {
  form: FormGroup= new FormGroup({
    NameT: new FormControl(),
    IdT: new FormControl(),
    cateT: new FormControl(),
    typeT: new FormControl(),
    imgT: new FormControl(),
    priceT: new FormControl(),
    admin: new FormControl(),
  });
  constructor(private http: HttpClient,private fb: FormBuilder) { }

  ngOnInit(): void {
  
  }
  
  edit(){
    console.log(this.form.value)
    /* this.http.put<any>('https://localhost:7078/Product/UpdateEditProduct?treeId='+this'&admin='+'&treeName='+'&Cost='+'&imgT='+'&typT='+'&category='+).subscribe((res: any)=>{
      this.form.IdT =res.id;
    }) */
  }
 
}
