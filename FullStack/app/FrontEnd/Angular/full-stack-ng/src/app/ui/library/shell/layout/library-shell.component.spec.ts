import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LibraryShellComponent } from './library-shell.component';

describe('LibraryShellComponent', () => {
  let component: LibraryShellComponent;
  let fixture: ComponentFixture<LibraryShellComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LibraryShellComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(LibraryShellComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
