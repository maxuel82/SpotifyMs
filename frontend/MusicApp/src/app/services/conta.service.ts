//2º serviço
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Usuario } from '../model/conta';


@Injectable({
  providedIn: 'root'
})
export class ContaService {
  private apiUrl = 'https://localhost:7214/api/User'
  
  constructor(private http: HttpClient) { }

  cadastrarConta(usuario: Usuario): Observable<Usuario> {
    return this.http.post<Usuario>(`${this.apiUrl}`, usuario);
  }
}