import { bootstrapApplication } from '@angular/platform-browser';
import { config } from './app/core/config/app.config.server';
import { AppComponent } from './app/ui/main/pages/app.component';

const bootstrap = () => bootstrapApplication(AppComponent, config);

export default bootstrap;
