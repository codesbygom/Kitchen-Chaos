using System;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moveUp;
    [SerializeField] private TextMeshProUGUI moveDown;
    [SerializeField] private TextMeshProUGUI moveLeft;
    [SerializeField] private TextMeshProUGUI moveRight;
    [SerializeField] private TextMeshProUGUI interact;
    [SerializeField] private TextMeshProUGUI interactAlternate;
    [SerializeField] private TextMeshProUGUI pause;
    [SerializeField] private TextMeshProUGUI interactGamepad;
    [SerializeField] private TextMeshProUGUI interactAlternateGamepad;
    [SerializeField] private TextMeshProUGUI pauseGamepad;
    private void Start()
    {
        GameInput.Instance.OnBindingRebind += GameInput_OnBindingRebind;
        GameManager.Instance.OnStateChanged += GameManager_OnStateChanged;
        UpdateVisual();
        Show();
    }
    private void GameManager_OnStateChanged(object sender, EventArgs e)
    {
        if (GameManager.Instance.IsCountDownToStartActive())
        {
            Hide();
        }
    }
    private void GameInput_OnBindingRebind(object sender, EventArgs e)
    {
        UpdateVisual();
    }
    private void UpdateVisual()
    {
        moveUp.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        moveDown.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        moveLeft.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        moveRight.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        interact.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        interactAlternate.text = GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlternate);
        pause.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
        interactGamepad.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Interact);
        interactAlternateGamepad.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_InteractAlternate);
        pauseGamepad.text = GameInput.Instance.GetBindingText(GameInput.Binding.GamePad_Pause);
    }
    private void Show()
    {
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
