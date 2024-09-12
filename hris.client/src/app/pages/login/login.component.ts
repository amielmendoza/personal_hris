import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
import { SpinnerService } from '../../services/spinner.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss',
})
export class LoginComponent implements OnInit {
  email = "";
  password = "";
  isError = false;

  constructor(private authService: AuthService, private router: Router, private spinnerService: SpinnerService){
  }

  ngOnInit(): void {
      let token = localStorage.getItem("authToken");

      if(!!token)
        this.router.navigate(['/dashboard/home']);
  }

  onSubmit(){
    this.spinnerService.show();
    this.authService.login(this.email, this.password).subscribe({
      next: (response) => {
        if (response) {
          this.spinnerService.hide();
          localStorage.setItem("authToken", response.token);
          this.router.navigate(['/dashboard/home']); // Redirect to dashboard or any other route after successful login
        } else {
          this.spinnerService.hide();
          this.isError = true; // Show error message on failed login
        }
      },
      error: (error) => {
        this.spinnerService.hide();
        console.error(error);
        this.isError = true;
      }
    });
  }
}
