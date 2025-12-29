import { Injectable, inject } from '@angular/core';
import { AUTHOR_REPOSITORY_TOKEN } from '../../domain/repositories/repository.tokens';
import { AuthorModel } from '../models/authors/author.model';
import { applicationMapper } from '../mappers/application.mapper';
import { Author } from '../../domain/entities/Auhtor.entity';

@Injectable({
  providedIn: 'root'
})
export class GetAuthorByAuthorIdUseCase {
  private authorRepository = inject(AUTHOR_REPOSITORY_TOKEN);

  public async execute(authorId: string): Promise<AuthorModel> {
    const authorEntity = await this.authorRepository.getAuthorById(authorId);

    return  applicationMapper.map(authorEntity,Author, AuthorModel);
  }
}
