using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class rewardIndicatorManager : MonoBehaviour
{
    public GameObject rewardSpawnedItem;
    public Transform rewardSpawnedContainer;
    public Sprite[] textures;
    public int index;
    public save save;
    public GameObject indicator;
    public int defaultCoinAmount;
    public int defaultGemsAmount;
    public int defaultExpAmount;
    public audioManager audioManager_;
    void Start()
    {
        save = GameObject.FindGameObjectWithTag("save").GetComponent<save>();
    }
    /// <summary>
    /// Use this method to give rewards to the player - follow the number
    /// 0 - coins
    /// </summary>
    /// <param name="spawnedRewardNumber"></param>
    /// <param name="index"></param>
    /// <param name="itemTitle"></param>
    /// <param name="rewardAmount"></param>
    /// <param name="rewardTexture"></param>
    public void giveReward(int spawnedRewardNumber, int itemIndex, string itemTitle, int rewardAmount)
    {
        indicator.SetActive(true);

        this.index = itemIndex;

        for (int i = 0; i < spawnedRewardNumber; i++)
        {
            GameObject item = Instantiate(rewardSpawnedItem, rewardSpawnedContainer.position, Quaternion.identity);

            item.transform.SetParent(rewardSpawnedContainer);

            RawImage rewardImage = item.transform.Find("rewardImage").GetComponent<RawImage>();
            TMP_Text rewardTitle = rewardImage.transform.Find("Text (TMP)").GetComponent<TMP_Text>();

            rewardImage.texture = textures[index].texture;
            rewardTitle.text = itemTitle + " x " + rewardAmount;

            if (textures[index].name.Contains("Coin"))
            {
                save.gameFile_.coins += rewardAmount;
            }
            if (textures[index].name.Contains("Gems"))
            {
                save.gameFile_.crystal += rewardAmount;
            }
            if (textures[index].name.Contains("Iron"))
            {
                save.gameFile_.exp += rewardAmount;
            }
            if (textures[index].name.Contains("wewdsdd"))
            {
                save.gameFile_.emotes[0] = true;
            }
            if (textures[index].name.Contains("ewew2dfdes"))
            {
                save.gameFile_.emotes[1] = true;
            }
            if (textures[index].name.Contains("wewdwsd"))
            {
                save.gameFile_.emotes[2] = true;
            }

            audioManager_.PlayAudio("RewardSound", 1);
        }
    }
    public void rewardIndicatorClose()
    {
        if (rewardSpawnedContainer.transform.childCount > 0)
        {
            for (int i = 0; i < rewardSpawnedContainer.transform.childCount; i++)
            {
                Destroy(rewardSpawnedContainer.transform.GetChild(i).gameObject);
            }

        }

        indicator.SetActive(false);
    }
}
