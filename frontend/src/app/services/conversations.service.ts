import { Conversation, ConversationList } from '../models/conversation.model';
import { Inject, Injectable } from '@angular/core';
import axios from 'axios';
import { API_BASE_URL } from '../clients/api-index';

@Injectable({
  providedIn: 'root',
})
export class ConversationsService {
  baseUrl: string;

  constructor(@Inject(API_BASE_URL) baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  async getConversations(userId: number): Promise<ConversationList[]> {
    const conversationsResponse = await axios.get(
      `${this.baseUrl}/conversations?userId=${userId}`
    );
    return conversationsResponse.data;
  }

  async createConversation(
    currentUserId: number,
    otherUserId: number
  ): Promise<void> {
    await axios.post(
      `${this.baseUrl}/conversations?firstUserId=${currentUserId}&secondUserId=${otherUserId}`
    );
  }

  async getConversation(
    conversationId: number,
    userId: number
  ): Promise<Conversation> {
    const response = await axios.get(
      `${this.baseUrl}/conversations/${conversationId}?userId=${userId}`
    );
    return response.data;
  }

  async sendMessage(
    message: string,
    userId: number,
    conversationId: number
  ): Promise<void> {
    await axios.post(
      `${this.baseUrl}/messages?message=${message}&sentByUserId=${userId}&conversationId=${conversationId}`
    );
  }
}
