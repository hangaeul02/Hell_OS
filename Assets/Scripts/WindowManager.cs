using UnityEngine;
using System.Collections.Generic;

public class WindowManager : MonoBehaviour
{
    public static WindowManager Instance;

    [Header("모든 창 부모 오브젝트")]
    public Transform windowParent; // MonitorCanvas 내의 Windows 그룹

    private List<GameObject> activeWindows = new List<GameObject>();

    void Awake() => Instance = this;

    // 1. 창 열기 및 포커스
    public void OpenWindow(GameObject windowPrefab)
    {
        windowPrefab.SetActive(true);
        FocusWindow(windowPrefab);

        if (!activeWindows.Contains(windowPrefab))
            activeWindows.Add(windowPrefab);
    }

    // 2. 창을 가장 앞으로 가져오기 (Z-Order 관리)
    public void FocusWindow(GameObject window)
    {
        // Hierarchy 상에서 가장 아래에 위치할수록 UI는 가장 앞에 보임
        window.transform.SetAsLastSibling();
    }

    // 3. 창 닫기
    public void CloseWindow(GameObject window)
    {
        window.SetActive(false);
        activeWindows.Remove(window);
    }
}