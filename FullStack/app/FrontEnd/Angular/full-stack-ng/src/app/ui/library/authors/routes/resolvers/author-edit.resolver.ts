import { inject} from '@angular/core';
import { ResolveFn } from '@angular/router';
import { AuthorModel } from '../../../../../business/application/models/authors/author.model';
import { GetAuthorByAuthorIdUseCase } from '../../../../../business/application/use-cases/get-author-by-author-id.use-case';

export const AuthorEditResolver: ResolveFn<Promise<AuthorModel>> = (route, state) => {
  const getAuthorByAuthorIdUseCase = inject(GetAuthorByAuthorIdUseCase);
  const authorId = route.paramMap.get('authorId');

  const author = getAuthorByAuthorIdUseCase.execute(authorId!);
  return author;
};
