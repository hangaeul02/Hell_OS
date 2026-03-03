using UnityEngine;
using System.Collections.Generic;

public class WindowManager : MonoBehaviour
{
    public static WindowManager Instance;

    [Header("모든 창 부모 오브젝트")]
    public Transform windowParent;

    private List<GameObject> activeWindows = new List<GameObject>();

    void Awake() => Instance = this;

    public void OpenWindow(GameObject windowPrefab)
    {
        windowPrefab.SetActive(true);
        FocusWindow(windowPrefab);

        if (!activeWindows.Contains(windowPrefab))
            activeWindows.Add(windowPrefab);
    }

    public void FocusWindow(GameObject window)
    {
        window.transform.SetAsLastSibling();
    }

    public void CloseWindow(GameObject window)
    {
        window.SetActive(false);
        activeWindows.Remove(window);
    }
}