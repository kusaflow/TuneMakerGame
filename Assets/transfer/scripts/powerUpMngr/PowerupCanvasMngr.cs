using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerupCanvasMngr : MonoBehaviour
{
    public Image powerup;
    public Slider powerSlider;
    private float val = 0;

    public PowerUp.PowerUpType _type;

    private void Start()
    {
        //_type = PowerUp.PowerUpType.AddBall;
        val = 0;
    }

    public void SetSpriteAndPower (Sprite sp, PowerUp.PowerUpType type)
    {
        powerup.sprite = sp;
        //Debug.Log(type);
        this._type = type;
        //Debug.Log(type);

    }

    private void Update()
    {
        if (val >= 3)
        {
            addToStackAndDestroy();
        }
        else
        {
            val += 1 * Time.deltaTime;
        }

        powerSlider.value = val;
    }

    public void addToStackAndDestroy()
    {
        PowerUpManager.Instance.CollectPowerUp_instantly(new PowerUp(_type));
        globalStatic.updateTheStackPlease = true;
        Destroy(gameObject);
    }


}
