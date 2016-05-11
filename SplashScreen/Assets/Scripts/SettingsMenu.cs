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
#pragma warning disable CS0618 // Type or member is obsolete
        Application.LoadLevel("Scenes/Main_Menu");
#pragma warning restore CS0618 // Type or member is obsolete
    }

    public void changeVolume()
    {
        AudioListener.volume = (volume_slider.GetComponent<Slider>().value);
        PlayerPrefs.SetFloat("volume", AudioListener.volume);
        PlayerPrefs.Save();
    }
}
