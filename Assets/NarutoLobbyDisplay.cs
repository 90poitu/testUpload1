using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NarutoLobbyDisplay : MonoBehaviour
{
    public TMP_Text versionText;
    public TMP_Text levelAmountText;
    public TMP_Text crystalAmount;
    public TMP_Text coinAmount;
    public TMP_Text bpLevelAmount;
    public save save;
    void Start()
    {
        save = GameObject.FindGameObjectWithTag("save").GetComponent<save>();
        versionText.text = Application.version;

    }
    void Update()
    {
        levelAmountText.text = save.gameFile_.level.ToString();
        coinAmount.text = save.gameFile_.coins.ToString();
        crystalAmount.text = save.gameFile_.crystal.ToString();
        bpLevelAmount.text = save.gameFile_.bpLevel.ToString();
    }
}
