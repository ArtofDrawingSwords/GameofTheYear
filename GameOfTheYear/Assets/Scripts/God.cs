using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class God : MonoBehaviour {
	public float BlingCount;
    public float ChestCount;
    public float SwitchCount;
    public static God Kamisama;
    public string FileName = "Kamisama";
	// Use this for initialization
    void Awake()
    {
        if (Kamisama == null)
        {
            DontDestroyOnLoad(gameObject);
            Kamisama = this;
        }
        else if (Kamisama != this)
        {
            Destroy(gameObject);
        }
    }
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            SaveData(); 
        }
        if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            LoadData();
        }
	}

    public void SaveData()
    {
        Debug.Log("PlayerInfo Saved");
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + FileName + ".dat");
        //
        PlayerData data = new PlayerData();
        data.BlingCount = BlingCount;
        data.ChestCount = ChestCount;
        data.SwitchCount = SwitchCount;

        //
        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadData()
    {
        Debug.Log("PlayerInfo Loaded");
        if (File.Exists(Application.persistentDataPath + "/" + FileName + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + FileName + ".dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            //
            BlingCount = data.BlingCount;
            ChestCount = data.ChestCount;
            SwitchCount = data.SwitchCount;
        }
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
    private string Scene1 = "Go to Scene 1";
    private string testscene = "Go to Test Scene";
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
            if (GUI.Button(new Rect(10, 100, 150, 20), Scene1))
            {
                Debug.Log("Scene is now on: Scene1");
                Application.LoadLevel("Scene1");
            }
            if (GUI.Button(new Rect(10, 130, 150, 20), testscene))
            {
                Debug.Log("Scene is now on: testscene");
                Application.LoadLevel("testscene");
            }
			if(GUI.Button(new Rect(10,160,50,20), "-")) {
				DeveloperButtons = false;
			}

		}else{
			if(GUI.Button(new Rect(10,10,75,20), "+")) {
				DeveloperButtons = true;
			}
		}
	}

}

[Serializable]
class PlayerData
{
    public float BlingCount;
    public float ChestCount;
    public float SwitchCount;
}