import { Injectable, inject } from "@angular/core";
import { AppUserAuth } from "../models/app-user-auth";
import { KeycloakService } from "../../infrastructure/keycloak/keycloak.service";
import { KeycloakProfile } from "keycloak-js";
import { Router } from "@angular/router";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public redirectUrl: string = '';
  public appUserAuth = new AppUserAuth();
  private keycloakService = inject(KeycloakService);
  private router = inject(Router);

  constructor() {
    this.appUserAuth = this.getUserLoggedIn();
    this.setUserLoggedIn(this.appUserAuth);
  }

  public login(redirectUri:string): Promise<void> {
    return this.keycloakService.login(redirectUri);
  }

  public logout(): Promise<void> {
    return this.keycloakService.logout(window.location.origin)
      .then(() => {
        this.appUserAuth = new AppUserAuth();
        sessionStorage.removeItem('appUserAuth');
        this.router.navigate(['/']);
      });
  }

  public async getUserProfile(): Promise<KeycloakProfile> {
    try {
      return await this.keycloakService.getProfile();
    } catch (error) {
      console.error('Failed to get user profile', error);
      throw error;
    }
  }

  private setUserLoggedIn(appUserAuth: AppUserAuth) {
    sessionStorage.setItem('appUserAuth', JSON.stringify(appUserAuth));
  }

  public async LoggedInFromKeycloak() {
    this.appUserAuth = {
      access_token: await this.keycloakService.getToken(),
      refresh_token: this.keycloakService.getRefreshToken()
    };
    this.setUserLoggedIn(this.appUserAuth);
  }

  public isAuthenticated(): boolean {
    return this.keycloakService.isLoggedIn();
  }
  private getUserLoggedIn(): AppUserAuth {
    let appUserAuth = JSON.parse(sessionStorage.getItem('appUserAuth')!);
    appUserAuth = appUserAuth || new AppUserAuth();
    return appUserAuth;
  }
}
