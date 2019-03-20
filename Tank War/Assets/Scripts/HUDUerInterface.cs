using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDUerInterface : MonoBehaviour
{
    public Unit player;
    public Image healthBar;
    public Text healthLabel;

    void Update()
    {
        healthBar.fillAmount = (float)player.GetCurHealth() / (float)player.health;
        healthLabel.text = player.GetCurHealth().ToString();
    }
}
