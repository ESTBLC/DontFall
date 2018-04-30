using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{

	public AudioMixer audio;
	public Dropdown drop;
	private Resolution[] resolutions;

	private void Start()
	{
		resolutions = Screen.resolutions;
		drop.ClearOptions();
		List<string> options  = new List<string>();
		int currentresolution = 0;
		for (int i = 0; i < resolutions.Length; i++)
		{
			string option = resolutions[i].width + " x " + resolutions[i].height;
			options.Add(option);
			if (Screen.currentResolution.height == resolutions[i].height && Screen.currentResolution.width == resolutions[i].width)
			{
				currentresolution = i;
			}
		}
		drop.AddOptions(options);
		drop.value = currentresolution;
		drop.RefreshShownValue();
	}

	public void setResolution(int resolutionIndex)
	{
		Resolution resolution = resolutions[resolutionIndex];
		Screen.SetResolution(resolution.width , resolution.height, Screen.fullScreen);	
	}
	
	public void SetVolume(float volume)
	{
		audio.SetFloat("volume", volume);
	}

	public void setQuality(int quality)
	{
		QualitySettings.SetQualityLevel(quality);
	}

	public void SetFullScreen(bool fullscreen)
	{
		Screen.fullScreen = fullscreen;
	}
}
