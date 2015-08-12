using UnityEngine;
using System.Collections;

public class God : MonoBehaviour {
	public int BlingCount;
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
}
