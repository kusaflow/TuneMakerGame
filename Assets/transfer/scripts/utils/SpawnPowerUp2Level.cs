using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class SpawnPowerUp2Level : MonoBehaviour
{
    public static SpawnPowerUp2Level Instance;

    public PP_StackData pp_stack;

    public GameObject Canvas;

    public GameObject SpawnnerGO;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        if (!pp_stack)
            pp_stack = GetComponent<PP_StackData>();
        
    }

    public void SpawnPowerup(Vector2 pos, PowerUp.PowerUpType type)
    {
        if (!pp_stack)
            pp_stack = GetComponent<PP_StackData>();
        
        Sprite sp = pp_stack.powerupPresets[(int)type].GetComponent<powerupPreset>().powerupSprite;
        GameObject go2Spawn = Instantiate(SpawnnerGO,Canvas.transform);
        PowerupCanvasMngr powerupCanvasMngr = go2Spawn.GetComponent<PowerupCanvasMngr>();
        powerupCanvasMngr.SetSpriteAndPower(sp, type);
        go2Spawn.GetComponent<RectTransform>().localPosition = pos;


    }

}
