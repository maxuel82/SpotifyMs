export interface Album {
    id?:string;
    nome?:string;
    musicas?: Musica[]
}

export interface Musica {
    id?:string;
    nome?:string;
    duracao?:string;
    Favorita:boolean;
}


export interface Playlist{
    id: string;
    nome: string;
    publica: boolean;
    usuarioId: string;
    musicas?: Musica[];
}


export interface MusicaFavoritaUsuario
{
    usuarioId:string;
    musicaId: string;
}