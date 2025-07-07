 using System;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    private const string CUT = "Cut";
    [SerializeField] private CuttingCounter cuttingCounter;
    private Animator animator;
    void Awake()
    {
        animator = GetComponent<Animator>();

    }
    void Start()
    {
        cuttingCounter.OnCut += ContainerCounter_OnCut;
    }

    private void ContainerCounter_OnCut(object sender, EventArgs e)
    {
        animator.SetTrigger(CUT);
    }
}