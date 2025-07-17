import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarroEdit } from './carro-edit';

describe('CarroEdit', () => {
  let component: CarroEdit;
  let fixture: ComponentFixture<CarroEdit>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarroEdit]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarroEdit);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
