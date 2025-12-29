import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-security-shell',
  standalone: true,
  imports: [
    RouterLink,
    RouterOutlet
  ],
  templateUrl: './security-shell.component.html',
  styleUrl: './security-shell.component.scss'
})
export class SecurityShellComponent {

}
