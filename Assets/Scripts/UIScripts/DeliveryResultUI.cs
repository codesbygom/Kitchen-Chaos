using System;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class DeliveryResultUI : MonoBehaviour
{
    private const string POPUP_ANIMATOR = "POPUP";
    [SerializeField] private Image backgroundImage;
    [SerializeField] private TextMeshProUGUI messageText;
    [SerializeField] private Color successColor = Color.green;
    
    [SerializeField] private Color failedColor = Color.red;
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        DeliveryManagement.Instance.OnRecipeSucceded += DeliveryManagement_OnRecipeSucceded;
        DeliveryManagement.Instance.OnRecipeFailed += DeliveryManagement_OnRecipeFailed;
        gameObject.SetActive(false);
    }
    void DeliveryManagement_OnRecipeFailed(object sender, EventArgs e)
    {
        gameObject.SetActive(true);
        backgroundImage.color = failedColor;
        messageText.text = "Delivery\nFailed";
        animator.SetTrigger(POPUP_ANIMATOR);
    }
    void DeliveryManagement_OnRecipeSucceded(object sender, EventArgs e)
    {
        gameObject.SetActive(true);
        backgroundImage.color = successColor;
        messageText.text = "Delivery\nSuccess";
        animator.SetTrigger(POPUP_ANIMATOR);    
    }
}
