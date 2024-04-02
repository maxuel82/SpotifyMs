import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login } from '../model/login';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private url = "https://localhost:7214/api/User"
    
  constructor(private http: HttpClient) { }

  public autenticar(email:String, senha: String) : Observable<Login> {
    return this.http.post<Login>(`${this.url}/login`, {
      email:email,
      senha:senha
    });
  }

}
