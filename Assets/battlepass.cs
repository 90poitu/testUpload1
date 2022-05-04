using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class battlepass : MonoBehaviour
{
    public GameObject freeTiers;
    public Sprite[] tierReward;
    public Sprite noTierReward;
    public Sprite claimedTierReward;
    public rewardIndicatorManager rewardIndicatorManager_;
    public audioManager audioManager_;
    public TMP_Text levelText;
    public save save;
    public int[] bpExp;
    void Start()
    {
        save = GameObject.FindGameObjectWithTag("save").GetComponent<save>();
    }
    void Update()
    {
        levelText.text = "BP LEVEL " + save.gameFile_.bpLevel.ToString();

        for (int i = 0; i < freeTiers.transform.childCount; i++)
        {
            RawImage tierReward = freeTiers.transform.Find("itemBorder (" + i+")").Find("item 0").Find("item").GetComponent<RawImage>();
            TMP_Text tierRewardAmountText = freeTiers.transform.Find("itemBorder (" + i + ")").Find("item 0").Find("item").Find("Text (TMP)").GetComponent<TMP_Text>();

            if (this.tierReward[i])
            {
                if (save.gameFile_.bpCollected[i])
                {
                    tierReward.texture = claimedTierReward.texture;
                }
                else
                {
                    tierReward.texture = this.tierReward[i].texture;
                }
                tierReward.color = Color.white;
                if (this.tierReward[i].name.Contains("Coins"))
                {
                    tierRewardAmountText.text = "X" + rewardIndicatorManager_.defaultCoinAmount.ToString();
                }
                if (this.tierReward[i].name.Contains("Gems"))
                {
                    tierRewardAmountText.text = "X" + rewardIndicatorManager_.defaultGemsAmount.ToString();
                }
                if (this.tierReward[i].name.Contains("Iron"))
                {
                    tierRewardAmountText.text = "X" + rewardIndicatorManager_.defaultExpAmount.ToString();
                }
                if (this.tierReward[i].name.Contains("ewew2fdes"))
                {
                    tierRewardAmountText.text = "X1";
                }
            }
            else
            {
                tierReward.color = Color.blue;
                tierReward.texture = noTierReward.texture;
            }
        }

        bpLevelup();
    }
    public void claimBpReward(int index)
    {
        if (save.gameFile_.bpLevel >= index)
        {
            if (!save.gameFile_.bpCollected[index])
            {
                if (tierReward[index])
                {
                    if (tierReward[index].name.Contains("Coins"))
                    {
                        rewardIndicatorManager_.giveReward(1, 1, "Coins", rewardIndicatorManager_.defaultCoinAmount);
                    }
                    if (tierReward[index].name.Contains("Gems"))
                    {
                        rewardIndicatorManager_.giveReward(1, 2, "Gems", rewardIndicatorManager_.defaultGemsAmount);
                    }
                    if (this.tierReward[index].name.Contains("Iron"))
                    {
                        rewardIndicatorManager_.giveReward(1, 5, "Exp", rewardIndicatorManager_.defaultExpAmount);
                    }
                    if (this.tierReward[index].name.Contains("wewdsdd"))
                    {
                        rewardIndicatorManager_.giveReward(1, 7, "Emote #0 ", 1);
                    }
                    if (this.tierReward[index].name.Contains("ewew2dfdes"))
                    {
                        rewardIndicatorManager_.giveReward(1, 6, "Emote #1 ", 1);
                    }
                    if (this.tierReward[index].name.Contains("wewdwsd"))
                    {
                        rewardIndicatorManager_.giveReward(1, 8, "Emote #2 ", 1);
                    }
                }
                else
                {
                    rewardIndicatorManager_.giveReward(1, 4, "Nothing", 0);

                    Debug.Log("This index does not have reward");
                }

                audioManager_.PlayAudio("RewardSound", 1);
                save.gameFile_.bpCollected[index] = true;
                Debug.Log("You claimed level " + index + " reward");
            }
        }
        else
        {
            audioManager_.PlayAudio("ErrorSound", 1);
            Debug.Log("You need to reach at least level " + index + " to unlock this");
        }
    }
    public void claimAll()
    {
        for (int i = 0; i < freeTiers.transform.childCount; i++)
        {
            if (save.gameFile_.bpLevel >= i)
            {
                if (!save.gameFile_.bpCollected[i])
                {
                    save.gameFile_.bpCollected[i] = true;

                    if (tierReward[i])
                    {
                        if (tierReward[i].name.Contains("Coins"))
                        {
                            rewardIndicatorManager_.giveReward(1, 1, "Coins", rewardIndicatorManager_.defaultCoinAmount);
                        }
                        if (tierReward[i].name.Contains("Gems"))
                        {
                            rewardIndicatorManager_.giveReward(1, 2, "Gems", rewardIndicatorManager_.defaultGemsAmount);
                        }
                        if (this.tierReward[i].name.Contains("Iron"))
                        {
                            rewardIndicatorManager_.giveReward(1, 5, "Exp", rewardIndicatorManager_.defaultExpAmount);
                        }
                        if (this.tierReward[i].name.Contains("wewdsdd"))
                        {
                            rewardIndicatorManager_.giveReward(1, 7, "Emote #0 ", 1);
                        }
                        if (this.tierReward[i].name.Contains("ewew2dfdes"))
                        {
                            rewardIndicatorManager_.giveReward(1, 6, "Emote #1 ", 1);
                        }
                        if (this.tierReward[i].name.Contains("wewdwsd"))
                        {
                            rewardIndicatorManager_.giveReward(1, 8, "Emote #2 ", 1);
                        }
                    }
                    else
                    {
                        rewardIndicatorManager_.giveReward(1, 4, "Nothing", 0);

                        Debug.Log("This index does not have reward");
                    }

                    audioManager_.PlayAudio("RewardSound", 1);
                    save.gameFile_.bpCollected[i] = true;
                    Debug.Log("You claimed level " + i + " reward");
                }
            }
        }
    }

    void bpLevelup()
    {
        if (save.gameFile_.bpExp >= bpExp[save.gameFile_.bpLevel] && save.gameFile_.bpLevel < (bpExp.Length - 1))
        {
            save.gameFile_.bpExp -= bpExp[save.gameFile_.bpLevel];
            save.gameFile_.bpLevel++;
            rewardIndicatorManager_.giveReward(1, 0, "Bp level up", 1);
            audioManager_.PlayAudio("RewardSound", 1);
        }
    }
}
