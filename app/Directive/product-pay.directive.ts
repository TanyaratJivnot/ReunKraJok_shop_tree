import { Directive, HostListener, Input } from '@angular/core';
import { Router } from '@angular/router';

@Directive({
  selector: '[ProductPay]'
})
export class ProductPayDirective {
  @Input() producId: number =0;
  @HostListener('click') openProductPay(){
    window.scrollTo(0,0);
    this.router.navigate(['/payProduct'],{
      queryParams:{
        id: this.producId,
      },
    });
    
  }

  constructor(private router: Router) { }

}
