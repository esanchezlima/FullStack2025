import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AuthorEditInfoComponent } from './author-edit-info.component';

describe('AuthorEditInfoComponent', () => {
  let component: AuthorEditInfoComponent;
  let fixture: ComponentFixture<AuthorEditInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AuthorEditInfoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AuthorEditInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
