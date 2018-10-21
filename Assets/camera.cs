using UnityEngine;
using System.Collections;

public class CameraFlow : MonoBehaviour
{
    public Transform target;
    Vector3 offset;
    // Use this for initialization
    void Start()
    {
        offset = transform.position - target.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        Rotate();
        Scale();
    }
    //縮放
    private void Scale()
    {
        float dis = offset.magnitude;
        dis += Input.GetAxis("Mouse ScrollWheel") * 5;
        Debug.Log("dis=" + dis);
        if (dis < 10 || dis > 40)
        {
            return;
        }
        offset = offset.normalized * dis;
    }
    //左右上下移動
    private void Rotate()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 pos = transform.position;
            Vector3 rot = transform.eulerAngles;

            //圍繞原點旋轉，也可以將Vector3.zero改為 target.position,就是圍繞觀察對象旋轉
            transform.RotateAround(Vector3.zero, Vector3.up, Input.GetAxis("Mouse X") * 10);
            transform.RotateAround(Vector3.zero, Vector3.left, Input.GetAxis("Mouse Y") * 10);
            float x = transform.eulerAngles.x;
            float y = transform.eulerAngles.y;
            Debug.Log("x=" + x);
            Debug.Log("y=" + y);
            //控制移動範圍
            if (x < 20 || x > 45 || y < 0 || y > 40)
            {
                transform.position = pos;
                transform.eulerAngles = rot;
            }
            //  更新相對差值
            offset = transform.position - target.position;
        }
    }
}   