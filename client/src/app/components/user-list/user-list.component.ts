import { Component } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../interfaces/user.interface';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrl: './user-list.component.css',
})
export class UserListComponent {
  public users: User[] = [];

  constructor(private userService: UserService) {
    this.getUsers()
  }

  getUsers() {
    this.userService.getList().subscribe((res) => {
      this.users = res;
    });
  }


}
