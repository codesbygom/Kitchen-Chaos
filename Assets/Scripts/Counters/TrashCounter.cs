using System;
using UnityEngine;

public class TrashCounter : BaseCounter
{
    public static event EventHandler OnAnyObjectTranshed;
    public new static void ResetStaticData()
    {
        OnAnyObjectTranshed = null;
    }
    public override void Interact(Player player)
    {
        if (player.HasKitchenObject())
        {
            player.GetKitchenObject().DestroySelf();
            OnAnyObjectTranshed?.Invoke(this, EventArgs.Empty);
        }
    }
}
