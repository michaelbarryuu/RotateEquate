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
    public float TorqueDecrementFactor = 4.0f;
    public float MaxTorque = 300.0f;

    // Private variables
    private Rigidbody2D myRigidbody;


    // Use this for initialization
    void Start()
    {
        this.myRigidbody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Switch between different movement types(To be removed)
        if (TorqueMovement)
            playerMovementTorque();

        else
            playerMovement();
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
                else
                    myRigidbody.AddTorque(-TorqueIncrement * TorqueDecrementFactor);
            }

            // Otherwise, slowly reduce rotation
            else
            {
                if (myRigidbody.angularVelocity > 15)
                {
                    myRigidbody.angularVelocity -= 5f;
                }
                else if (myRigidbody.angularVelocity < -15)
                {
                    myRigidbody.angularVelocity += 5.5f;
                }
                else
                {
                    myRigidbody.angularVelocity = 0.0f;
                }
            }
        }


    }

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
