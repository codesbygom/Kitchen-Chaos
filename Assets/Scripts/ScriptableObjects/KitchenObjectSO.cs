using UnityEngine;

[CreateAssetMenu(fileName = "KitchenObjectsSO", menuName = "Scriptable Objects/KitchenObjectsSO")]
public class KitchenObjectSO : ScriptableObject
{
    public Transform Prefab;
    public Sprite Sprite;
    public string ObjectName;

}