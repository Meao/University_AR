using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Gaze : MonoBehaviour
{
    List<infoBehavior> infos = new List<infoBehavior>();

    void Start()
    {
        infos = FindObjectsOfType<infoBehavior>().ToList();
    }

    void Update()
    {
        if (Physics.Raycast(transform.position,transform.forward, out RaycastHit hit))
        {
            GameObject go = hit.collider.gameObject;
            if (go.CompareTag("hasInfo"))
            {
                OpenInfo(go.GetComponent<infoBehavior>());
            }
        } else
        {
            CloseAll();
        }
    }

    void OpenInfo(infoBehavior desiredInfo)
    {
        foreach (infoBehavior info in infos)
        {
            if (info == desiredInfo)
            {
                info.OpenInfo();
            } else
            {
                info.CloseInfo();
            }
        }
    }

    void CloseAll()
    {
        foreach (infoBehavior info in infos)
        {
            info.CloseInfo();
        }
    }
}
