import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CarroCreate } from './carro-create';

describe('CarroCreate', () => {
  let component: CarroCreate;
  let fixture: ComponentFixture<CarroCreate>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CarroCreate]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CarroCreate);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
