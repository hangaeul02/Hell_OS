using UnityEngine;

public class MailManager : MonoBehaviour
{
    [Header("연결할 객체")]
    public ClipGuide clip; // ClipGuide 스크립트 연결

    /// <summary>
    /// 메일 창에서 '확인' 또는 '업무 시작' 버튼을 눌렀을 때 호출합니다.
    /// </summary>
    public void OpenBossMail()
    {
        if (clip != null)
        {
            // 1. Clip이 대사를 출력합니다.
            clip.ShowMessage("상사님의 업무 지시서야. '비명 소리 분류' 업무를 시작해봐!", 4f);
        }

        // 2. 1.5초 뒤에 실제 업무 창을 띄웁니다.
        Invoke("TriggerFirstTask", 1.5f);
    }

    private void TriggerFirstTask()
    {
        if (TaskManager.Instance != null)
        {
            // TaskManager를 통해 무작위 업무 창 활성화
            TaskManager.Instance.AssignRandomTask();
        }
        else
        {
            Debug.LogWarning("TaskManager 인스턴스를 찾을 수 없습니다.");
        }
    }

    /// <summary>
    /// 바이러스 링크 클릭 시 이벤트 (공포 연출용)
    /// </summary>
    public void ClickVirusLink()
    {
        if (clip != null)
        {
            clip.ShowMessage("안 돼! 그 링크는 누르면 안... 시 스 템 오 류 ...", 3f);
        }
        // 여기에 화면 흔들림이나 기괴한 사운드 추가 가능
    }
}