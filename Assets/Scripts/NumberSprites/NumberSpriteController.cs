using UnityEngine;
using System.Collections;

public class NumberSpriteController : MonoBehaviour
{
	
	// sprite used and spriteRenderer
	private Sprite sprite;
	private SpriteRenderer spriteRenderer;
	
	
	// setter for the sprite
	public void setSprite(Sprite sprite)
	{
		this.sprite = sprite;
	}


	// Use this for initialization
	void Start ()
	{
		spriteRenderer = (SpriteRenderer)GetComponent<SpriteRenderer>();
		
		spriteRenderer.sprite = sprite;
	}
	
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
