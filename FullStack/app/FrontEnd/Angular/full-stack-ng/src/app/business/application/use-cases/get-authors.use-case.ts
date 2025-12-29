import { Injectable, inject} from '@angular/core';
import { AuthorModel } from '../models/authors/author.model';
import { applicationMapper } from '../mappers/application.mapper';
import { Author } from '../../domain/entities/Auhtor.entity';
import { AUTHOR_REPOSITORY_TOKEN } from '../../domain/repositories/repository.tokens';
import { PaginatedResult } from '../../../infrastructure/agents/authors/dtos/paginated-result';

@Injectable({
  providedIn: 'root'
})
export class GetAuthorsUseCase{
  private authorRepository = inject(AUTHOR_REPOSITORY_TOKEN);

  public async execute(
    genre: string | null = null,
    searchQuery: string | null = null,
    orderBy: string = '',
    sortDirection: string = '',
    pageNumber: number = 1,
    pageSize: number = 10
  ): Promise<PaginatedResult<AuthorModel>> {
    const pagenatedAuthors = await this.authorRepository.getAuthors(genre, searchQuery, orderBy, sortDirection, pageNumber, pageSize);
    const authors = applicationMapper.mapArray(pagenatedAuthors.data,Author, AuthorModel);

    const result: PaginatedResult<AuthorModel> = {
      data:authors,
      pagination: pagenatedAuthors.pagination
    };

    return result;
  }
}
