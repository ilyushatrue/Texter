import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { constants } from '../infrastructure/constants';
import { User } from '../interfaces/user.interface';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  constructor(private httpClient: HttpClient) {}

  getList() {
    return this.httpClient.get<User[]>(`${constants.backendUrl}/users`);
  }
}
