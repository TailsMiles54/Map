using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CameraMove : MonoBehaviour
{
    private Vector3 qwera;

    public Slider asdg;

    void Update()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, asdg.value, gameObject.transform.position.z);
        
        float dx = Input.mousePosition.x - qwera.x;
        float dy = Input.mousePosition.y - qwera.y;

        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            if (dy > 0f)
            {
                gameObject.transform.position += new Vector3(0, 0, -1) * Time.deltaTime;
            }

            if (dy < 0f)
            {
                gameObject.transform.position += new Vector3(0, 0, 1) * Time.deltaTime;
            }
            if (dx > 0f)
            {
                gameObject.transform.position += Vector3.left * Time.deltaTime;
            }

            if (dx < 0f)
            {
                gameObject.transform.position += Vector3.right * Time.deltaTime;
            }
        }

    }

    private void LateUpdate()
    {
        qwera = Input.mousePosition;
    }

}
