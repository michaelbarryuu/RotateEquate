using UnityEngine;
using System.Collections;

public class NumberSpriteGeneratorController : MonoBehaviour
{

	// the number gameobject
	private GameObject parentNumberObj;
	
	//the value of the number gameobject
	public int value;
	
	public Sprite[] numberSpriteArray;
	
	public float offset;
	
	public bool created = false;
	
	
	// Use this for initialization
	void Start ()
	{
		// set the parentNumberObj
		parentNumberObj = transform.parent.gameObject;
		
		// get value from the parentNumberObj
		value = parentNumberObj.GetComponent<NumberController>().getValue();
		
		
		CreateNumberSprites();
	}
	
	
	// method to create the required numberSprites
	void CreateNumberSprites()
	{
	    // put the value into a character array so the individual characters can be accessed
		char[] numbers = value.ToString().ToCharArray();
		
		// store the current position
		Vector3 newPos = transform.position;
		
		// if there are even amount of numbers
		if((numbers.Length % 2) == 0)
		{
			for(int i = (numbers.Length / 2) - 1; i >= 0; i--)
			{
				//decrease the newpos x position by the offset
				newPos.x -= offset;
				
				//instantiate a new numberSprite gameObject
				GameObject numberSprite = (GameObject)Instantiate(Resources.Load("Prefabs/NumberSprites/NumberSprite"), newPos, transform.rotation);
				
				numberSprite.transform.parent = gameObject.transform;
				
				numberSprite.GetComponent<NumberSpriteController>().setSprite(numberSpriteArray[(int)char.GetNumericValue(numbers[i])]);
				
				newPos.x -= offset;
			}
			
			// reset the newPos
			newPos = transform.position;
			
			for(int i = (numbers.Length / 2); i < numbers.Length; i++)
			{
				//decrease the newpos x position by the offset
				newPos.x += offset;
				
				//instantiate a new numberSprite gameObject
				GameObject numberSprite = (GameObject)Instantiate(Resources.Load("Prefabs/NumberSprites/NumberSprite"), newPos, transform.rotation);
				
				numberSprite.transform.parent = gameObject.transform;
				
				numberSprite.GetComponent<NumberSpriteController>().setSprite(numberSpriteArray[(int)char.GetNumericValue(numbers[i])]);
				
				newPos.x += offset;
			}
		}
		else
		{
			// odd count of numbers here!!
		}

	}







}