using UnityEngine;
using System.Collections;

public enum MenuStates{
	STARTMENU,
	OPCOES
}


public class MainMenu : MonoBehaviour {

	public Texture backgroundTexture;
	public Texture LogoTexture;
	public Texture buttonSoundOff;
	public Texture buttonSoundOn;
	public Texture buttonEffectOff;
	public Texture buttonEffectOn;
	//Botoes do Menu
	public GUIStyle buttonIniciarGUIStyle;
	public GUIStyle buttonSobreGUIStyle;
	public GUIStyle buttonAjudaGUIStyle;
	public GUIStyle buttonOpcoesGUIStyle;

	//Botoes do Menu Opcoes
	public GUIStyle buttonSoundGUIStyle;
	public GUIStyle buttonEffectGUIStyle;
	public GUIStyle buttonVoltarGUIStyle;

	//Botoes Transic
	public bool SoundEnable;
	public bool EffectEnable;
	private MenuStates currentState;


	void Start(){
		Menu();
		//PlaySomFundo()  
	}


	//Controle da GUI---------------------------------------------------------
	void OnGUI(){
		

		//Display background Texture e Logo
		GUI.DrawTexture (new Rect(0,0, Screen.width, Screen.height), backgroundTexture);
		GUI.DrawTexture (new Rect (Screen.width * .14f, Screen.height * .12f, Screen.width * .8f, Screen.height* .21f), LogoTexture);
		switch (currentState) {
				case MenuStates.STARTMENU:
						{
								if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .39f, Screen.width * .5f, Screen.height * .1f), "", buttonIniciarGUIStyle)) {
										PlaySomClick ();
										Debug.Log ("Cliquei Iniciar");
										//TODO Fazer mudar de Scene para scene do jogo com o codigo abaixo
										//Application.LoadLevel(numDoLevelNoBuild);
								}
								if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .5f, Screen.width * .5f, Screen.height * .1f), "", buttonOpcoesGUIStyle)) {
										PlaySomClick ();
										Opcoes ();
										Debug.Log ("Cliquei Opcoes");
								}
								if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .61f, Screen.width * .5f, Screen.height * .1f), "", buttonAjudaGUIStyle)) {
										PlaySomClick ();
										Debug.Log ("Cliquei Ajuda");
										//TODO Fazer tela ajuda
								}
								if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .72f, Screen.width * .5f, Screen.height * .1f), "", buttonSobreGUIStyle)) {
										PlaySomClick ();
										Debug.Log ("Cliquei Sobre");
										//TODO Fazer tela do Sobre
								}

						}
						break;
				case MenuStates.OPCOES:
						{
								if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .39f, Screen.width * .5f, Screen.height * .1f), "", buttonSoundGUIStyle)) {
									SoundEnable = inverteTrueFalse(SoundEnable);
									PlaySomClick ();
									buttonSoundGUIStyle.normal.background = ClickSound() as Texture2D; 
									Debug.Log ("Cliquei Sound");
								}
								if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .5f, Screen.width * .5f, Screen.height * .1f), "", buttonEffectGUIStyle )) {
									EffectEnable = inverteTrueFalse(EffectEnable);
									PlaySomClick ();
									buttonEffectGUIStyle.normal.background = ClickEffect() as Texture2D;
									Debug.Log ("Cliquei Effect");
								}
								if (GUI.Button (new Rect (Screen.width * .25f, Screen.height * .61f, Screen.width * .5f, Screen.height * .1f), "", buttonVoltarGUIStyle)) {
									PlaySomClick ();
									Menu ();
									Debug.Log ("Cliquei Voltar");
									
								}

						}
						break;
				}
		
		}

	//METODOS AUXILIARES---------------------------------------------------

	private void PlaySomClick(){
		if (EffectEnable) {
						SoundController.PlaySound (soundsMenu.click);
				} else {
			Debug.Log("EffectEnable Off");
		}
	}

	private void PlaySomFundo(){
		if (SoundEnable) {
						SoundController.PlaySound (soundsMenu.fundo);
				} else {
			SoundController.StopSound();		
		}
	}

	private Texture ClickEffect(){
		Texture result;
		if (EffectEnable) {
						result = buttonEffectOn;		
				} else {
			result = buttonEffectOff;		
		}
		return result;
	}

	private Texture ClickSound(){
		Texture result;
		if (SoundEnable) {
			result = buttonSoundOn;		
		} else {
			result = buttonSoundOff;		
		}
		return result;
	}

	private bool inverteTrueFalse(bool boolean){
		if (boolean.Equals(true)) {
						return false;		
				
		} else {
			return true;
		}
	}



	//STATES------------------------------------------------

	public void Menu(){
		currentState = MenuStates.STARTMENU;
		
	}

	public void Opcoes(){
		currentState = MenuStates.OPCOES;
		
	}



}

