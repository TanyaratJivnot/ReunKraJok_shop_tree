import { Directive, HostListener, Input } from '@angular/core';
import { Route, Router } from '@angular/router';
import { Category, CategoryDropdown, IndoorProduct, OutdorProduct, PriceDropdown, Product, TypeTree } from '../Models/IProduct';

@Directive({
  selector: '[OpenProduct]'
})
export class OpenProductDirective {
  @Input() cateDropdown:CategoryDropdown={
    CategoryName: ''
  }
  @Input() price:PriceDropdown={
    Nameprice: ''
  }
 @Input() type: TypeTree={
   TypeId: 0,
   TypeName: '',
   IsActives: true,
 }

  @HostListener('click') openProduct() {
    this.router.navigate(['/allplant'],{
      queryParams:{
        CategoryName:this.cateDropdown.CategoryName,
      },
    });
  }

  constructor(private router: Router) { }

}
