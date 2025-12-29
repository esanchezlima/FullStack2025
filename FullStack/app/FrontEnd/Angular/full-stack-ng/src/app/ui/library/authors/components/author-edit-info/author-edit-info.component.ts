import { Component, OnInit, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-author-edit-info',
  standalone: true,
  imports: [],
  templateUrl: './author-edit-info.component.html',
  styleUrl: './author-edit-info.component.scss'
})
export class AuthorEditInfoComponent {
  public author = inject(ActivatedRoute).parent!.snapshot.data['author'];

}
