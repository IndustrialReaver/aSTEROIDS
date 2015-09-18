using UnityEngine;
using System.Collections;

public class GoTo : MonoBehaviour {

	public void newGame(){
		Application.LoadLevel ("aSteroidsStaging");
	}

	public void about(){
		Application.LoadLevel ("aSteroidsAbout");
	}

	public void howTo(){
		Application.LoadLevel ("aSteroidsHowTo");
	}

	public void mainMenu(){
		Application.LoadLevel ("aSteroidsMainMenu");
	}

	public void shipSelect(){
		Application.LoadLevel ("aSteroidsShipSelect");
	}

}
