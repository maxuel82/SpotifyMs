using IdentityServer4;
using IdentityServer4.Models;


namespace SpotifyMs.STS
{
    public class IdentityServerConfiguration
    {
        public static IEnumerable<IdentityResource> GetIdentityResource()
        {
            return new List<IdentityResource>()
            {
                new IdentityResources.OpenId(),
                new IdentityResources.Profile()
            };
        }

        public static IEnumerable<ApiResource> GetApiResource()
        {
            return new List<ApiResource>()
            {
                new ApiResource("SpotifyMs-api", "SpotifyMs", new string[] { "SpotifyMs-user" })
                {
                    ApiSecrets =
                    {
                        new Secret("SpotifyMsSecret".Sha256())
                    },
                    Scopes =
                    {
                        "SpotifyMsScope"
                    }
                }
            };
        }

        public static IEnumerable<ApiScope> GetApiScopes()
        {
            return new List<ApiScope>()
            {
                new ApiScope()
                {
                    Name = "SpotifyLikeScope",
                    DisplayName = "SpotifyMs API",
                    UserClaims = { "SpotifyMs-user" }
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client()
                {
                    ClientId = "client-angular-spotify",
                    ClientName = "Acesso do front as APIS",
                    AllowedGrantTypes = GrantTypes.ResourceOwnerPasswordAndClientCredentials,
                    ClientSecrets =
                    {
                        new Secret("SpotifyMsSecret".Sha256())
                    },
                    AllowedScopes =
                    {
                        IdentityServerConstants.StandardScopes.OpenId,
                        IdentityServerConstants.StandardScopes.Profile,
                        "SpotifyLikeScope"
                    }
                }
            };
        }
    }
}
