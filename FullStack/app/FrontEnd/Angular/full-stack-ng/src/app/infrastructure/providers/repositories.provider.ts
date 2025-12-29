import { Provider } from "@angular/core";
import { AUTHOR_REPOSITORY_TOKEN } from "../../business/domain/repositories/repository.tokens";
import { AuthorRepositoryImpl } from "../persistence/author.repository.impl";

export function provideRepositories(): Provider[] {
  return [
    { provide: AUTHOR_REPOSITORY_TOKEN, useClass: AuthorRepositoryImpl },
    // Agrega otros repositorios aquí
  ];
}
