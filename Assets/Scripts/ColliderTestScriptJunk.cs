using UnityEngine;
using System.Collections;

public class ColliderTestScriptJunk : MonoBehaviour {

	public float DistanceIncrement;
	float x;
	// Use this for initialization
	void Start () {
	x = this.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		x += DistanceIncrement;
		this.transform.position = new Vector3(x, 0, 0);
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
    	Destroy(this.gameObject);

    }
}
