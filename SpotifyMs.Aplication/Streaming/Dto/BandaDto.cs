﻿using System.ComponentModel.DataAnnotations;

namespace SpotifyMs.Aplication.Streaming.Dto
{
    public class BandaDto
    {
        public Guid Id { get; set; }


        [Required]
        public String Nome { get; set; }

        [Required]
        public String Descricao { get; set; }
        
        public String Backdrop { get; set; }

    }
}
