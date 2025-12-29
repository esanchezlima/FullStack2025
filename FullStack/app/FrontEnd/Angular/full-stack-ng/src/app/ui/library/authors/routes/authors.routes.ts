import { Routes } from "@angular/router";
import { AuthorsShellComponent } from "../shell/layout/authors-shell.component";
import { AuthorListPageComponent } from "../pages/author-list-page/author-list-page.component";
import { AuthorEditResolver } from "./resolvers/author-edit.resolver";
import { AuthorEditPageComponent } from "../pages/author-edit-page/author-edit-page.component";
import { AuthorDetailPageComponent } from "../pages/author-detail-page/author-detail-page.component";
import { AuthorDetailResolver } from "./resolvers/author-detail.resolver";

export const AUTHORS_ROUTES: Routes = [
  {
    path: '', component: AuthorsShellComponent,
    children: [
      { path: '', component: AuthorListPageComponent
      // , resolve: { authors: AuthorsResolver }
      },
      { path: 'new', component: AuthorEditPageComponent },
      { path: ':authorId', component: AuthorDetailPageComponent, resolve: { author: AuthorDetailResolver } },
      { path: ':authorId/edit', component: AuthorEditPageComponent, resolve: { author: AuthorEditResolver }}
    ]
  }
]
