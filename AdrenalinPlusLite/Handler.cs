using LabApi.Events.Arguments.PlayerEvents;
using MEC;

namespace AdrenalinPlusLite;

public class Handler
{
    public ushort TotalHealValue { get; set; } = 40;
    public ushort HealPerTick { get; set; } = 1;
    public float HealFrequency { get; set; } = 0.05f;
    public float EffectsDelay { get; set; } = 1f;
    
    public void OnAdrenalineUsed(PlayerUsingItemEventArgs ev)
    {
        Timing.CallDelayed(EffectsDelay, () => // Задержка предусматривает время анимации, от начала и до укола
        {
            if (ev.UsableItem.Type == ItemType.Adrenaline && ev.Player.CurrentItem?.Type == ItemType.Adrenaline)
                Features.ProgressiveHeal(ev.Player, TotalHealValue, HealPerTick, HealFrequency);
        });
    }
}