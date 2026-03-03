using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public static TaskManager Instance;

    [Header("9가지 업무 창 프리팹/오브젝트")]
    public GameObject[] taskWindows;

    public int currentTaskIndex = -1;

    void Awake() => Instance = this;

    // 무작위로 업무 배정
    public void AssignRandomTask()
    {
        // 기존 업무가 있다면 닫기
        if (currentTaskIndex != -1)
            WindowManager.Instance.CloseWindow(taskWindows[currentTaskIndex]);

        // 새로운 랜덤 업무 선택
        currentTaskIndex = Random.Range(0, taskWindows.Length);

        // WindowManager를 통해 창 열기
        WindowManager.Instance.OpenWindow(taskWindows[currentTaskIndex]);

        Debug.Log($"새 업무 배정: {taskWindows[currentTaskIndex].name}");
    }
}