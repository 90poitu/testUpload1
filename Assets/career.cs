using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class career : MonoBehaviour
{
    public Slider expSlider;
    public TMP_Text expAmountText;
    public TMP_Text levelAmountText;
    public Slider bpSlider;
    public TMP_Text bpAmountText;
    public levelManager levelManager_;
    public battlepass battlepass_;
    public save save;
    void Start()
    {
        save = GameObject.FindGameObjectWithTag("save").GetComponent<save>();   
    }
    void Update()
    {
        expSlider.maxValue = levelManager_.levelExp[save.gameFile_.level];
        expSlider.value = save.gameFile_.exp;
        expAmountText.text = expSlider.value + "/<color=blue>" + expSlider.maxValue;
        bpSlider.maxValue = battlepass_.bpExp[save.gameFile_.bpLevel];
        bpSlider.value = save.gameFile_.bpExp;
        bpAmountText.text = bpSlider.value + "/<color=blue>" + bpSlider.maxValue;

        levelAmountText.text = save.gameFile_.level.ToString();
    }
}
