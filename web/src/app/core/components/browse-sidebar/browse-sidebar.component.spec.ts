import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BrowseSidebarComponent } from './browse-sidebar.component';

describe('SidebarComponent', () => {
  let component: BrowseSidebarComponent;
  let fixture: ComponentFixture<BrowseSidebarComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BrowseSidebarComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BrowseSidebarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
