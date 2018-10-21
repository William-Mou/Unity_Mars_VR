using UnityEngine;
using System.Collections;

public class CameraFlow : MonoBehaviour
{


    public float near = 20.0f;
    public float far = 100.0f;

    public float sensitivityX = 10f;
    public float sensitivityY = 10f;
    public float sensitivetyZ = 0f;
    public float sensitivetyMove = 10f;
    public float sensitivetyMouseWheel = 2f;
    public int speed = 1;

    public Camera camera;

    void start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {

        //w键前进
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));
        }
        //s键后退
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -1 * speed * Time.deltaTime));
        }
        //a键后退
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-1 * speed, 0, 0 * Time.deltaTime));
        }
        //d键后退
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed, 0, 0 * Time.deltaTime));
        }


        // 滚轮实现镜头缩进和拉远
        /*
         * if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            camera.fieldOfView =this.camera.fieldOfView - Input.GetAxis("Mouse ScrollWheel")*sensitivetyMouseWheel;
            camera.fieldOfView = Mathf.Clamp(this.camera.fieldOfView, near, far);
        }
        */
        //鼠标实现视角转动，类似第一人称视角
        //if (Input.GetMouseButton(1))
        //{ 
        float rotationX = Input.GetAxis("Mouse X") * sensitivityX;
        //float rotationY = Input.GetAxis("Mouse Y") * sensitivityY;
        transform.Rotate(-0, rotationX, 0);
        // transform.Rotate(-rotationY, 0, 0);
        //}
        }
        //键盘按钮←和→实现视角水平旋转
        /*
        if (Input.GetAxis("Horizontal")!=0)
        {
            float rotationZ=Input.GetAxis("Horizontal") * sensitivetyZ;
            transform.Rotate(0, 0, rotationZ); 
        }
        */
    }