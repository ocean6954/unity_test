using Leap;
using Leap.Unity;
using UnityEngine;

public class trackingData : MonoBehaviour
{
    public LeapProvider leapProvider;
    public Transform handTransform; // 手のTransform

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
            // メインカメラの位置を取得
            Vector3 newPosition = Camera.main.transform.position;

            // 新しい回転を設定（例: 元の回転をそのまま使用）
            Quaternion newRotation = hand.Rotation;
            handTransform.position = newPosition;
            handTransform.rotation = newRotation;
            Debug.Log("手の位置 " + hand.PalmPosition + "\nカメラの位置: " + Camera.main.transform.position);

        }
        Hand _leftHand = frame.GetHand(Chirality.Left);
        Hand _rightHand = frame.GetHand(Chirality.Right);
    }
}