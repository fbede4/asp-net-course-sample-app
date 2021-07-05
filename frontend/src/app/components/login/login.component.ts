import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { Component } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {
  username: string;

  constructor(private authService: AuthService, private router: Router) {}

  async login(): Promise<void> {
    const userId = await this.authService.login(this.username);
    localStorage.setItem('userId', userId.toString());
    this.router.navigate(['conversations']);
  }
}
