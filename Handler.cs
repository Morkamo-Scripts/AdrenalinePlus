using DarkAPI.Handlers.Components;
using Exiled.API.Features;
using LabApi.Events.Arguments.PlayerEvents;
using LabApi.Features.Wrappers;
using MEC;

namespace AdrenalinePlus;

public class Handler : IEventsRegistrator
{
    public void RegisterEvents() => LabApi.Events.Handlers.PlayerEvents.UsingItem += OnAdrenalineUsed;
    public void UnregisterEvents() => LabApi.Events.Handlers.PlayerEvents.UsingItem -= OnAdrenalineUsed;

    public ushort TotalHealValue { get; set; } = 50;
    public ushort HealPerTick { get; set; } = 1;
    public float HealFrequency { get; set; } = 0.04f;
    public float EffectsDelay { get; set; } = 1f;
    
    private void OnAdrenalineUsed(PlayerUsingItemEventArgs ev)
    {
        Timing.CallDelayed(EffectsDelay, () => // Задержка предусматривает время анимации, от начала и до укола
        {
            if (ev.UsableItem.Type == ItemType.Adrenaline && ev.Player.CurrentItem?.Type == ItemType.Adrenaline)
                Features.ProgressiveHeal(ev.Player, TotalHealValue, HealPerTick, HealFrequency);
        });
    }
}