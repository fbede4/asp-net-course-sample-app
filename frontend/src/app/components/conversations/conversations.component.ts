import { SignalRService } from '../../services/signal-r.service';
import { ConversationsService } from '../../services/conversations.service';
import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Router } from '@angular/router';
import * as signalR from '@microsoft/signalr';
import {
  Conversation,
  ConversationList,
} from 'src/app/models/conversation.model';
import { NewConversationComponent } from '../new-conversation/new-conversation.component';

@Component({
  selector: 'app-conversations',
  templateUrl: './conversations.component.html',
  styleUrls: ['./conversations.component.scss'],
})
export class ConversationsComponent implements OnInit {
  currentConversation: Conversation = {
    id: 0,
    partnerUserName: '',
    messages: [],
  };
  newMessage = '';
  isLoading = false;
  userId: number;
  conversations: ConversationList[];
  connection: signalR.HubConnection;

  constructor(
    private signalRService: SignalRService,
    private conversationsService: ConversationsService,
    private router: Router,
    private dialog: MatDialog
  ) {}

  async ngOnInit(): Promise<void> {
    this.isLoading = true;

    const userId = localStorage.getItem('userId');
    if (!userId) {
      this.router.navigate(['/login']);
    }
    this.userId = +userId;

    this.initializeSignalR();

    await this.getConversations();

    this.isLoading = false;
  }

  initializeSignalR(): void {
    this.connection = this.signalRService.createConnection();
    this.connection.on('NewMessage', async () => {
      await this.reloadConversations();
    });
    SignalRService.start(this.connection);
  }

  async reloadConversations(): Promise<void> {
    await this.getConversations();
    if (this.currentConversation.id) {
      await this.getConversation(this.currentConversation.id);
    }
  }

  openNewConversationDialog(): void {
    const dialogRef = this.dialog.open(NewConversationComponent, {
      data: this.userId,
    });
    dialogRef.afterClosed().subscribe(() => {
      this.getConversations();
    });
  }

  async getConversations(): Promise<void> {
    this.conversations = await this.conversationsService.getConversations(
      this.userId
    );
  }

  async getConversation(conversationId: number): Promise<void> {
    this.currentConversation = await this.conversationsService.getConversation(
      conversationId,
      this.userId
    );
  }

  async sendMessage(): Promise<void> {
    if (this.newMessage.trim() === '') {
      return;
    }

    await this.conversationsService.sendMessage(
      this.newMessage,
      this.userId,
      this.currentConversation.id
    );

    this.newMessage = '';
    await this.getConversation(this.currentConversation.id);
  }

  logout(): void {
    localStorage.clear();
    this.userId = 0;
    this.conversations = null;
    this.router.navigate(['/']);
  }
}
