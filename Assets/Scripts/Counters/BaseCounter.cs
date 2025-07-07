using System;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class BaseCounter : MonoBehaviour, IKitchenObjectParent, IInteractable
{
    [SerializeField] public Transform counterTopPoint;
    public static event EventHandler OnAnyObjectPlacedHere;
    public static void ResetStaticData()
    {
        OnAnyObjectPlacedHere = null;
    }
    // was private i made it protected
    protected KitchenObject kitchenObject;
    public abstract void Interact(Player player);
    public Transform GetKitchenObjectFollowTransform()
    {
        return counterTopPoint;
    }
    // this code is experimental
    protected void Invoke_OnAnyObjectPlacedHere()
    {
        OnAnyObjectPlacedHere?.Invoke(this, EventArgs.Empty);
    }
    // above code was experimental was ordinary method i made it virtual
    public virtual void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;

        if (kitchenObject != null)
            OnAnyObjectPlacedHere?.Invoke(this, EventArgs.Empty);
    }
    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }

    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObject()
    {
        return kitchenObject != null;
    }
}
