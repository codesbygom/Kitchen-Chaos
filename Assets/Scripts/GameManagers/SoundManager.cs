using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private const string PLAYER_PREFS_SOUND_EFFECTS_VOLUME = "SoundEffectsVolume";
    public static SoundManager Instance { get; private set; }
    [SerializeField] private AudioClipsSO audioClipsSO;
    [SerializeField] private float volume = 1f;
    public void Start()
    {
        DeliveryManagement.Instance.OnRecipeSucceded += DeliveryManagement_OnRecipeSucceded;
        DeliveryManagement.Instance.OnRecipeFailed += DeliveryManagement_OnRecipeFailed;
        CuttingCounter.OnAnyCut += CuttingCounter_OnAnyCut;
        Player.Instance.OnPickedSomething += Player_OnPickedSomething;
        BaseCounter.OnAnyObjectPlacedHere += BaseCounter_OnAnyObjectPlacedHere;
        TrashCounter.OnAnyObjectTranshed += TrashCounter_OnAnyObjectTranshed;
    }
    private void Awake()
    {
        volume = PlayerPrefs.GetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME,1f);
        Instance = this;
    }
    private void TrashCounter_OnAnyObjectTranshed(object sender, EventArgs e)
    {
        TrashCounter trashCounter = sender as TrashCounter;
        PlaySound(audioClipsSO.trash, trashCounter.transform.position, volume);
    }
    private void BaseCounter_OnAnyObjectPlacedHere(object sender, EventArgs e)
    {
        BaseCounter baseCounter = sender as BaseCounter;
        PlaySound(audioClipsSO.objectDrop, baseCounter.transform.position, volume);
    }
    private void Player_OnPickedSomething(object sender, EventArgs e)
    {
        Player player = sender as Player;
        PlaySound(audioClipsSO.objectPickup, player.transform.position, volume);
    }
    private void CuttingCounter_OnAnyCut(object sender, EventArgs e)
    {
        CuttingCounter cuttingCounter = sender as CuttingCounter;
        PlaySound(audioClipsSO.chop, cuttingCounter.transform.position, volume);
    }
    private void DeliveryManagement_OnRecipeSucceded(object sender, EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySound(audioClipsSO.deliverySuccess, deliveryCounter.transform.position);
    }
    private void DeliveryManagement_OnRecipeFailed(object sender, EventArgs e)
    {
        DeliveryCounter deliveryCounter = DeliveryCounter.Instance;
        PlaySound(audioClipsSO.deliveryFail, deliveryCounter.transform.position, volume);
    }

    public void PlaySound(AudioClip[] audioClipArray, Vector3 position, float volume = 1)
    {
        AudioSource.PlayClipAtPoint(audioClipArray[UnityEngine.Random.Range(0, audioClipArray.Length)], position, volume);
    }
    public void PlaySound(AudioClip audioClip, Vector3 position, float volume = 1)
    {
        AudioSource.PlayClipAtPoint(audioClip, position, volume);
    }
    public void PlayFootStepsSound(Vector3 position, float volume = 1)
    {
        PlaySound(audioClipsSO.footstep, position, volume);
    }
    public void PlayCountdownSound()
    {
        PlaySound(audioClipsSO.warning, Vector3.zero, volume);
    }
    public void PlayWarningSound(Vector3 position)
    {
        PlaySound(audioClipsSO.warning, position, volume);
    }

    public void ChangeVolume()
    {
        volume += 0.1f;
        volume = Mathf.Round(volume * 10f) / 10f;
        if (volume > 1f)
        {
            volume = 0f;
        }
        PlayerPrefs.SetFloat(PLAYER_PREFS_SOUND_EFFECTS_VOLUME, volume);
        PlayerPrefs.Save();
    }
    public float GetVolume()
    {
        return volume;
    }
}
