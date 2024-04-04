import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ActivatedRouteSnapshot, Route } from '@angular/router';
import { Form, FormsModule, FormControl } from '@angular/forms';  //para trabalhar com ngForm, ngModel, 
import {MatExpansionModule} from '@angular/material/expansion';
import {MatSlideToggleModule} from '@angular/material/slide-toggle';

import { Banda } from '../model/banda';
import { BandaService } from '../services/banda.service';
import { Album, Musica } from '../model/album';

import { CommonModule } from '@angular/common';
import { LoginService } from '../services/login.service';
import { PlaylistService } from '../services/playlist.service';


@Component({
  selector: 'app-detail-banda',
  standalone: true,
  imports: [MatExpansionModule, CommonModule, FormsModule, MatSlideToggleModule],
  templateUrl: './detail-banda.component.html',
  styleUrl: './detail-banda.component.css'
})
export class DetailBandaComponent implements OnInit {

  idBanda = '';
  banda!:Banda;
  albuns!:Album[];
      
  constructor(private route: ActivatedRoute, private bandaService: BandaService, private loginService: LoginService, private playlistService :PlaylistService) {  }
  
  ngOnInit(): void {
    this.idBanda = this.route.snapshot.params["id"];  

    this.bandaService.getBandaPorId(this.idBanda).subscribe(response => {
      this.banda = response;
    });

    this.bandaService.getAlbunsBanda(this.idBanda).subscribe(response => {
      this.albuns = response;
      console.log(this.albuns);
    });
  
  }

  public FavoritarMusica (event: any, item:Musica) {
    item.Favorita = event.checked;

    
    console.log(item, item.Favorita, this.loginService.getUsuarioLogado());
    const usuario = this.loginService.getUsuarioLogado();

    if (usuario && usuario.id && item && item.id) {
      this.playlistService.FavoritarMusica(usuario.id, item.id);
    } else {
      console.error('Usuário ou item não estão definidos ou não possuem IDs.');
    }
  }

}//OnInit


