using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class avator : MonoBehaviour
{
    public RawImage mainAvatorPicture;
    public RawImage careerAvatorPicture;
    public Sprite[] pictures;
    public save save;
    void Start()
    {
        save = GameObject.FindGameObjectWithTag("save").GetComponent<save>();
    }
    void Update()
    {
        for (int i = 0; i < pictures.Length; i++)
        {
            mainAvatorPicture.texture = pictures[save.gameFile_.avatorIndex].texture;
        }

        careerAvatorPicture.texture = mainAvatorPicture.texture;
    }
    public void avatorIndex(int index) 
    {
        save.gameFile_.avatorIndex = index;
    }
}
