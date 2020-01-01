import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EquipoItemComponent } from './equipo-item.component';

describe('EquipoItemComponent', () => {
  let component: EquipoItemComponent;
  let fixture: ComponentFixture<EquipoItemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EquipoItemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EquipoItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
