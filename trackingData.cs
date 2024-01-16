using Leap;
using Leap.Unity;
using LeapInternal;
using UnityEngine;

public class trackingData : MonoBehaviour
{
    public LeapProvider leapProvider;

    private void OnEnable()
    {
        leapProvider.OnUpdateFrame += OnUpdateFrame;
    }
    private void OnDisable()
    {
        leapProvider.OnUpdateFrame -= OnUpdateFrame;
    }

    void OnUpdateFrame(Frame frame)
    {
        //Get a list of all the hands in the frame and loop through
        //to find the first hand that matches the Chirality
        foreach (var hand in frame.Hands)
        {
            if (hand.IsLeft)
            {
                Debug.Log("左手");

                // Assuming LEAP_VECTOR structure
                LEAP_VECTOR leftHandPosition = new LEAP_VECTOR
                {
                    x = hand.PalmPosition.x,
                    y = hand.PalmPosition.y,
                    z = hand.PalmPosition.z
                };

                // Now you can use leftHandPosition to access x, y, z coordinates.
                Debug.Log("Left Hand Position: " + leftHandPosition.x + ", " + leftHandPosition.y + ", " + leftHandPosition.z);
            }
            if (hand.IsRight)
            {
                Debug.Log("右手");

                // Assuming LEAP_VECTOR structure
                LEAP_VECTOR rightHandPosition = new LEAP_VECTOR
                {
                    x = hand.PalmPosition.x,
                    y = hand.PalmPosition.y,
                    z = hand.PalmPosition.z
                };

                // Now you can use rightHandPosition to access x, y, z coordinates.
                Debug.Log("Right Hand Position: " + rightHandPosition.x + ", " + rightHandPosition.y + ", " + rightHandPosition.z);
            }
        }

        //Use a helpful utility function to get the first hand that matches the Chirality
        Hand _leftHand = frame.GetHand(Chirality.Left);
        Hand _rightHand = frame.GetHand(Chirality.Right);
    }
}
