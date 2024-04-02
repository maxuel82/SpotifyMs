import { Component } from '@angular/core';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormControl, Validators, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { LoginService } from '../services/login.service';
import { Login } from '../model/login';
import { Router } from '@angular/router';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [MatFormFieldModule, MatInputModule, FormsModule, ReactiveFormsModule, CommonModule, MatButtonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email = new FormControl('', [Validators.required, Validators.email]);
  senha = new FormControl('', [Validators.required]);
  errorMessage = '';
  usuario!: Login;

  constructor(private LoginService: LoginService, private router: Router) {

  }

  public login() {
    if (this.email.invalid || this.senha.invalid) {
      return;
    }

    let emailValue = this.email.getRawValue() as String;
    let senhaValue = this.senha.getRawValue() as String;

    this.LoginService.autenticar(emailValue, senhaValue).subscribe(
      {
        next: (response) => {
          this.usuario = response;
          sessionStorage.setItem("user", JSON.stringify(this.usuario));
          this.router.navigate(["/home"]);
        },
        error: (e) => {
          if (e.error) {
            this.errorMessage = e.error.error;
          }
        }
      });


  }

  public criarConta() {
    this.router.navigate(["conta"]);
  }


}
