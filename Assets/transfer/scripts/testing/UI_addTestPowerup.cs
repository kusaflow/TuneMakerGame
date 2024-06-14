using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_addTestPowerup : MonoBehaviour
{

    public Button close;
    public Button addPowerup_tolist;
    public Button ShowPannel;
    public TMPro.TMP_Dropdown dropDown;

    public GameObject powerPanel;

    public PP_StackData stackData;

    [Space]
    public Button addPowerup_toLevel;

    // Start is called before the first frame update
    void Start()
    {
        powerPanel.gameObject.SetActive(false);

        close.onClick.AddListener(() => { powerPanel.gameObject.SetActive(false); });

        ShowPannel.onClick.AddListener(() => { powerPanel.gameObject.SetActive(true); });

        //setup dropDown Data
        dropDown.ClearOptions();

        // add all options form PP_stackdata and power presets and sprite data
        
        List<string> options = new List<string>();
        foreach (powerupPreset preset in stackData.powerupPresets)
        {
            options.Add(preset.powerUpType.ToString());
        }
        dropDown.AddOptions(options);
        

        addPowerup_tolist.onClick.AddListener(() => 
                {
                    PowerUpManager.Instance.CollectPowerUp_instantly(new PowerUp((PowerUp.PowerUpType)dropDown.value)); 
                    globalStatic.updateTheStackPlease = true;
                }
         );

        addPowerup_toLevel.onClick.AddListener(() =>
            {
                SpawnPowerUp2Level.Instance.SpawnPowerup(new Vector2(Random.Range(-12.15f, 17.4f), Random.Range(-22.22f, 35.8f)), (PowerUp.PowerUpType)dropDown.value);
                //PowerUpManager.Instance.CollectPowerUp_instantly(new PowerUp((PowerUp.PowerUpType)dropDown.value));
                globalStatic.updateTheStackPlease = true;
            }
        );



    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
