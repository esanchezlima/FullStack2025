import { Component, Input, OnInit, inject } from '@angular/core';
import { Router, RouterLink, RouterOutlet } from '@angular/router';
import { AuthorModel } from '../../../../../business/application/models/authors/author.model';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatSnackBar, MatSnackBarConfig, MatSnackBarModule } from '@angular/material/snack-bar';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { GetGenresUseCase } from '../../../../../business/application/use-cases/get-genres.use-case';
import { MatSelectModule } from '@angular/material/select';
import { AsyncPipe } from '@angular/common';
import { UpdateAuthorUseCase } from '../../../../../business/application/use-cases/update-author.use-case';
import { MatButtonModule } from '@angular/material/button';
import { CreateAuthorUseCase } from '../../../../../business/application/use-cases/create-author.use-case';

@Component({
  selector: 'app-author-edit-page',
  standalone: true,
  imports: [
    RouterOutlet,
    RouterLink,
    AsyncPipe,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatSelectModule,
    MatSnackBarModule,
    MatButtonModule,
    ReactiveFormsModule
  ],
  templateUrl: './author-edit-page.component.html',
  styleUrl: './author-edit-page.component.scss'
})
export class AuthorEditPageComponent implements OnInit{
  @Input() authorId!: string;
  @Input() author!: AuthorModel;

  public authorForm = inject(FormBuilder).group({
    authorId: [{ value: '', disabled: true }],
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    dateOfBirth: [new Date(), Validators.required],
    genre: ['', Validators.required]
  });

  public genres = inject(GetGenresUseCase).execute();
  public updateAuthorUseCase = inject(UpdateAuthorUseCase);
  public createAuthorUseCase = inject(CreateAuthorUseCase);

  public router = inject(Router);
  private snackBar = inject(MatSnackBar);
  private configSnackBar = new MatSnackBarConfig();

  ngOnInit(): void {
    this.setFormValues(this.author);
    this.configSnackBar.duration = 3000;
  }

  private setFormValues(author: AuthorModel) {
    if (author) {      
      this.authorForm.setValue({
        authorId: author.authorId,
        firstName: author.firstName,
        lastName: author.lastName,
        dateOfBirth: author.dateOfBirth,
        genre: author.genre
      });
    }
  }

  public async saveAuthor() {
    const authorModel = this.getFormValues(this.authorForm);

    if(this.authorId){
      await this.updateAuthorUseCase.execute(this.authorId, authorModel);
      this.snackBar.open('Record was successfully updated.', undefined, this.configSnackBar);
    }else{
      const author = await this.createAuthorUseCase.execute(authorModel);
      this.snackBar.open('Record was successfully created.', undefined, this.configSnackBar);
      this.router.navigate(['/library/authors', author.authorId,'edit']);
    }
  }

  public cancelAuthor() {
    this.router.navigate(['/library/authors']);
  }

  private getFormValues(form: FormGroup): AuthorModel {
    const author = new AuthorModel();
    author.firstName = form.get('firstName')?.value;
    author.lastName = form.get('lastName')?.value;
    author.genre = form.get('genre')?.value;
    author.dateOfBirth = new Date(form.get('dateOfBirth')?.value);

    return author;
  }

}
