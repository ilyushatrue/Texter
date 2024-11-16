import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { constants } from '../infrastructure/constants';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private httpClient: HttpClient) {}

  register(nickname: { nickname: string }) {
    return this.httpClient.post(`${constants.backendUrl}/auth`, nickname, {
      observe: 'response',
      withCredentials: true,
    });
  }
}
