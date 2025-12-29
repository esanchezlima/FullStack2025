import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthorListPageComponent } from './author-list-page.component';

describe('AuthorListPageComponent', () => {
  let component: AuthorListPageComponent;
  let fixture: ComponentFixture<AuthorListPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AuthorListPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AuthorListPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
