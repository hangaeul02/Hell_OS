using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PCBootSequence : MonoBehaviour
{
    public GameObject blackScreen;   // 꺼진 화면
    public GameObject loadingPanel;  // 로딩(로밍) 화면
    public GameObject desktopPanel;  // 바탕화면

    public AudioSource sfxSource;
    public AudioClip bootSound;      // XP 시작 사운드 (선택)

    void Start()
    {
        // 초기 상태: 모두 끄고 검은 화면만 켬
        blackScreen.SetActive(true);
        loadingPanel.SetActive(false);
        desktopPanel.SetActive(false);
    }

    // 외부(예: PC 클릭 시)에서 호출할 함수
    public void PowerOn()
    {
        StartCoroutine(BootRoutine());
    }

    IEnumerator BootRoutine()
    {
        // 1. 본체 돌아가는 소리와 함께 검은 화면 유지 (2초)
        yield return new WaitForSeconds(2f);
        blackScreen.SetActive(false);

        // 2. 로딩 화면 등장
        loadingPanel.SetActive(true);
        // 여기서 로딩 바 애니메이션을 넣으면 더 좋습니다.
        yield return new WaitForSeconds(4f);

        // 3. 로딩 끝, 바탕화면 진입
        loadingPanel.SetActive(false);
        desktopPanel.SetActive(true);

        // 4. XP 특유의 환영 사운드 재생
        if (bootSound != null) sfxSource.PlayOneShot(bootSound);
    }
}