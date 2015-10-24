using UnityEngine;
using System.Collections;

public class NumberSpriteGeneratorController : MonoBehaviour
{

	// the number gameobject
	private GameObject parentNumberObj;
	
	// the value of the number gameobject
	public int value;
	
	// sprite array for the numbers
	public Sprite[] numberSpriteArray;
	
	// the spacing between numbers
	public float spacing;
	
	// Use this for initialization
	void Start ()
	{
		// set the parentNumberObj
		parentNumberObj = transform.parent.gameObject;
		
		// get value from the parentNumberObj
		value = parentNumberObj.GetComponent<NumberController>().getValue();
		
		spacing *= parentNumberObj.transform.localScale.x;
		
		CreateNumberSprites();
	}

	
	// method to create the required numberSprites
	void CreateNumberSprites()
	{
	    // put the value into a character array so the individual characters can be accessed
		char[] numbers = value.ToString().ToCharArray();
		
		// store the current position
		Vector3 newPos = transform.position;
		
		// gameobject to represent new numberSprite
		GameObject numberSprite;
		
		// if there are even amount of numbers
		if((numbers.Length % 2) == 0)
		{
			for(int i = (numbers.Length / 2) - 1; i >= 0; i--)
			{
				//decrease the newpos x position by the offset
				newPos.x -= spacing;
				
				//instantiate a new numberSprite gameObject
				numberSprite = (GameObject)Instantiate(Resources.Load("Prefabs/NumberSprites/NumberSprite"), newPos, transform.rotation);
				
				numberSprite.transform.parent = gameObject.transform;
				
				numberSprite.transform.localScale = parentNumberObj.transform.localScale * 0.8f;
				
				numberSprite.GetComponent<NumberSpriteController>().setSprite(numberSpriteArray[(int)char.GetNumericValue(numbers[i])]);
				
				newPos.x -= spacing;
			}
			
			// reset the newPos
			newPos = transform.position;
			
			for(int i = (numbers.Length / 2); i < numbers.Length; i++)
			{
				//decrease the newpos x position by the offset
				newPos.x += spacing;
				
				//instantiate a new numberSprite gameObject
				numberSprite = (GameObject)Instantiate(Resources.Load("Prefabs/NumberSprites/NumberSprite"), newPos, transform.rotation);
				
				numberSprite.transform.parent = gameObject.transform;
				
				numberSprite.transform.localScale = parentNumberObj.transform.localScale * 0.8f;
				
				numberSprite.GetComponent<NumberSpriteController>().setSprite(numberSpriteArray[(int)char.GetNumericValue(numbers[i])]);
				
				newPos.x += spacing;
			}
		}
		// handle an odd amount of numbers
		else
		{
			// reset the newPos
			newPos = transform.position;
			
			// create the center numberSprite first
			// instantiate a new numberSprite gameObject
			numberSprite = (GameObject)Instantiate(Resources.Load("Prefabs/NumberSprites/NumberSprite"), newPos, transform.rotation);
			
			numberSprite.transform.parent = gameObject.transform;
			
			numberSprite.transform.localScale = parentNumberObj.transform.localScale * 0.8f;
			
			numberSprite.GetComponent<NumberSpriteController>().setSprite(numberSpriteArray[(int)char.GetNumericValue(numbers[numbers.Length / 2])]);
			
			
			// numbers left of the center
			for(int i = (numbers.Length / 2) - 1; i >= 0; i--)
			{
				//decrease the newpos x position by the offset
				newPos.x -= numberSprite.GetComponent<BoxCollider2D>().size.x;
				
				//instantiate a new numberSprite gameObject
				numberSprite = (GameObject)Instantiate(Resources.Load("Prefabs/NumberSprites/NumberSprite"), newPos, transform.rotation);
				
				numberSprite.transform.parent = gameObject.transform;
				
				numberSprite.transform.localScale = parentNumberObj.transform.localScale * 0.8f;
				
				numberSprite.GetComponent<NumberSpriteController>().setSprite(numberSpriteArray[(int)char.GetNumericValue(numbers[i])]);
			}
			
			// reset the newPos
			newPos = transform.position;

			
			//numbers right of the center
			for(int i = (numbers.Length / 2) + 1; i < numbers.Length; i++)
			{
				//decrease the newpos x position by the offset
				newPos.x += numberSprite.GetComponent<BoxCollider2D>().size.x;
				
				//instantiate a new numberSprite gameObject
				numberSprite = (GameObject)Instantiate(Resources.Load("Prefabs/NumberSprites/NumberSprite"), newPos, transform.rotation);
				
				numberSprite.transform.parent = gameObject.transform;
				
				numberSprite.transform.localScale = parentNumberObj.transform.localScale * 0.8f;
				
				numberSprite.GetComponent<NumberSpriteController>().setSprite(numberSpriteArray[(int)char.GetNumericValue(numbers[i])]);
			}
			
		}

	}







}