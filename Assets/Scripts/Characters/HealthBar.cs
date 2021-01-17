using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image isisHealthCircle, horusHealthCircle, anubisHealthCircle;

    private void Start()
    {
        isisHealthCircle.fillAmount = PlayerControl.instance.isis.getMaxHealth() / 100;
        horusHealthCircle.fillAmount = PlayerControl.instance.horus.getMaxHealth() / 100;
        anubisHealthCircle.fillAmount = PlayerControl.instance.anubis.getMaxHealth() / 100;
    }

    private void Update()
    {
        setIsisHealth(PlayerControl.instance.isis.getCurrentHealth() / 100);
        setHorusHealth(PlayerControl.instance.horus.getCurrentHealth() / 100);
        setAnubisHealth(PlayerControl.instance.anubis.getCurrentHealth() / 100);
    }

    public void setToMaxHealth()
    {
        //HealthSlider.value = PlayerControl.instance.currentPlayer.maxHealth;
    }

    public void setIsisHealth(float health)
    {
        isisHealthCircle.fillAmount = (float)health;
    }

    public void setHorusHealth(float health)
    {
        horusHealthCircle.fillAmount = (float)health;
    }

    public void setAnubisHealth(float health)
    {
        anubisHealthCircle.fillAmount = (float)health;
    }
}
