import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditHotelmanagementComponent } from './add-edit-hotelmanagement.component';

describe('AddEditHotelmanagementComponent', () => {
  let component: AddEditHotelmanagementComponent;
  let fixture: ComponentFixture<AddEditHotelmanagementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddEditHotelmanagementComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditHotelmanagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
