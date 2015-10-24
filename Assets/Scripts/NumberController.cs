using UnityEngine;
using System.Collections;

public class NumberController : MonoBehaviour
{
	
	// value variables
	public int value;
	private int minValue = 1000;
	private int maxValue = 9999;

	// getter for value
	public int getValue()
	{
		return value;
	}

	//player GameObject
	private GameObject player;

	// Use this for initialization
	void Start () 
	{
		// set the value randomly based on the minimum and maximum possible values
		value = Random.Range(minValue, maxValue);

		//Find the player GameObject
		player = GameObject.Find("Player");
	}
	
	
	// Update is called once per frame
	void Update () 
	{
	
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