using TMPro;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.InputSystem;


public class StatusUI : MonoBehaviour
{
    public GameObject[] SlotStats;
    public CanvasGroup statsCanvas;
    private bool statsopen = false;

    public void Start()
    {
        UpdateAllStats();
    }
    public void Update()
    {
    if (Keyboard.current.eKey.wasPressedThisFrame)
        {
            if (statsopen)
            {
                Time.timeScale = 1;
                UpdateAllStats();
                statsCanvas.alpha = 0;
                statsopen = false;
            }
            else
            {
                Time.timeScale = 0;
                UpdateAllStats();
                statsCanvas.alpha = 1;
                statsopen = true;
            }
        }
    }
    public void UpdateDamage()
    {
        SlotStats[0].GetComponentInChildren<TMP_Text>().text = "Damage:" + StatusManeger.Instance.damage;
    }
    public void UpdateSpeed()
    {
        SlotStats[1].GetComponentInChildren<TMP_Text>().text = "Speed:" + StatusManeger.Instance.speed;
    }
    public void UpdateAllStats()
    {
        UpdateDamage();
        UpdateSpeed();
    }
}
