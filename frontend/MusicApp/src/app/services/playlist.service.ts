import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MusicaFavoritaUsuario, Playlist } from '../model/album';

@Injectable({
  providedIn: 'root'
})
export class PlaylistService {

  private url = "https://localhost:7214/api/Playlist"

  

  constructor(private http: HttpClient) { }

  public FavoritarMusica(usuarioId:String, musicaId: String) : Observable<Playlist> {  
      return this.http.post<Playlist>(`${this.url}/FavoritarMusica`, { usuarioId:usuarioId,   musicaId:musicaId}
      );
  }
 
}
