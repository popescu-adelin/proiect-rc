import { APP_INITIALIZER, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http'
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListComponent } from './components/list/list.component';
import { MatTableModule } from '@angular/material/table';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { EmployeeComponent } from './component/employee/employee.component';
import { ModalComponent } from './shared/modal/modal.component';
import { FormsModule } from '@angular/forms';
import { SignalrService } from './services/signalr.service';

@NgModule({
  declarations: [
    AppComponent,
    ListComponent,
    EmployeeComponent,
    ModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MatTableModule,
    BrowserAnimationsModule,
    FormsModule
  ],
  providers: [
    SignalrService,
    {
      provide: APP_INITIALIZER,
      useFactory: (signalrService: SignalrService) => () => signalrService.initiateSignalrConnection(),
      deps: [SignalrService],
      multi: true,
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
