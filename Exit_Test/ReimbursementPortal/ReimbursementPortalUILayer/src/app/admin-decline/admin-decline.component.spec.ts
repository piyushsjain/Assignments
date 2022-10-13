import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminDeclineComponent } from './admin-decline.component';

describe('AdminDeclineComponent', () => {
  let component: AdminDeclineComponent;
  let fixture: ComponentFixture<AdminDeclineComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminDeclineComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminDeclineComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
