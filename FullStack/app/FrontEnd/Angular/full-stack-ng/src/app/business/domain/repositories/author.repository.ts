import { PaginatedResult } from '../../../infrastructure/agents/authors/dtos/paginated-result';
import { Author } from '../entities/Auhtor.entity';

export interface AuthorRepository {
  getAuthors(genre: string | null, searchQuery: string | null, orderBy: string, sortDirection: string, pageNumber: number, pageSize: number): Promise<PaginatedResult<Author>>;
  getAuthorById(authorId: string): Promise<Author>;
  updateAuthor(authorId: string, author: Author): Promise<Author>;
  createAuthor(author: Author): Promise<Author>;
  deleteAuthor(authorId: string): Promise<void>;
  getGenres(): Promise<Array<string>>
}
