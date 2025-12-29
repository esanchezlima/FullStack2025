import { Injectable, inject } from "@angular/core";
import { AuthorRepository } from "../../business/domain/repositories/author.repository";
import { Author } from "../../business/domain/entities/Auhtor.entity";
import { AuthorsAgent } from "../agents/authors/authors.agent";
import { PaginatedResult } from "../agents/authors/dtos/paginated-result";

@Injectable({
  providedIn: 'root'
})
export class AuthorRepositoryImpl implements AuthorRepository {
  private authorAgent = inject(AuthorsAgent);

  public async getAuthorById(authorId: string): Promise<Author> {
    return await this.authorAgent.getAuthorByAuhtorId(authorId);
  }

  public getAuthors(
    genre: string | null,
    searchQuery: string | null,
    orderBy: string,
    sortDirection: string,
    pageNumber: number,
    pageSize: number
  ): Promise<PaginatedResult<Author>> {
    return this.authorAgent.getAuthors(genre, searchQuery, orderBy, sortDirection, pageNumber, pageSize);
  }

  public async updateAuthor(authorId: string, author: Author): Promise<Author>{
    return await this.authorAgent.updateAuthor(authorId, author);
  }

  public async createAuthor(author: Author): Promise<Author>{
    return await this.authorAgent.createAuthor(author);
  }

  public async deleteAuthor(authorId: string): Promise<void>{
    return await this.authorAgent.deleteAuthor(authorId);
  }

  public getGenres(): Promise<Array<string>>{
    return this.authorAgent.getGenres();
  }
}
