using UnityEngine;

public class MonitorController : MonoBehaviour
{
    [Header("화면들")]
    public GameObject loginScreen;
    public GameObject desktopScreen;

    [Header("오디오")]
    public AudioSource audioSource;  
    public AudioClip clickSound;   
    public void OnLoginButtonClick()
    {
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }
        loginScreen.SetActive(false);
        desktopScreen.SetActive(true);
    }
}