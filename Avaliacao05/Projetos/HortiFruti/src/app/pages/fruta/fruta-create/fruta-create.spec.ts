import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FrutaCreate } from './fruta-create';

describe('FrutaCreate', () => {
  let component: FrutaCreate;
  let fixture: ComponentFixture<FrutaCreate>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FrutaCreate]
    })
    .compileComponents();

    fixture = TestBed.createComponent(FrutaCreate);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
