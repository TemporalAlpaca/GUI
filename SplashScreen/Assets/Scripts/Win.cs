using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

	// Use this for initialization
	void Start () {
        AudioListener.volume = PlayerPrefs.GetFloat("volume");

    }

    public void OnClick()
    {
        Application.LoadLevel("Scenes/Main_Menu");
    }
    // Update is called once per frame
    void Update () {
	
	}
}
