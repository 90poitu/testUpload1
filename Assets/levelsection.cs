using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class levelsection : MonoBehaviour
{
    public GameObject[] level;
    public Sprite unlockTexture;
    public Sprite lockTexture;
    public save save;
    void Start()
    {
        save = GameObject.FindGameObjectWithTag("save").GetComponent<save>();

        if (!save.gameFile_.levelSelection[0])
        {
            save.gameFile_.levelSelection[0] = true;
        }
    }
    void Update()
    {
        for (int i = 0; i < level.Length; i++)
        {
            if (level[i])
            {
                RawImage levelImage = level[i].transform.Find("Image").GetComponent<RawImage>();

                if (!save.gameFile_.levelSelection[i])
                {
                    levelImage.texture = lockTexture.texture;
                }
                else
                {
                    levelImage.texture = unlockTexture.texture;
                }
            }
        }
    }

    public void SceneLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
