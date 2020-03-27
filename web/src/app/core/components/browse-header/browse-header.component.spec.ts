import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { BrowseHeaderComponent } from './browse-header.component';

describe('HeaderComponent', () => {
  let component: BrowseHeaderComponent;
  let fixture: ComponentFixture<BrowseHeaderComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ BrowseHeaderComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(BrowseHeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
