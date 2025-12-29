import { HttpClient, HttpErrorResponse, HttpHeaders} from '@angular/common/http';
import { Injectable, inject} from '@angular/core';
import { catchError, delay, firstValueFrom, throwError } from 'rxjs';
import { ConfigService } from '../../../core/services/config.service';
import { Author } from '../../../business/domain/entities/Auhtor.entity';
import { AuthorResponse } from './dtos/author.response';
import { agentsMapper } from '../agents.mapper';
import { AuthService } from '../../../core/services/auth.service';
import { PaginatedResult } from './dtos/paginated-result';
import { AuthorForUpdateRequest } from './dtos/author-for-update.request';
import { AuthorForCreationRequest } from './dtos/author-for-creation.request';

@Injectable({
  providedIn: 'root'
})
export class AuthorsAgent {
  private authorsUrl = '';
  private http = inject(HttpClient);
  private authService = inject(AuthService);
  private configService = inject(ConfigService);

  constructor(){
    this.authorsUrl = `${this.configService.getValue('AUTHORS_URL')}`;
  }

  public async getAuthors(
    genre: string | null,
    searchQuery: string | null,
    orderBy: string,
    sortDirection: string,
    pageNumber: number,
    pageSize: number
  ): Promise<PaginatedResult<Author>> {
    let url: string = `${this.authorsUrl}?pageNumber=${pageNumber + 1}&pageSize=${pageSize}&orderBy=${orderBy} ${sortDirection}`;

    if (searchQuery) {
      url = `${url}&searchQuery=${searchQuery}`;
    }

    if (genre) {
      url = `${url}&genre=${genre}`;
    }

    const response = await firstValueFrom(this.http.get<AuthorResponse[]>(url,{ observe: 'response' }).pipe(
      delay(1000),
      catchError(this.handleError)
    ));

    const paginationHeader = response.headers.get('X-Pagination');
    const paginationData = paginationHeader ? JSON.parse(paginationHeader) : null;
    const authors = agentsMapper.mapArray(response.body || [], AuthorResponse, Author);

    const result: PaginatedResult<Author> = {
      data:authors,
      pagination: paginationData
    };

    return result;
  }

  public async getAuthorByAuhtorId(authorId: string): Promise<Author> {
    const url = `${this.authorsUrl}/${authorId}`;
    const response = await firstValueFrom(this.http.get<AuthorResponse>(url).pipe(catchError(this.handleError)));
    const author = agentsMapper.map(response, AuthorResponse, Author);
    return author;
  }

  public async updateAuthor(authorId: string, author: Author): Promise<Author> {
    const url = `${this.authorsUrl}/${authorId}`;
    const authorForUpdateRequest = agentsMapper.map(author, Author, AuthorForUpdateRequest);
    const response = await firstValueFrom(this.http.put<AuthorResponse>(url, authorForUpdateRequest).pipe(catchError(this.handleError)));
    const updatedAuthor = agentsMapper.map(response, AuthorResponse, Author);
    return updatedAuthor;
  }

  public async createAuthor(author: Author): Promise<Author> {
    const url = `${this.authorsUrl}`;
    const authorForCreationRequest = agentsMapper.map(author, Author, AuthorForCreationRequest);
    const response = await firstValueFrom(this.http.post<AuthorResponse>(url, authorForCreationRequest).pipe(catchError(this.handleError)));
    const createdAuthor = agentsMapper.map(response, AuthorResponse, Author);
    return createdAuthor;
  }

  public async deleteAuthor(authorId: string): Promise<void> {
    const url = `${this.authorsUrl}/${authorId}`;
    await firstValueFrom(this.http.delete(url).pipe(catchError(this.handleError)));
  }

  public getGenres(): Promise<Array<string>> {
    const genres: string[] = [
      'Children',
      'Crime',
      'Fantasy',
      'Fiction',
      'Historical Fiction',
      'Horror',
      'Magical Realism',
      'Modernist',
      'Mystery',
      'Novel',
      'Romance',
      'Science fiction',
      'Thriller',
      'Various'
    ];
    return Promise.resolve(genres);
  }

  private handleError(error: HttpErrorResponse) {
    console.error('server error:', error);
    if (error.error instanceof Error) {
      const errMessage = error.error.message;
      return throwError(() => errMessage);
    }
    return throwError(() => error || 'Server error');
  }
}
