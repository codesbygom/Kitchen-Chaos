using UnityEngine;

[CreateAssetMenu(fileName = "BuningRecipeSO", menuName = "Scriptable Objects/BuningRecipeSO")]
public class BurningRecipeSO : ScriptableObject
{
    public KitchenObjectSO input;
    public KitchenObjectSO output;
    public float burningTimerMax;
}