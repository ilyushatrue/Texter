import { HttpClient } from '@angular/common/http';
import { Component, signal } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { constants } from '../../infrastructure/constants';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.css',
})
export class AuthComponent {
  form: FormGroup;
  error = signal('');
  constructor(private fb: FormBuilder, private authService: AuthService) {
    this.form = this.fb.group({
      nickname: '',
    });
  }

  onSubmit() {
    console.log(this.form.value)
    this.authService.register(this.form.value).subscribe(({ ok }) => {
      if (!ok) {
        this.error.set('Не удалось зарегистрироваться');
        return;
      }
    });
  }
}
