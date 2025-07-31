import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FrutaIndex } from './fruta-index';

describe('FrutaIndex', () => {
  let component: FrutaIndex;
  let fixture: ComponentFixture<FrutaIndex>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FrutaIndex]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FrutaIndex);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
