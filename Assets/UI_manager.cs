using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UI_manager : MonoBehaviour
{
    public static UI_manager instance;

    public GameObject indicator;
    public audioManager audioManager_;
    public career career_;
    public GameObject container;

    public Vector3 popupPos;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void openPanel(GameObject go)
    {
        if (go)
        {
            go.SetActive(true);
            audioManager_.PlayAudio("ClickingSound", 1);
        }
    }
    public void quitPanel(GameObject go)
    {
        if (go.activeInHierarchy)
        {
            if (go)
            {
                go.SetActive(false);
            }
        }
    }
    public void hover(GameObject go)
    {
        container = go;

        if (!go.activeInHierarchy)
        {
            go.SetActive(true);
        }
        else
        {
            go.SetActive(false);
        }
    }
    public void hoverParent(Transform parentContainer)
    {
        container.transform.SetParent(parentContainer);

        container.transform.localPosition = popupPos;
    }

    public void hoverMessage(string msg)
    {
        TMP_Text text = container.transform.Find("Text (TMP)").GetComponent<TMP_Text>();
        text.text = msg;
    }
}
