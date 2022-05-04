using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class dailyLogin : MonoBehaviour
{
    public GameObject[] loginRewardImage;
    public Sprite[] rewardTexture;
    public rewardIndicatorManager rewardIndicatorManager_;
    public DayOfWeek currentDayOfWeek;
    public save save;
    public TMP_Text loginAmount;
    public Sprite completeTexture;
    void Start()
    {
        currentDayOfWeek = DateTime.Today.DayOfWeek;

        save = GameObject.FindGameObjectWithTag("save").GetComponent<save>();

        loginAmount.text = "Login: " +save.gameFile_.totalLogin.ToString();
    }
    void Update()
    {
        for (int i = 0; i < loginRewardImage.Length; i++)
        {
            if (save.gameFile_.totalLogin >= (save.gameFile_.loginDay.Length))
            {
                save.gameFile_.totalLogin = 0;

                for (int k = 0; k < save.gameFile_.loginDay.Length; k++)
                {
                    save.gameFile_.loginDay[k] = false;
                }
            }
        }

        for (int i = 0; i < loginRewardImage.Length; i++)
        {
            if (loginRewardImage[i])
            {
                TMP_Text rewardAmountText = loginRewardImage[i].transform.Find("border").Find("itemAmount").GetComponent<TMP_Text>();
                RawImage rewardImage = loginRewardImage[i].transform.Find("border").Find("item").GetComponent<RawImage>();
                Button itemButton = loginRewardImage[i].transform.Find("border").Find("item").GetComponent<Button>();
          
                if (rewardTexture[i].name.Contains("Coins"))
                {
                    rewardAmountText.text = "x" + rewardIndicatorManager_.defaultCoinAmount.ToString();
                }

                else if (rewardTexture[i].name.Contains("Gems"))
                {
                    rewardAmountText.text = "x" + rewardIndicatorManager_.defaultGemsAmount.ToString();
                }

                if (rewardTexture[i])
                {
                    if (save.gameFile_.loginDay[i])
                    {
                        rewardImage.texture = completeTexture.texture;
                        itemButton.interactable = false;
                    }
                    else
                    {
                        rewardImage.texture = rewardTexture[i].texture;
                        itemButton.interactable = true;
                    }
                }

            }
        }
    }
    public void claimLoginTask(int index)
    {
        if ((int)currentDayOfWeek >= index)
        {
            if (!save.gameFile_.loginDay[index])
            {
                save.gameFile_.loginDay[index] = true;

                save.gameFile_.totalLogin++;
                loginAmount.text = "Login: " + save.gameFile_.totalLogin.ToString();

                if (rewardTexture[index].name.Contains("Coins"))
                {
                    rewardIndicatorManager_.giveReward(1, 1, "Coins", rewardIndicatorManager_.defaultCoinAmount);
                }
                if (rewardTexture[index].name.Contains("Gems"))
                {
                    rewardIndicatorManager_.giveReward(1, 2, "Gems", rewardIndicatorManager_.defaultGemsAmount);
                }
            }
        }
    }
}
