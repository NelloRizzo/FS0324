using Microsoft.AspNetCore.Authorization;

/// <summary>
/// Gestione di un requisità di età minima.
/// </summary>
/// <remarks>Indica al sistema i dati per la gestione di una policy.</remarks>
public class MinimumAgeRequirement : IAuthorizationRequirement
{
    /// <summary>
    /// Età minima alla quale fare riferimento per la gestione della policy.
    /// </summary>
    public int MinimumAge { get; }

    public MinimumAgeRequirement(int minimumAge) {
        MinimumAge = minimumAge;
    }
}