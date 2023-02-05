import { Directive, HostListener, Input } from '@angular/core';
import { Router } from '@angular/router';

@Directive({
  selector: '[ProductDetail]',
})
export class ProductDetailDirective {
 @Input() producId: number =0;
  @HostListener('click') openProductDetail(){
    window.scrollTo(0,0);
    this.router.navigate(['/detailProduct'],{
      queryParams:{
        id: this.producId,
      },
    });
    
  }

  constructor(private router: Router) { }

}
