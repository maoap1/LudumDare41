using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour {

	public void SliderChanged(float newValue)
    {
        GameObject.Find("Audio Source").GetComponent<AudioSource>().volume = newValue;
    }
}
