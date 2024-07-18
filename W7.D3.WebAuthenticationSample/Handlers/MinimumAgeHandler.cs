using Microsoft.AspNetCore.Authorization;

namespace W7.D3.WebAuthenticationSample.Handlers
{
    /// <summary>
    /// Gestore del requirement MinimumAgeRequirement.
    /// </summary>
    public class MinimumAgeHandler : AuthorizationHandler<MinimumAgeRequirement>
    {
        /// <summary>
        /// Cuore del gestore: controlla che l'utente registrato nel context soddisfi
        /// i requisiti previsti dal requirement.
        /// </summary>
        /// <param name="context">Contesto di autorizzazione di sistema.</param>
        /// <param name="requirement">Requirement da controllare.</param>
        /// <returns></returns>
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            MinimumAgeRequirement requirement) {
            // prende l'utente che ha effettuato il login
            var claim = context.User
                // recupera le sue claims
                .Claims
                // cerca la prima che sia Claims.Birthday
                .FirstOrDefault(c => c.Type == Claims.Birthday);

            // se la claim esiste!
            if (claim != null) {
                var birthday = Convert.ToDateTime(claim.Value);
                var age = DateTime.Now.Year - birthday.Year;
                if (age >= requirement.MinimumAge)
                    // indica che il controllo sia stato superato rispetto ad un requirement
                    context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
