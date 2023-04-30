using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UIStack
{
    public static GameObject Root;
    private static List<GameObject> panels = new List<GameObject>();

    public static T Push<T>(GameObject panelPrefab)
    {
        GameObject instanceObject = InstantiateObject(panelPrefab);

        return instanceObject.GetComponent<T>();
    }

    public static GameObject Push(GameObject panelPrefab)
    {
        GameObject instanceObject = InstantiateObject(panelPrefab);

        return instanceObject;
    }

    private static GameObject InstantiateObject(GameObject prefab)
    {
        if (Root == null)
        {
            Root = GameObject.Find("UIStack");
        }

        GameObject panel = GameObject.Instantiate(prefab, Root.transform);
        panel.transform.SetAsLastSibling();
        panels.Add(panel);

        Debug.Log($"Push : {panel.name}, Count : {panels.Count}");

        return panel;
    }

    public static void Pop()
    {
        GameObject panel = panels[panels.Count - 1];
        panels.RemoveAt(panels.Count - 1);

        GameObject.Destroy(panel);
    }

    public static GameObject Peek() => panels[panels.Count - 1];

    public static bool IsEmpty() => panels.Count == 1;
}
