import { Injectable, inject} from '@angular/core';
import { AUTHOR_REPOSITORY_TOKEN } from '../../domain/repositories/repository.tokens';

@Injectable({
  providedIn: 'root'
})
export class GetGenresUseCase{
  private authorRepository = inject(AUTHOR_REPOSITORY_TOKEN);

  public async execute(): Promise<Array<string>> {
    return await this.authorRepository.getGenres();
  }
}
