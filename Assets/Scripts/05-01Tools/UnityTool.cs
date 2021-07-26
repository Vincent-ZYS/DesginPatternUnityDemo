using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnityTool
{
    public static Transform FindChildGo(GameObject parent, string goName)
    {
        Transform[] childrenGoArr = parent.GetComponentsInChildren<Transform>();
        Transform outPutChildTf = null;
        int isFindNum = 0;
        try
        {
            foreach (Transform item in childrenGoArr)
            {
                if (item.name == goName)
                {
                    outPutChildTf = item;
                    isFindNum++;
                    if (isFindNum >= 2) { Debug.LogWarning("The Current Find target Child Go is Existing more than 2!"); break; }
                }
            }
        }catch
        {
            throw new MissingReferenceException();
        }
        return outPutChildTf;
    }

    public static void AttachGo(GameObject parent, GameObject child)
    {
        child.transform.SetParent(parent.transform);
        child.transform.localPosition = Vector3.zero;
        child.transform.localScale = Vector3.one;
        child.transform.eulerAngles = Vector3.zero; 
    }
}
