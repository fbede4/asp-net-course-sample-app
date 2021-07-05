import { Inject, Injectable } from '@angular/core';
import { API_BASE_URL } from '../clients/api-index';
import axios from 'axios';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseUrl: string;

  constructor(@Inject(API_BASE_URL) baseUrl: string) {
    this.baseUrl = baseUrl;
  }

  async login(username: string): Promise<number> {
    const response = await axios.post(
      `${this.baseUrl}/users/login/${username}`
    );
    return response.data.id;
  }
}
