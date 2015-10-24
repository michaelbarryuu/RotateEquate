using UnityEngine;
using System.Collections;

public class NumberController : MonoBehaviour
{
	
	// value variables
	public int value;
	private int minValue = 1;
	private int maxValue = 99;
	
	public float minScale;
	public float maxScale;

	//player GameObject
	private GameObject player;
	
	
	// getter for value
	public int getValue()
	{
		return value;
	}
	
	public int getMinValue()
	{
		return minValue;
	}
	
	public int getMaxValue()
	{
		return maxValue;
	}


	// Use this for initialization
	void Awake () 
	{
		// set the value randomly based on the minimum and maximum possible values
		value = Random.Range(minValue, maxValue);

		//Find the player GameObject
		player = GameObject.Find("Player");
		
		// set the scale of the object based on its value
		setScale();
	}
	
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	
	// set the scale based on the value
	void setScale()
	{
		Vector3 newScale;
		
		float scale = minScale + ((value / (float)maxValue) * (maxScale - minScale));
		
		newScale = new Vector3(scale, scale, 1.0f);
		
		transform.localScale = newScale;
	}
	

	void OnTriggerEnter2D(Collider2D coll){

		//If number collides with player, perform correct action based on the side collided with
		if(coll.gameObject.tag == "Add"){
			player.GetComponent<PlayerController>().addPlayerValue(value);
		}
		else if(coll.gameObject.tag == "Subtract"){
			player.GetComponent<PlayerController>().subtractPlayerValue(value);
		}
		else if(coll.gameObject.tag == "Multiply"){
			player.GetComponent<PlayerController>().multiplyPlayerValue(value);
		}
		else if(coll.gameObject.tag == "Divide"){
			player.GetComponent<PlayerController>().dividePlayerValue(value);
		}
	}
	
}