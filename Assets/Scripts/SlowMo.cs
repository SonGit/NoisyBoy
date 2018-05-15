using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlowMo : MonoBehaviour {

    public float SlowMoSpeed = 0.2f;

    public Image SlowMoUI;

    public float Recovery;

    public float CurrentSlowMoCountdown;

    public float MaxSlowMoTime;

    // Use this for initialization
    void Start () {
        CurrentSlowMoCountdown = MaxSlowMoTime;
        SlowMoUI.fillAmount = 1;
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetButtonDown("Fire1"))
        {
            SlowMoSwitch();
        }

        if(Time.timeScale < 1.0f)
        {
            CurrentSlowMoCountdown -= Time.deltaTime;

            if(CurrentSlowMoCountdown<= 0)
            {
                Time.timeScale = 1.0F;
            }
        }
        else
        {
            if(CurrentSlowMoCountdown < MaxSlowMoTime)
            CurrentSlowMoCountdown += Recovery * Time.deltaTime;
        }

        if(SlowMoUI != null)
        SlowMoUI.fillAmount = CurrentSlowMoCountdown / MaxSlowMoTime;
    }

    void SlowMoSwitch()
    {
        if (Time.timeScale == 1.0F)
            Time.timeScale = SlowMoSpeed;
        else
            Time.timeScale = 1.0F;
        Time.fixedDeltaTime = SlowMoSpeed * Time.timeScale;
    }
}
