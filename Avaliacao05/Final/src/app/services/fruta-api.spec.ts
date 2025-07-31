import { TestBed } from '@angular/core/testing';

import { FrutaApi } from './fruta-api';

describe('FrutaApi', () => {
  let service: FrutaApi;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(FrutaApi);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
