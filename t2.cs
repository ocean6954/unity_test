using UnityEngine;

public class HandFollowCamera : MonoBehaviour
{
    public Transform handTransform; // 手のTransform

    void Update()
    {
        if (handTransform != null)
        {
            // メインカメラの座標に手の座標を合わせる
            handTransform.position = Camera.main.transform.position;
        }
    }
}

