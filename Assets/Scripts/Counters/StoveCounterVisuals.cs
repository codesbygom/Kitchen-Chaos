using UnityEngine;

public class StoveCounterVisuals : MonoBehaviour
{
    [SerializeField] public GameObject stoveOnGameObject;
    [SerializeField] public GameObject particleGameObject;
    [SerializeField] public StoveCounter stoveCounter;
    private void Start()
    {
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
    }
    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e)
    {
        bool showVisual = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;
        stoveOnGameObject.SetActive(showVisual);
        particleGameObject.SetActive(showVisual);
    }
}
