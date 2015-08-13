using UnityEngine;
using System.Collections;

public class God : MonoBehaviour {
	public int BlingCount;
	public int ChestCount;
	public int SwitchCount;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void Blingerino(){
		Debug.Log ("Bling!");
		BlingCount += 1;
	}
	public void Chesterino(){
		Debug.Log ("Chest!");
		ChestCount += 1;
	}
	public void Switcherino(){
		Debug.Log ("Switch!");
		SwitchCount += 1;
	}

	private bool DeveloperButtons = true;
	private string FirstFloor = "Teleport to 1st Floor";
	private string SecondFloor = "Teleport to 2nd Floor";
	private string ResetLevel = "Reset Level";
	public GameObject FirstFloorTP;
	public GameObject SecondFloorTP;
	public GameObject Player;

	void OnGUI () {
		if(DeveloperButtons == true){
			if(GUI.Button(new Rect(10,10,150,20), FirstFloor)) {
				Debug.Log("Player teleported to 1st Floor");
				Player.transform.position = FirstFloorTP.transform.position;
			}
			if(GUI.Button(new Rect(10,40,150,20), SecondFloor)) {
				Debug.Log("Player teleported to 2nd Floor");
				Player.transform.position = SecondFloorTP.transform.position;
			}
			if(GUI.Button(new Rect(10,70,150,20), ResetLevel)) {
				Debug.Log("Player has reset the level");
				Application.LoadLevel(Application.loadedLevel); 
			}
			if(GUI.Button(new Rect(10,100,50,20), "-")) {
				DeveloperButtons = false;
			}
		}else{
			if(GUI.Button(new Rect(10,10,75,20), "+")) {
				DeveloperButtons = true;
			}
		}
	}

}
