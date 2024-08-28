import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent implements OnInit {
  email = "";
  password = "";
  isError = false;

  constructor(private authService: AuthService, private router: Router){
  }

  ngOnInit(): void {
      let token = localStorage.getItem("authToken");

      if(!!token)
        this.router.navigate(['/dashboard/home']);
  }

  onSubmit(){
    this.authService.login(this.email, this.password).subscribe({
      next: (response) => {
        if (response) {
          localStorage.setItem("authToken", response.token);
          this.router.navigate(['/dashboard/home']); // Redirect to dashboard or any other route after successful login
        } else {
          this.isError = true; // Show error message on failed login
        }
      },
      error: (error) => {
        console.error(error);
        this.isError = true;
      }
    });
  }
}
