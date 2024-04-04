import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MusicaFavoritaUsuario } from '../model/album';

@Injectable({
  providedIn: 'root'
})
export class PlaylistService {

  private url = "https://localhost:7214/api/Playlist"

  

  constructor(private http: HttpClient) { }

  public FavoritarMusica(usuarioId:String, musicaId: String) : Observable<MusicaFavoritaUsuario> {
    let headers = new HttpHeaders({'Content-Type': 'application/json'});
    
    return this.http.post<MusicaFavoritaUsuario>(`${this.url}/FavoritarMusica`, {
      usuarioId:usuarioId,
      musicaId:musicaId
    }, { headers: headers });
  }
 
}
