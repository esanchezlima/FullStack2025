import { Injectable, inject} from '@angular/core';
import { AUTHOR_REPOSITORY_TOKEN } from '../../domain/repositories/repository.tokens';

@Injectable({
  providedIn: 'root'
})
export class DeleteAuthorUseCase{
  private authorRepository = inject(AUTHOR_REPOSITORY_TOKEN);

  public async execute(authorId: string): Promise<void> {
    await this.authorRepository.deleteAuthor(authorId);
  }
}
