import { Inject, Injectable } from '@angular/core';
import { API_BASE_URL } from '../clients/api-index';
import axios from 'axios';
import { User } from '../models/conversation.model';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  baseUrl: string;

  constructor(@Inject(API_BASE_URL) baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  async getUsers(): Promise<User[]> {
    const response = await axios.get(`${this.baseUrl}/users/search`);
    return response.data;
  }
}
