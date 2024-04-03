using SpotifyMs.Domain.Conta.Agreggates;
using SpotifyMs.Domain.Streaming.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotifyMS.Repository.Repository
{
    public class PlaylistRepository : RepositoryBase<Playlist>
    {
        public PlaylistRepository(SpotifyMSContext context) : base(context)
        {

        }


    }
}
