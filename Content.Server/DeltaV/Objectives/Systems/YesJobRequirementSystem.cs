using Content.Shared.Objectives.Components;
using Content.Shared.Roles.Jobs;

namespace Content.Server.Objectives.Systems;

/// <summary>
/// Handles checking the job whitelist for this objective.
/// </summary>
public sealed class YesJobRequirementSystem : EntitySystem
{
    public override void Initialize()
    {
        base.Initialize();

        SubscribeLocalEvent<YesJobRequirementComponent, RequirementCheckEvent>(OnCheck);
    }

    private void OnCheck(EntityUid uid, YesJobRequirementComponent comp, ref RequirementCheckEvent args)
    {
        if (args.Cancelled)
            return;

        // if player has no job then don't care
        if (!TryComp<JobComponent>(args.MindId, out var job))
            return;

        if (job.Prototype != comp.Job)
            args.Cancelled = true;
    }
}
