import { AsyncPipe } from "@angular/common";
import { Component, Input, OnInit, inject } from "@angular/core";
import { MatButtonModule } from "@angular/material/button";
import { MatIconModule } from "@angular/material/icon";
import { MatMenuModule } from "@angular/material/menu";
import { MatSidenav } from "@angular/material/sidenav";
import { MatToolbarModule } from "@angular/material/toolbar";
import { Observable } from "rxjs";
import { AuthService } from "../../../../../core/services/auth.service";
import { KeycloakProfile } from "keycloak-js";
import { CapitalizePipe } from "../../../../shared/pipes/capitalize.pipe";


@Component({
  selector: 'app-header',
  standalone: true,
  imports: [
    MatToolbarModule,
    MatButtonModule,
    MatIconModule,
    MatMenuModule,
    AsyncPipe,
    CapitalizePipe
  ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent  implements OnInit {
  @Input() isHandset$!: Observable<boolean>;
  @Input() drawer!: MatSidenav;

  private authService = inject(AuthService);
  public profile?: KeycloakProfile;

  public ngOnInit(): void {
    this.authService.getUserProfile().then(profile => {
      this.profile = profile;
    });
  }

  public signOut() {
    this.authService.logout();
  }
}
