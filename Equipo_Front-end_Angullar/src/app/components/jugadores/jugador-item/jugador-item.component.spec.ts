import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { JugadorItemComponent } from './jugador-item.component';

describe('JugadorItemComponent', () => {
  let component: JugadorItemComponent;
  let fixture: ComponentFixture<JugadorItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ JugadorItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(JugadorItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
