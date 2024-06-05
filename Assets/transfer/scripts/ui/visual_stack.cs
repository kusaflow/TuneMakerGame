using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class visual_stack : MonoBehaviour
{

    // list of all poweruppresets
    //public List<powerupPreset> powerupPresets = new List<powerupPreset>();
    public PP_StackData _powerupPresets;

    public GameObject powerupPrefab;


    public Button PopButton;

    /*
     * sequence of powerups
     * //helper enum for powerup types-----------------------------------------------------------
        AddBall
        DoubleBalls
        DirectionalControl
        Explosive, 
        IncreaseSize
        InvincibleBall
        IncreaseSpeed
        Shield 
        slowMotion
        magnet
        tripleScrore
        DoubleScore 
        ExtraBounce
        SplitBallOnCollision
        extraTime
    
        //Adverse Powers---------------------------------------------------------
        DecreaseSize
        DecreaseSpeed
        HalfBalls
        RandomDirection 
        InvisibleBall
        DoubleGravity
        ReverseStack
        RandomizeStack
        PowerUpCooldown,
        BlockRegeneration
        popTop4Powers
        popTop2Powers
     * 
     */

    private void Start()
    {
        if (_powerupPresets == null)
        {
            _powerupPresets = FindObjectOfType<PP_StackData>();
        }

        UpdateTheStack();

        //add listener to the pop button
        PopButton.onClick.AddListener(() => {
            PowerUpManager.Instance.UsePowerUp();
            UpdateTheStack();
        });
    }

    private void Update()
    {
        if (globalStatic.updateTheStackPlease)
            UpdateTheStack();
    }


    //check on update the powerup mngr stack and fill the visual stack with the image and tou can getsprite from powerupPreset
    private void UpdateTheStack()
    {
        globalStatic.updateTheStackPlease = false;
        //get the powerup stack from the powerup mngr
        Stack<PowerUp> powerUpStack = PowerUpManager.Instance.GetPowerUpStack();

        //clear the visual stack
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        //fill the visual stack
        foreach (PowerUp powerUp in powerUpStack)
        {
            /*GameObject powerup = new GameObject();
            //want to add ui image component to the gameobject
            powerup.AddComponent<Image>().sprite = _powerupPresets.powerupPresets[(int)powerUp.powerUpType].powerupSprite;
            //set scale to 1 or ui element 
            //powerup.GetComponent<RectTransform>().localScale = new Vector3(.27f, .27f, .27f);
            //powerup.AddComponent<SpriteRenderer>().sprite = _powerupPresets.powerupPresets[(int)powerUp.powerUpType].powerupSprite;
            powerup.transform.SetParent(transform);*/

            GameObject powerup = Instantiate(powerupPrefab, transform);
            powerup.GetComponent<Image>().sprite = _powerupPresets.powerupPresets[(int)powerUp.powerUpType].powerupSprite;


        }
    }


}
