using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    public int[] levelExp;
    public rewardIndicatorManager rewardManager;
    public audioManager audioManager_;
    public save save;
    void Start()
    {
        save = GameObject.FindGameObjectWithTag("save").GetComponent<save>();
    }
    void Update()
    {
        if (save.gameFile_.exp >= levelExp[save.gameFile_.level] && save.gameFile_.level < (levelExp.Length - 1))
        {
            save.gameFile_.exp -= levelExp[save.gameFile_.level];
            save.gameFile_.level++;
            rewardManager.giveReward(1, 0, "Level", 1);
            rewardManager.giveReward(1, 3, "Check LevelTask to claim more", 0);
        }
    }
}
