import { InjectionToken } from "@angular/core";
import { AuthorRepository } from "./author.repository";

export const AUTHOR_REPOSITORY_TOKEN = new InjectionToken<AuthorRepository>('AuthorRepository');
