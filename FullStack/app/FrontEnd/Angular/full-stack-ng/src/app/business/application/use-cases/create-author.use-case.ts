import { Injectable, inject} from '@angular/core';
import { AuthorModel } from '../models/authors/author.model';
import { applicationMapper } from '../mappers/application.mapper';
import { Author } from '../../domain/entities/Auhtor.entity';
import { AUTHOR_REPOSITORY_TOKEN } from '../../domain/repositories/repository.tokens';

@Injectable({
  providedIn: 'root'
})
export class CreateAuthorUseCase{
  private authorRepository = inject(AUTHOR_REPOSITORY_TOKEN);

  public async execute(author: AuthorModel): Promise<AuthorModel> {
    const authorEntity =  applicationMapper.map(author, AuthorModel, Author);
    const createdAuthorEntity = await this.authorRepository.createAuthor(authorEntity);
    const createdAuthorModel = applicationMapper.map(createdAuthorEntity, Author, AuthorModel);
    return createdAuthorModel;
  }
}
