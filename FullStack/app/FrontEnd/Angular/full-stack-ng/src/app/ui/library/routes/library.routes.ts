import { Routes } from "@angular/router";
import { LibraryShellComponent } from "../shell/layout/library-shell.component";
import { BookListComponent } from "../books/components/book-list/book-list.component";
import { authGuard } from "../../../core/guards/auth.guard";

export const LIBRARY_ROUTES: Routes = [
  {
    path: '', component: LibraryShellComponent, canActivate: [authGuard],
    children: [
      { path: '', redirectTo: 'authors', pathMatch: 'full' },
      { path: 'authors', loadChildren: () => import('../authors/routes/authors.routes').then(m => m.AUTHORS_ROUTES) },
      { path: 'books', component: BookListComponent }
    ]
  }
]
