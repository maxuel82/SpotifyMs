import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login } from '../model/login';
import { Usuario } from '../model/conta';

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


    // Método para retornar o usuário logado
    public getUsuarioLogado(): Usuario | null {
      const usuarioArmazenado = sessionStorage.getItem("user");
      if (usuarioArmazenado) {
        return JSON.parse(usuarioArmazenado);
      } else {
        return null;
      }
    }
  
}
