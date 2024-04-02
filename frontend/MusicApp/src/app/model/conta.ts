
// conta.ts 1º model
export interface Usuario {
    //id: string;
    nome: string;
    email: string;
    senha: string;
    dtNascimento: Date;
    planoId: string;
    cartao: Cartao;
  }
  
  // cartao
  export interface Cartao {
    //id: string;
    ativo: boolean;
    limite: number;
    numero: string;
  }
  
  //Usuario
  //Conta