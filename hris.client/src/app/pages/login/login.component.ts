import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent {
  email = "";
  password = "";
  isError = false;

  constructor(private authService: AuthService, private router: Router){
  }
  onSubmit(){
    this.authService.login(this.email, this.password).subscribe({
      next: (isAuthenticated) => {
        if (isAuthenticated) {
          this.router.navigate(['/home']); // Redirect to dashboard or any other route after successful login
        } else {
          this.isError = true; // Show error message on failed login
        }
      },
      error: (error) => {
        this.isError = true;
      }
    });
  }
}
