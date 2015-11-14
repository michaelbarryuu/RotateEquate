using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Alows us to switch between two different movement modes for testing along with variables it requires (To be removed)
    public bool TorqueMovement = true;
    float RotationIncrement = 0.2f;
    float MaxRotation = 15.0f;
    Vector3 rotationVector = new Vector3(0, 0, 1.0f);

    // Public variables
    public float TorqueIncrement = 6.0f;
    public float TorqueDecrementFactor = 8.0f;
    public float MaxTorque = 300.0f;
    public int PlayerStartingValue = 0;

    // Private variables
    private Rigidbody2D myRigidbody;
    private int PlayerValue;
    private int MaxPlayerValue;
    private int MinPlayerValue;
    private NumberSpriteGeneratorController numberSpriteGeneratorController;

	
	void Awake()
	{
		numberSpriteGeneratorController = transform.FindChild("NumberSpriteGenerator").GetComponent<NumberSpriteGeneratorController>();
	}
	

    // Use this for initialization
    void Start()
    {
        //Store Rigidbody2D component in a variable
        this.myRigidbody = this.GetComponent<Rigidbody2D>();

        //Put PlayerValue(number displayed on the player) to equal the set starting value
        PlayerValue = PlayerStartingValue;
        
        numberSpriteGeneratorController.SetValue(PlayerValue);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        // Switch between different movement types(To be removed)
        if (TorqueMovement){
            playerMovementTorque();
            this.transform.position = new Vector3(0, 0, 0);
        }

        else
            playerMovement();
    }

    int playerValue(){
        return PlayerValue;
    }

    public void addPlayerValue(int value){
        PlayerValue += value;
    }

    public void subtractPlayerValue(int value){
        PlayerValue -= value;
    }

    public void multiplyPlayerValue(int value){
        PlayerValue *= value;
    }

    public void dividePlayerValue(int value){
        PlayerValue /= value;
    }

    void playerMovementTorque()
    {
        // If not exceeding maximum rotation speed
        if (Mathf.Abs(myRigidbody.angularVelocity) < MaxTorque)
        {
            // Add torque in the correct direction based on the button press
            if (Input.GetButton("Left"))
            {
                if (myRigidbody.angularVelocity > 0)
                    myRigidbody.AddTorque(TorqueIncrement);
                else // If used for slowing down, reduce torque faster
                    myRigidbody.AddTorque(TorqueIncrement * TorqueDecrementFactor);
            }

            else if (Input.GetButton("Right"))
            {
                if (myRigidbody.angularVelocity < 0)
                    myRigidbody.AddTorque(-TorqueIncrement);
                else // If used for slowing down, reduce torque faster
                    myRigidbody.AddTorque(-TorqueIncrement * TorqueDecrementFactor);
            }

            // Otherwise, slowly reduce rotation
            else
            {
                if (myRigidbody.angularVelocity > 10)
                {
                    myRigidbody.angularVelocity -= 5f;
                }
                else if (myRigidbody.angularVelocity < -10)
                {
                    myRigidbody.angularVelocity += 5f;
                }
                else
                {
                    myRigidbody.angularVelocity = 0.0f;
                }
            }
        }
    }

    //Simple transform movement method(to be removed)
    void playerMovement()
    {
        myRigidbody.angularVelocity = 0.0f;
        if (Input.GetButton("Left"))
        {
            if (rotationVector.z < MaxRotation)
            {
                rotationVector.z += RotationIncrement;
            }
            transform.Rotate(rotationVector);

        }

        else if (Input.GetButton("Right"))
        {
            if (rotationVector.z < MaxRotation)
            {
                rotationVector.z += RotationIncrement;
            }
            transform.Rotate(-rotationVector);

        }

        if (Input.GetButtonUp("Left") || Input.GetButtonUp("Right"))
        {
            rotationVector.z = 1.0f;
        }
    }
}
