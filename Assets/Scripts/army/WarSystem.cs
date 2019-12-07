using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class WarSystem : MonoBehaviour
{
    public Army army1;
    public Army army2;

    public Text txtArmy1;
    public Text txtArmy2;

    public Text txtPowerArmy1;
    public Text txtPowerArmy2;

    public float difficultyCoef;
    private float warStatusValue;

    public Slider warStatusBar;

    public AudioMixer musicAudioMixer;

    // Start is called before the first frame update
    void Start()
    {
        army1 = new Army("Bad Skulls", 0);
        army2 = new Army("Bad Bees", 0);

        txtArmy1.text = army1.name;
        txtArmy2.text = army2.name;

        warStatusValue = 0;

        warStatusBar.minValue = -100f;
        warStatusBar.maxValue = 100f;
        warStatusBar.value = warStatusValue;
    }

    // Update is called once per frame
    void Update()
    {
        warStatusValue += ((float)army1.power - (float)army2.power) * difficultyCoef;
        warStatusBar.value = warStatusValue;
        musicAudioMixer.SetFloat("volumePeaceMusic", -(Mathf.Abs(warStatusValue))/10);
        musicAudioMixer.SetFloat("volumeWarMusic", Mathf.Lerp(-10, 7, (Mathf.Abs(warStatusValue)) / 100));
        musicAudioMixer.SetFloat("lowpassWarMusic", Mathf.Lerp(10, 22000, (Mathf.Abs(warStatusValue)) / 100));

        txtPowerArmy1.text = army1.power.ToString();
        txtPowerArmy2.text = army2.power.ToString();

        if (warStatusValue < warStatusBar.minValue || warStatusValue > warStatusBar.maxValue)
        {
            SceneManager.LoadScene("gameOverScene", LoadSceneMode.Single);
        }
    }

    public void SellWeapon(int indexArmy, RessourceManager.WeaponRessourceType type, uint number)
    {
        if (indexArmy == 1)
        {
            army1.power += RessourceManager.Instance.get_Arme(type).puissance * number;
            RessourceManager.Instance.vendre_arme((int)(RessourceManager.Instance.get_Arme(type).prix * number));
        }
        else
        {
            army2.power += RessourceManager.Instance.get_Arme(type).puissance * number;
            RessourceManager.Instance.vendre_arme((int)(RessourceManager.Instance.get_Arme(type).prix * number));
        }
    }
}
