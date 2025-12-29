import { Injectable, inject} from '@angular/core';
import { AuthorModel } from '../models/authors/author.model';
import { applicationMapper } from '../mappers/application.mapper';
import { Author } from '../../domain/entities/Auhtor.entity';
import { AUTHOR_REPOSITORY_TOKEN } from '../../domain/repositories/repository.tokens';

@Injectable({
  providedIn: 'root'
})
export class UpdateAuthorUseCase{
  private authorRepository = inject(AUTHOR_REPOSITORY_TOKEN);

  public async execute(authorId: string, author: AuthorModel): Promise<AuthorModel> {
    const authorEntity =  applicationMapper.map(author, AuthorModel, Author);
    const updatedAuthorEntity = await this.authorRepository.updateAuthor(authorId, authorEntity);
    const updatedAuthorModel = applicationMapper.map(updatedAuthorEntity, Author, AuthorModel);
    return updatedAuthorModel;
  }
}
