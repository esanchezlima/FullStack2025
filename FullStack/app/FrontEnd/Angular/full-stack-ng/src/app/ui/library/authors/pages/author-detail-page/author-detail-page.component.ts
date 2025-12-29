import { Component, Input } from '@angular/core';
import { AuthorModel } from '../../../../../business/application/models/authors/author.model';

@Component({
  selector: 'app-author-detail-page',
  standalone: true,
  imports: [],
  templateUrl: './author-detail-page.component.html',
  styleUrl: './author-detail-page.component.scss'
})
export class AuthorDetailPageComponent {
  @Input() authorId?: string;
  @Input() searchQuery?: string;
  @Input() orderBy?: string;

  @Input() author!: AuthorModel;
}
