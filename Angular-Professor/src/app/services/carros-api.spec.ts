import { TestBed } from '@angular/core/testing';

import { CarrosApi } from './carros-api';

describe('CarrosApi', () => {
  let service: CarrosApi;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CarrosApi);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
