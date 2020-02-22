using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Text text;
    public Image bar;
    public float fill;
    public PlayerCombat Player;
    float lerpspeed = 3.5f;


   
    void Update()
    {
        fill = Player.CurrentHealth;
        text.text = Player.CurrentHealth.ToString();
        HandleBar();
    }

    private void HandleBar()
    {
        if (fill/100 != bar.fillAmount)

            bar.fillAmount = Mathf.Lerp(bar.fillAmount, fill/100, Time.deltaTime * lerpspeed);

    }
}
