using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour 
{
	public float xbeforemove = 1f;	
	public float ybeforemove = 1f;		
	public float xcameraspeed = 6f;		
	public float ycameraspeed = 6f;		
	public Vector2 maximumXY;		
	public Vector2 minimumXY;		
	private Transform spineboy;		
	
	void Awake ()
	{
		spineboy = GameObject.FindGameObjectWithTag("spineboy").transform;
	}
	bool playermaxmoveX()
	{
		return Mathf.Abs(transform.position.x - spineboy.position.x) > xbeforemove;
	}
	bool playermaxmoveY()
	{
		return Mathf.Abs(transform.position.y - spineboy.position.y) > ybeforemove;
	}
	void FixedUpdate ()
	{
		followme();
	}
	void followme ()
	{
		float playerx = transform.position.x;
		float playery = transform.position.y;
			if(playermaxmoveX())
			playerx = Mathf.Lerp(transform.position.x, spineboy.position.x, xcameraspeed * Time.deltaTime);
			if(playermaxmoveY())
			playery = Mathf.Lerp(transform.position.y, spineboy.position.y, ycameraspeed * Time.deltaTime);
				playerx = Mathf.Clamp(playerx, minimumXY.x, maximumXY.x);
				playery = Mathf.Clamp(playery, minimumXY.y, maximumXY.y);
				transform.position = new Vector3(playerx, playery, transform.position.z);
	}	
}
