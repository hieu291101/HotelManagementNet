import { TestBed } from '@angular/core/testing';

import { HotelmanagementApiService } from './hotelmanagement-api.service';

describe('HotelmanagementApiService', () => {
  let service: HotelmanagementApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HotelmanagementApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
