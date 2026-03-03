using UnityEngine;

public class MailManager : MonoBehaviour
{
    public ClipGuide clip;

    public void OpenBossMail()
    {
        if (clip != null)
        {
            clip.ShowMessage("상사님의 업무 지시서야. '비명 소리 분류' 업무를 시작해봐!", 4f);
        }
        Invoke("TriggerFirstTask", 1.5f);
    }

    private void TriggerFirstTask()
    {
        if (TaskManager.Instance != null)
        {
            TaskManager.Instance.AssignRandomTask();
        }
        else
        {
            Debug.LogWarning("TaskManager 인스턴스를 찾을 수 없습니다.");
        }
    }

    public void ClickVirusLink()
    {
        if (clip != null)
        {
            clip.ShowMessage("안 돼! 그 링크는 누르면 안... 시 스 템 오 류 ...", 3f);
        }
    }
}