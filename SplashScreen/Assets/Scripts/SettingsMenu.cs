using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour {

    public GameObject volume_slider;
    public float volume;

    void Start()
    {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");
        volume_slider.GetComponent<Slider>().value = AudioListener.volume;
    }
	public void onClick()
    {
        Application.LoadLevel("Scenes/Main_Menu");
    }

    public void changeVolume()
    {
        AudioListener.volume = (volume_slider.GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("volume", AudioListener.volume);
        PlayerPrefs.Save();
    }
}
