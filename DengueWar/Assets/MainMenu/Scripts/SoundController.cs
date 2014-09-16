using UnityEngine;
using System.Collections;

public enum soundsMenu{
	fundo,
	click
}

public class SoundController : MonoBehaviour {
	
	public AudioClip somDeFundo;
	public AudioClip somClickMenu;

	//Singleton 
	public static SoundController instance;

	void Start () {
		instance = this;
	}
	
	public static void PlaySound(soundsMenu currentSound){
		switch(currentSound){
		case soundsMenu.fundo:{
			instance.audio.PlayOneShot(instance.somDeFundo);
		}
			break;
		case soundsMenu.click:{
			instance.audio.PlayOneShot(instance.somClickMenu);
		}
			break;
		}
	}

	public static void StopSound(){
		instance.audio.Stop();
	}


}
