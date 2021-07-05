import { AppRoutingModule } from './app-routing.module';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSelectModule } from '@angular/material/select';
import { LoginComponent } from './components/login/login.component';
import { ConversationsComponent } from './components/conversations/conversations.component';
import { API_BASE_URL } from './clients/api-index';
import { NewConversationComponent } from './components/new-conversation/new-conversation.component';

@NgModule({
  declarations: [
    AppComponent,
    NewConversationComponent,
    LoginComponent,
    ConversationsComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    MatSelectModule,
    BrowserAnimationsModule,
    MatDialogModule,
  ],
  providers: [
    {
      provide: API_BASE_URL,
      useValue: 'http://localhost:5000',
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
