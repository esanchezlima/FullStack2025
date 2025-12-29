import { AfterViewInit, Component, Input, OnInit, ViewChild, inject } from '@angular/core';
import { AsyncPipe, DatePipe } from '@angular/common';
import { AuthorModel } from '../../../../../business/application/models/authors/author.model';
import { MatTableModule} from '@angular/material/table';
import { MatPaginator, MatPaginatorModule} from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatCardModule } from '@angular/material/card';
import { PaginatedResult } from '../../../../../infrastructure/agents/authors/dtos/paginated-result';
import { Subject, debounceTime, merge, startWith, switchMap } from 'rxjs';
import { LoadingService } from '../../../../shared/components/loading/services/loading.service';
import { GetAuthorsUseCase } from '../../../../../business/application/use-cases/get-authors.use-case';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { GetGenresUseCase } from '../../../../../business/application/use-cases/get-genres.use-case';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from '../../components/confirmation-dialog/confirmation-dialog.component';
import { DeleteAuthorUseCase } from '../../../../../business/application/use-cases/delete-author.use-case';
import { MatSnackBar, MatSnackBarConfig, MatSnackBarModule } from '@angular/material/snack-bar';

@Component({
  selector: 'app-author-list-page',
  standalone: true,
  imports: [
    DatePipe,
    AsyncPipe,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatCardModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatIconModule,
    MatButtonModule,
    MatSnackBarModule
  ],
  templateUrl: './author-list-page.component.html',
  styleUrl: './author-list-page.component.scss'
})
export class AuthorListPageComponent implements AfterViewInit, OnInit{
  @Input() pageTitle?: string;
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  private loadingService = inject(LoadingService);
  private getAuthorsUseCase = inject(GetAuthorsUseCase);
  private deleteAuthorUseCase = inject(DeleteAuthorUseCase);
  private router = inject(Router);

  private searchQueryChanged: Subject<string> = new Subject<string>();
  private currentSearchQuery: string = '';
  private genreChanged: Subject<string> = new Subject<string>();
  private selectedGenre: string = '';

  public authors: PaginatedResult<AuthorModel> = new PaginatedResult<AuthorModel>();
  public genres = inject(GetGenresUseCase).execute();
  public dialog = inject(MatDialog);
  private snackBar = inject(MatSnackBar);
  private configSnackBar = new MatSnackBarConfig();
  public displayedColumns: string[] = ['authorId', 'name', 'age', 'genre', 'firstName', 'lastName','dateOfBirth','actions'];

  ngOnInit(): void {
    this.configSnackBar.duration = 3000;
  }
  ngAfterViewInit(): void {
    this.loadData();
  }

  private async loadData() {
    merge(
      this.paginator.page,
      this.sort.sortChange,
      this.genreChanged,
      this.searchQueryChanged.pipe(debounceTime(300))
    )
    .pipe(
      startWith({}),
      switchMap(() => {
        this.loadingService.show();
        return this.getAuthorsUseCase.execute(
          this.selectedGenre,
          this.currentSearchQuery,
          this.sort.active,
          this.sort.direction,
          this.paginator.pageIndex,
          this.paginator.pageSize
        )
          .then(result => result)
          .catch(() => new PaginatedResult<AuthorModel>());
      }))
      .subscribe(result => {
        this.loadingService.hide();
        this.authors = result;
      }
    );
  }

  public applySearchQuery(event: Event) {
    this.currentSearchQuery = (event.target as HTMLInputElement).value;
    this.searchQueryChanged.next(this.currentSearchQuery);
  }

  public onGenreChange(event: any) {
    this.selectedGenre = event.value;
    this.genreChanged.next(this.selectedGenre);
  }

  public editAuthor(author: AuthorModel) {
    this.router.navigate(['/library/authors', author.authorId,'edit']);
  }

  public deleteAuthor(author: AuthorModel) {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      width: '350px',
      data: { author: author },
      disableClose: true
    });

    dialogRef.afterClosed().subscribe(async result => {
      if (result) {
        await this.deleteAuthorUseCase.execute(author.authorId);
        this.snackBar.open('Record was successfully deleted.', undefined, this.configSnackBar);
        this.loadData();
      }
    });
  }
}
