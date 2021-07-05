import { Inject, Injectable } from '@angular/core';
import { API_BASE_URL } from '../clients/api-index';
import { HubConnection, HubConnectionBuilder } from '@microsoft/signalr';

@Injectable({
  providedIn: 'root',
})
export class SignalRService {
  baseUrl: string;

  constructor(@Inject(API_BASE_URL) baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  static start(connection: HubConnection): void {
    connection.start().catch(() => {
      const retryDelay = 2000 + Math.random() * 2000;
      setTimeout(() => SignalRService.start(connection), retryDelay);
    });
  }

  createConnection(): HubConnection {
    return new HubConnectionBuilder()
      .withUrl(`${this.baseUrl}/hubs/chat`)
      .build();
  }
}
