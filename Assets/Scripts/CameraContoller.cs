using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour
{
    public float panSpeed = 30f; // Скорость панорамирования
    public float panBorderThickness = 10f; // Толщина границы панорамирования
    public float speedScroll = 5f;
    public float minY = 10f;
    public float maxY = 80f;
    private void Update() {

        if(GameManager.GameIsOver)
        {
            this.enabled = false;
            return;
        }


        if(Input.GetKey("w") || Input.mousePosition.y >= Screen.height  - panBorderThickness)
        {
            transform.Translate(Vector3.forward * panSpeed * Time.deltaTime,Space.Self);
        }
        if(Input.GetKey("s") || Input.mousePosition.y <= panBorderThickness)
        {
            transform.Translate(Vector3.back * panSpeed * Time.deltaTime,Space.Self);
        }
        if(Input.GetKey("d") || Input.mousePosition.x >= Screen.width  - panBorderThickness)
        {
            transform.Translate(Vector3.right * panSpeed * Time.deltaTime,Space.Self);
        }
        if(Input.GetKey("a") || Input.mousePosition.x <= panBorderThickness)
        {
            transform.Translate(Vector3.left * panSpeed * Time.deltaTime,Space.Self);
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y,minY,maxY);
        pos.y -= scroll * 100f * speedScroll * Time.deltaTime;
        transform.position = pos;
    }
}
