import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OutdoorProductComponent } from './outdoor-product.component';

describe('OutdoorProductComponent', () => {
  let component: OutdoorProductComponent;
  let fixture: ComponentFixture<OutdoorProductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OutdoorProductComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(OutdoorProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
