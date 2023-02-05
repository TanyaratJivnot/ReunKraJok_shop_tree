import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IndoorProductComponent } from './indoor-product.component';

describe('IndoorProductComponent', () => {
  let component: IndoorProductComponent;
  let fixture: ComponentFixture<IndoorProductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ IndoorProductComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(IndoorProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
