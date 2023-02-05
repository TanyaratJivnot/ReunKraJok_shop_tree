import { Component, Input, OnInit } from '@angular/core';
import { PageChangedEvent } from 'ngx-bootstrap/pagination';
import { imgSlide, Product, TreeAll } from 'src/app/Models/IProduct';
import { ProductService } from 'src/app/services/product.service';


@Component({
  selector: 'app-product-slide',
  templateUrl: './product-slide.component.html',
  styleUrls: ['./product-slide.component.css']
})
export class ProductSlideComponent implements OnInit {
  TreeAll:any;
  itemsPerSlide = 7;
  singleSlideOffset = true;
  noWrap = false;
  ontentArray = new Array(90).fill('');
  returnedArray?: string[];
  slidesChangeMessage = '';
  slides:imgSlide[]  = [];
  onSlideRangeChange(indexes: number[]|void): void {
    this.slidesChangeMessage = `Slides have been switched: ${indexes}`;
  }
  constructor(private productService:ProductService) { }

  ngOnInit(): void {
    this.ontentArray = this.ontentArray.map((v: string, i: number) => `Content line ${i + 1}`);
    this.returnedArray = this.ontentArray.slice(0, 10);
    this.productService.getTreeAll().subscribe((tree: TreeAll[])=>
    {
      for(let item of tree){
        this.slides.push({
          id:item.treeId,
          img:item.treeImg,
          name:item.treeName,
        })
      }
    }
    );
  }
  pageChanged(event: PageChangedEvent): void {
    const startItem = (event.page - 1) * event.itemsPerPage;
    const endItem = event.page * event.itemsPerPage;
    this.returnedArray = this.ontentArray.slice(startItem, endItem);
  }

}
