using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class levelTask : MonoBehaviour
{
    public GameObject[] task;
    public Sprite[] texture;
    public save save;
    public rewardIndicatorManager RewardManager;
    public Sprite checkMark;
    public audioManager audioManager_;
    void Start()
    {
        save = GameObject.FindGameObjectWithTag("save").GetComponent<save>();
    }
    void Update()
    {
        for (int i = 0; i < task.Length; i++)
        {
            if (task[i])
            {
                TMP_Text taskTitle = task[i].transform.Find("textBorder").Find("title").GetComponent<TMP_Text>();
                TMP_Text taskDescription = task[i].transform.Find("textBorder").Find("description").GetComponent<TMP_Text>();
                RawImage taskRewardIcon = task[i].transform.Find("itemBackground").Find("rewardIcon").GetComponent<RawImage>();
                TMP_Text taskReward = task[i].transform.Find("itemBackground").Find("rewardIcon").Find("rewardAmount").GetComponent<TMP_Text>();

                taskTitle.text = "Level " + i;

                if (texture[i].name.Contains("Coins"))
                {
                    taskReward.text = "x" + RewardManager.defaultCoinAmount;
                }
                else if (texture[i].name.Contains("Gems"))
                {
                    taskReward.text = "x" + RewardManager.defaultGemsAmount;
                }

                if (save.gameFile_.Leveltask[i])
                {
                    taskDescription.text = "Completed";
                    taskRewardIcon.texture = checkMark.texture;
                }
                else
                {
                    taskDescription.text = "Level <color=yellow>" + i;
                    taskDescription.text = "Level up to <color=yellow>" + i;
                    taskRewardIcon.texture = texture[i].texture;
                }
            }
        }
    }

    public void claimLevelTask(int index)
    {
        if (save.gameFile_.level >= index)
        {
            if (!save.gameFile_.Leveltask[index])
            {
                save.gameFile_.Leveltask[index] = true;

                if (texture[index].name.Contains("Coins"))
                {
                    RewardManager.giveReward(1, 1, "Coins", RewardManager.defaultCoinAmount);
                }

                if (texture[index].texture.name.Contains("Gems"))
                {
                    RewardManager.giveReward(1, 2, "Gems", RewardManager.defaultGemsAmount);
                }

                audioManager_.PlayAudio("RewardSound", 1);
            }
            else
            {
                audioManager_.PlayAudio("ErrorSound", 1);
            }
        }
        else
        {
            audioManager_.PlayAudio("ErrorSound", 1);
        }
    }
}
