using UnityEngine;
using System.Collections;

public class NumberController : MonoBehaviour
{
	
	//value variables
	public int value;
	private int minValue = 1;
	private int maxValue = 99;
	
	//array of sprites for numbers
	public Sprite[] sprites;
	
	//left and right number gameObjects
	public GameObject leftNum;
	public GameObject rightNum;
	
	//left and right number spriteRenderers and sprites for those renderers
	private SpriteRenderer leftRenderer;
	private SpriteRenderer rightRenderer;
	private Sprite leftSprite;
	private Sprite rightSprite;
	
	// Use this for initialization
	void Start () 
	{
		//set the value randomly based on the minimum and maximum possible values
		value = Random.Range(minValue, maxValue);
		
		//set the sprites for the left and right numbers based on the value
		setNumberSprites();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	
	
	//method to set the left and right number sprites based on the value
	private void setNumberSprites()
	{
		//get the left and right spriteRenderers
		leftRenderer = leftNum.GetComponent<SpriteRenderer>() as SpriteRenderer;
		rightRenderer = rightNum.GetComponent<SpriteRenderer>() as SpriteRenderer;
		
		//figure out how many 10s and 1s are in the value
		int leftSpriteIndex = value / 10;
		int rightSpriteIndex = value % 10;
		
		//get the correct left sprite and set the spriteRenderer sprite to it
		leftSprite = sprites[leftSpriteIndex];
		leftRenderer.sprite = leftSprite;
		
		//get the correct right sprite and set the spriteRenderer sprite to it
		rightSprite = sprites[rightSpriteIndex];
		rightRenderer.sprite = rightSprite;
	}
	
}