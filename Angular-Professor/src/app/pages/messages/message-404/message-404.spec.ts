import { ComponentFixture, TestBed } from '@angular/core/testing';

import { Message404 } from './message-404';

describe('Message404', () => {
  let component: Message404;
  let fixture: ComponentFixture<Message404>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [Message404]
    })
    .compileComponents();

    fixture = TestBed.createComponent(Message404);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
