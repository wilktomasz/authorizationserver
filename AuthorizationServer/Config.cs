using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdentityServer4.Models;

namespace AuthorizationServer
{
    public class Config
    {
        // scopes define the API resources in your system
        public static IEnumerable<IdentityServer4.Models.ApiResource> GetApiResources()
        {
            return new List<ApiResource>()
            {
                new ApiResource("scope.readaccess", "Example API"),
                new ApiResource("scope.fullaccess", "Example API"),
                new ApiResource("YouCanActuallyDefineTheScopesAsYouLike", "Example API")
            };
        }

        // client
        public static IEnumerable<Client> GetClients()
        {
            return new List<Client>()
            {
                new Client
                {
                    ClientId = "ClientIdThatCanOnlyRead",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret>()
                    {
                        new Secret("secret1".Sha256())
                    },
                    AllowedScopes = {"scope.readaccess"}
                },
                new Client
                {
                    ClientId = "ClientIdWithFullAccess",
                    AllowedGrantTypes = GrantTypes.ClientCredentials,
                    ClientSecrets = new List<Secret>
                    {
                        new Secret("secret2".Sha256())
                    },
                    AllowedScopes =  { "scope.fullaccess" }
                }
            };
        }
    }
}
