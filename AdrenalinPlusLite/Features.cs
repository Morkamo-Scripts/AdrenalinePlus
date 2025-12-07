using System.Collections;
using System.Collections.Generic;
using Exiled.API.Features;
using MEC;

namespace AdrenalinPlusLite;

public class Features
{
    public static void ProgressiveHeal(Player player, ushort totalHeal, ushort healPerTick, float frequency)
        => Timing.RunCoroutine(ProgressiveHealing(player, totalHeal, healPerTick, frequency));
    
    private static IEnumerator<float> ProgressiveHealing(Player player, ushort totalHeal, ushort healPerTick, float frequency)
    {
        ushort healed = 0;

        while (player != null && player.IsAlive && healed < totalHeal)
        {
            ushort remaining = (ushort)(totalHeal - healed);

            if (remaining < healPerTick)
            {
                player.Heal(remaining);
                break;
            }

            player.Heal(healPerTick);
            healed += healPerTick;

            yield return Timing.WaitForSeconds(frequency);
        }
    }
}