import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MotoIndex } from './moto-index';

describe('MotoIndex', () => {
  let component: MotoIndex;
  let fixture: ComponentFixture<MotoIndex>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MotoIndex]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MotoIndex);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
