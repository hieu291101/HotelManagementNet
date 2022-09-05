import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowHotelmanagementComponent } from './show-hotelmanagement.component';

describe('ShowHotelmanagementComponent', () => {
  let component: ShowHotelmanagementComponent;
  let fixture: ComponentFixture<ShowHotelmanagementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowHotelmanagementComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowHotelmanagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
