import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { editProduct, updateProduct } from '../Models/IProduct';
import { ProductService } from '../services/product.service';

@Component({
  selector: 'app-admin-updateproduct',
  templateUrl: './admin-updateproduct.component.html',
  styleUrls: ['./admin-updateproduct.component.css']
})
export class AdminUpdateproductComponent implements OnInit {
  form: FormGroup;
  constructor(private product: ProductService) { }

  ngOnInit(): void {
  }
  update(){
    let product: updateProduct={
      treeId: this.idT.value,
      adminId: this.adminT.value,
      treeName: this.nameT.value,
      treeImg: this.imgT.value,
      cost: this.costT.value,
      sun: this.sunT.value,
      water:this.waterT.value,
      soil: this.soildT.value,
      isactive: true
    };
    this.product.updateproduct(product).subscribe((res: any)=>{

    })
  }
  get idT(): FormControl{
    return this.form.get('TreeId') as FormControl;
  }
  get adminT(): FormControl{
    return this.form.get('admin') as FormControl;
  }
  get nameT(): FormControl{
    return this.form.get('Tname') as FormControl;
  }
  get costT(): FormControl{
    return this.form.get('Cost') as FormControl;
  }
  get sunT(): FormControl{
    return this.form.get('sun') as FormControl;
  }

  get soildT(): FormControl{
    return this.form.get('soild') as FormControl;
  }
  get waterT(): FormControl{
    return this.form.get('water') as FormControl;
  }
  get imgT(): FormControl{
    return this.form.get('img') as FormControl;
  }
}
