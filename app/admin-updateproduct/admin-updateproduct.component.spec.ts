import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminUpdateproductComponent } from './admin-updateproduct.component';

describe('AdminUpdateproductComponent', () => {
  let component: AdminUpdateproductComponent;
  let fixture: ComponentFixture<AdminUpdateproductComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminUpdateproductComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AdminUpdateproductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
