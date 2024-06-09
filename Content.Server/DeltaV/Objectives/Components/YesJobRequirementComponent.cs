using Content.Server.Objectives.Systems;
using Content.Shared.Roles;
using Content.Shared.Roles.Jobs;
using Robust.Shared.Serialization.TypeSerializers.Implementations.Custom.Prototype;

/// <summary>
/// Requires that the player have a certain job to have this objective.
/// </summary>
[RegisterComponent, Access(typeof(YesJobRequirementSystem))]
public sealed partial class YesJobRequirementComponent : Component
{
    /// <summary>
    /// ID of the job to allow having this objective.
    /// </summary>
    [DataField(required: true, customTypeSerializer: typeof(PrototypeIdSerializer<JobPrototype>))]
    public string Job = string.Empty;
}
