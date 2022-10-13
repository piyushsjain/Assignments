import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdminApprovedComponent } from './admin-approved.component';

describe('AdminApprovedComponent', () => {
  let component: AdminApprovedComponent;
  let fixture: ComponentFixture<AdminApprovedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AdminApprovedComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AdminApprovedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
