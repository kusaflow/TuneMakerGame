using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;

public class SpawnPowerUp2Level : MonoBehaviour
{
    public static SpawnPowerUp2Level Instance;

    public PP_StackData pp_stack;

    public GameObject Canvas;

    public GameObject SpawnnerGO;

    [Space]
    public float WaitTimeForPower;


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

        StartCoroutine(SpawnPowerupAfterSomeTime());
        
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

    public void IncrementAutoPowerSpawnner(float inc)
    {
        WaitTimeForPower += inc;
    }

    IEnumerator SpawnPowerupAfterSomeTime()
    {
        yield return new WaitForSeconds(WaitTimeForPower);
        int powerType = Random.Range(0, (int)PowerUp.PowerUpType.EOL);
        SpawnPowerUp2Level.Instance.SpawnPowerup(new Vector2(Random.Range(-12.15f, 17.4f), Random.Range(-22.22f, 35.8f)), (PowerUp.PowerUpType)powerType);
        //PowerUpManager.Instance.CollectPowerUp_instantly(new PowerUp((PowerUp.PowerUpType)dropDown.value));
        globalStatic.updateTheStackPlease = true;


        StartCoroutine(SpawnPowerupAfterSomeTime());
    }

    public void SpawnRandomPower()
    {
        int powerType = Random.Range(0, (int)PowerUp.PowerUpType.EOL);
        SpawnPowerUp2Level.Instance.SpawnPowerup(new Vector2(Random.Range(-12.15f, 17.4f), Random.Range(-22.22f, 35.8f)), (PowerUp.PowerUpType)powerType);
        //PowerUpManager.Instance.CollectPowerUp_instantly(new PowerUp((PowerUp.PowerUpType)dropDown.value));
        globalStatic.updateTheStackPlease = true;

    }

}
