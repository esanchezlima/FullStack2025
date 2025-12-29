import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter, withComponentInputBinding, withHashLocation } from '@angular/router';

import { APP_ROUTES } from '../../ui/main/routes/app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideRepositories } from '../../infrastructure/providers/repositories.provider';
import { provideAppInitialize } from '../../infrastructure/providers/app-initializer.provider';
import { provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { authInterceptor } from '../../infrastructure/interceptors/auth.interceptor';
import { provideKeycloak } from '../../infrastructure/providers/keycloak.provider';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideDateAdapter } from '../../infrastructure/providers/date-adapter.provider';

export const appConfig: ApplicationConfig = {
  providers: [
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(APP_ROUTES, withHashLocation(), withComponentInputBinding()),
    provideClientHydration(),
    provideAppInitialize(),
    provideHttpClient(withFetch(),withInterceptors([authInterceptor])),
    provideRepositories(),
    provideKeycloak(),
    provideDateAdapter(),
    provideAnimationsAsync(),
    provideAnimationsAsync()
  ]
};
