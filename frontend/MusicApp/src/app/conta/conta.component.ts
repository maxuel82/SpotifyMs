import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Form, FormsModule } from '@angular/forms';  //para trabalhar com ngForm, ngModel, 
import { Router } from '@angular/router';

import { Usuario, Cartao } from '../model/conta';
import { ContaService } from '../services/conta.service';

@Component({
  selector: 'app-conta',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './conta.component.html',
  styleUrl: './conta.component.css'
})
  export class ContaComponent implements OnInit {
    
    usuario: Usuario = {
      //id: '',
      nome: '',
      email: '',
      senha: '',
      dtNascimento: new Date(),
      planoId: '',
      cartao: {
//        id: '',
        ativo: false,
        limite: 0,
        numero: ''
      }
    }

    mensagem: string = '';
    errorMessage = '';

    constructor(private contaService: ContaService, private router: Router) {}
      
    ngOnInit(): void {
      // Coloque aqui o código que você deseja executar quando o componente for inicializado
    }

   /// 

   public cadastrarConta(frm: Form) {
    
    this.contaService.cadastrarConta(this.usuario).subscribe(
      {
        next: (response) => {
          this.usuario = response;
          sessionStorage.setItem("user", JSON.stringify(this.usuario));
          this.router.navigate(["/home"]
          );
        },
        error: (e) => {
          if (e.error) {
            this.errorMessage = e.error.error;
          }
        }
      });         
    }

 }