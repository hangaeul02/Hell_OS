using UnityEngine;
using System.Collections;

public class SystemBootLoader : MonoBehaviour
{
    [Header("화면 연결")]
    public GameObject screenOff;      // 1. 검은 화면
    public GameObject screenBoot;     // 2. 부팅 이미지 (로고)
    public GameObject screenDesktop;  // 3. 바탕화면

    [Header("설정")]
    public float offDuration = 1.5f;  // 검은 화면 지속 시간
    public float bootDuration = 3.0f; // 로고 보여주는 시간
    public AudioClip bootSound;       // 부팅 소리 (지이잉-)

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null) audioSource = gameObject.AddComponent<AudioSource>();

        // 시작하자마자 코루틴 실행
        StartCoroutine(BootProcess());
    }

    IEnumerator BootProcess()
    {
        // ----------------------------------------
        // 1단계: 검은 화면 (전원 들어오기 전)
        // ----------------------------------------
        screenOff.SetActive(true);
        screenBoot.SetActive(false);
        screenDesktop.SetActive(false);

        yield return new WaitForSeconds(offDuration); // 1.5초 대기

        // ----------------------------------------
        // 2단계: 부팅 로고 화면 (에셋 보여주기)
        // ----------------------------------------

        // 소리 재생
        if (bootSound != null) audioSource.PlayOneShot(bootSound);

        screenOff.SetActive(false); // 검은 화면 끄고
        screenBoot.SetActive(true); // 로고 보여줌

        yield return new WaitForSeconds(bootDuration); // 3초간 로고 감상

        // ----------------------------------------
        // 3단계: 바탕화면 진입 (부팅 완료)
        // ----------------------------------------
        screenBoot.SetActive(false); // 로고 끄고
        screenDesktop.SetActive(true); // 바탕화면 짠!


        ClipGuide clipGuide = FindObjectOfType<ClipGuide>(true); // 꺼져있는 오브젝트도 찾기 위해 true 추가
        if (clipGuide != null)
        {
            clipGuide.gameObject.SetActive(true);

            // WindowManager 인스턴스가 생성되었는지 확인 후 호출
            if (WindowManager.Instance != null)
            {
                WindowManager.Instance.FocusWindow(clipGuide.gameObject);
            }

            // 말풍선 대사 출력
            clipGuide.ShowMessage("Nice to meet you! I'm a clip that will help you with your work. Would you like to open your mailbox first?", 5f);
        }
        else
        {
            Debug.LogError("ClipGuide not found! Please check the placement of the hi-raki.");
        }
    }
}