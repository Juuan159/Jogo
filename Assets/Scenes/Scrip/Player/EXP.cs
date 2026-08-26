using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class EXP : MonoBehaviour
{
    public int level;
    public int currentEXP; 
    public int expTolevel = 10;
    public float expGrowthMulplier = 1.2f;
    public Slider EXPslider;
    public TMP_Text LVLText;

    public void Start()
    {
        UpdateUI();
    }

    public void OnEnable()
    {
        InimigoHP.OnMonsterDeafeated += GainEXP;
    }

    public void OnDisable()
    {
        InimigoHP.OnMonsterDeafeated -= GainEXP;
    }

    public void GainEXP(int amount)
    {
        currentEXP += amount;
        if(currentEXP >= expTolevel)
        {
            LevelUp();
        }

        UpdateUI();
    }

    private void LevelUp()
    {
        level++;
        currentEXP -= expTolevel;
        expTolevel = Mathf.RoundToInt(expTolevel * expGrowthMulplier);
    }

    public void UpdateUI()
    {
        EXPslider.maxValue = expTolevel;
        EXPslider.value = currentEXP;
        LVLText.text = "Level:" +  level;
    }
}
