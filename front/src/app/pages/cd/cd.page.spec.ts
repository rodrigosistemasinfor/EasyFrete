import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { cdPage } from './cd.page';

describe('cd.PageComponent', () => {
  let component: cdPage;
  let fixture: ComponentFixture<cdPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ cdPage ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(cdPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
