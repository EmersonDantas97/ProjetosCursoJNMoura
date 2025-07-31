import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FrutaEdit } from './fruta-edit';

describe('FrutaEdit', () => {
  let component: FrutaEdit;
  let fixture: ComponentFixture<FrutaEdit>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FrutaEdit]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FrutaEdit);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
