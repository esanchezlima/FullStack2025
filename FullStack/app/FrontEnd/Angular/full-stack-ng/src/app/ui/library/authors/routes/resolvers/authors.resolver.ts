import { inject } from '@angular/core';
import { ResolveFn } from '@angular/router';
import { AuthorModel } from '../../../../../business/application/models/authors/author.model';
import { GetAuthorsUseCase } from '../../../../../business/application/use-cases/get-authors.use-case';
import { LoadingService } from '../../../../shared/components/loading/services/loading.service';
import { PaginatedResult } from '../../../../../infrastructure/agents/authors/dtos/paginated-result';

export const AuthorsResolver: ResolveFn<Promise<PaginatedResult<AuthorModel>>> = async (route, state) => {
  const getAuthorsUseCase = inject(GetAuthorsUseCase);
  const loadingService = inject(LoadingService);

  loadingService.show();

  try {
    const authors = await getAuthorsUseCase.execute();
    return authors;
  } finally {
    loadingService.hide();
  }
};
