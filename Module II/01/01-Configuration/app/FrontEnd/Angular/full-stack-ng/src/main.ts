import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/core/config/app.config';
import { AppComponent } from './app/ui/main/pages/app.component';

bootstrapApplication(AppComponent, appConfig)
  .catch((err) => console.error(err));
