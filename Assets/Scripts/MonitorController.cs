using UnityEngine;

public class MonitorController : MonoBehaviour
{
    [Header("화면들")]
    public GameObject loginScreen;   // 로그인 화면 그룹
    public GameObject desktopScreen; // 바탕화면 그룹

    [Header("오디오")]
    public AudioSource audioSource;  // 소리 나오는 스피커
    public AudioClip clickSound;     // 삑- 소리 파일

    // 버튼이 눌리면 실행될 함수
    public void OnLoginButtonClick()
    {
        // 1. 삑 소리 재생
        if (audioSource != null && clickSound != null)
        {
            audioSource.PlayOneShot(clickSound);
        }

        // 2. 화면 전환 (로그인 끄고, 바탕화면 켜고)
        loginScreen.SetActive(false);
        desktopScreen.SetActive(true);
    }
}