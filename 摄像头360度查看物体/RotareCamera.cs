using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour {

    public Transform target;

    float distance = 20.0f;

// 鼠标在x轴和y轴移动的角度
    float x;
    float y;

// 限制旋转角度的最小值和最大值
    float yMinLimit = -20.0f;
    float yMaxLimit = 80.0f;

// 鼠标在x和y方向移动的速度
    float xSpeed = 250.0f;
    float ySpeed = 120.0f;

     void Start () {
     // 初始化x轴和y轴的角度
        Vector2 angles = transform.eulerAngles;
        x = angles.x;
        y = angles.y;

        if (rigidbody)
        {
            rigidbody.freezeRotation = true;
        }
     }

    void LateUpdate()
    {
        if (target)
        {
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
            y = ClampAngle(y, yMinLimit, yMaxLimit);
			
			// x,y 对调，因为摄像头跟物体是相对的。
            Quaternion rotation = Quaternion.Euler(y, x, 0);
            Vector3 position = rotation * new Vector3(0, 0, -distance) + target.position;
            transform.rotation = rotation;
            transform.position = position;
        }
    }

    float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360)
            angle -= 360;
        return Mathf.Clamp(angle, min, max);
    }
     // Update is called once per frame
     void Update () {
     
     }
}
