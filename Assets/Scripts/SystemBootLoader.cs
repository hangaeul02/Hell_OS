using UnityEngine;
using System.Collections;

public class SystemBootLoader : MonoBehaviour
{
    public GameObject screenOff;
    public GameObject screenBoot;   
    public GameObject screenDesktop; 
    public float offDuration = 1.5f;
    public float bootDuration = 3.0f;
    public AudioClip bootSound;    

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) audioSource = gameObject.AddComponent<AudioSource>();
        StartCoroutine(BootProcess());
    }

    IEnumerator BootProcess()
    {
        screenOff.SetActive(true);
        screenBoot.SetActive(false);
        screenDesktop.SetActive(false);

        yield return new WaitForSeconds(offDuration);
        if (bootSound != null) audioSource.PlayOneShot(bootSound);

        screenOff.SetActive(false);
        screenBoot.SetActive(true);

        yield return new WaitForSeconds(bootDuration); 

        screenBoot.SetActive(false); 
        screenDesktop.SetActive(true); 

        ClipGuide clipGuide = FindObjectOfType<ClipGuide>(true); 
        if (clipGuide != null)
        {
            clipGuide.gameObject.SetActive(true);

            if (WindowManager.Instance != null)
            {
                WindowManager.Instance.FocusWindow(clipGuide.gameObject);
            }

            clipGuide.ShowMessage("Nice to meet you! I'm a clip that will help you with your work. Would you like to open your mailbox first?", 5f);
        }
        else
        {
            Debug.LogError("ClipGuide not found! Please check the placement of the hi-raki.");
        }
    }
}