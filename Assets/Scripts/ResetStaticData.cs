using UnityEngine;

public class ResetStaticData : MonoBehaviour
{
    void Awake()
    {
        CuttingCounter.ResetStaticData();
        BaseCounter.ResetStaticData();
        TrashCounter.ResetStaticData();
    }
}
