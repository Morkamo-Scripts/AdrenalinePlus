using System;
using System.Collections;
using Exiled.API.Features;
using MEC;
using UnityEngine;

namespace AdrenalinePlus;

public class Features
{
    public static void ProgressiveHeal(Player player, ushort totalHeal, ushort healPerTick, float frequency)
        => DarkAPI.Handlers.CoroutineRunner.Run(ProgressiveHealing(player, totalHeal, healPerTick, frequency));
    
    private static IEnumerator ProgressiveHealing(Player player, ushort totalHeal, ushort healPerTick, float frequency)
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