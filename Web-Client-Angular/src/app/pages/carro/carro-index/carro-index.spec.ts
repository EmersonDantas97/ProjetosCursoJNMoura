import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarroIndex } from './carro-index';

describe('CarroIndex', () => {
  let component: CarroIndex;
  let fixture: ComponentFixture<CarroIndex>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarroIndex]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarroIndex);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
