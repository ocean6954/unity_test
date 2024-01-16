using Leap;
using Leap.Unity;
using System.Collections.Generic;
using UnityEngine;

public class Example : MonoBehaviour
{
    private void Update()
    {
        Hand _hand = Hands.Provider.GetHand(Chirality.Left); //Get just the left hand.

        float _grabStrength = _hand.GrabStrength;
        float _grabAngle = _hand.GrabAngle;

        bool _isGrabbing = false;

        if (_grabStrength > 0.8 && !_isGrabbing) //We check _isGrabbing so this code isn't called if we are already grabbing.
        {
            _isGrabbing = true; // grab strength is over 0.8 threshold so it is true
        }
        else if (_grabStrength < 0.7 && _isGrabbing) //We check _isGrabbing so this code isn't called if we aren't already grabbing.
        {
            _isGrabbing = false; // grab strength is less than 0.7 so no chance of jittering grab.
        }
    }
}