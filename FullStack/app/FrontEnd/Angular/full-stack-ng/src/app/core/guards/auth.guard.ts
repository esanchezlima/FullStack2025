import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { HashLocationStrategy, LocationStrategy } from '@angular/common';

export const authGuard: CanActivateFn = async (route, state) => {
  const authService = inject(AuthService);
  const locationStrategy = inject(LocationStrategy);

  let redirectUrl = window.location.origin;

  if (locationStrategy instanceof HashLocationStrategy) {
    const encodedUrl = btoa(state.url);
    redirectUrl += `/#/security/keycloak-integration/${encodedUrl}`;
  } else {
    redirectUrl += "/security/keycloak-integration";
  }

  if (!authService.isAuthenticated()) {
    await authService.login(redirectUrl);
  }

  return authService.isAuthenticated();
};
