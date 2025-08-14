using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Cubix jjj;
    private Vector3 previousPosition;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }

        if (Input.GetMouseButton(0))
        {
            // Viewport Coordinates give you the distance of movement of your mouse independent of the screen in the ratio 1:Length of screen
            Vector3 direction = previousPosition - cam.ScreenToViewportPoint(Input.mousePosition);
            cam.transform.position = new Vector3();
            cam.transform.Rotate(new Vector3 (1, 0, 0), direction.y * 180);
            cam.transform.Rotate(new Vector3 (0, 1, 0), -direction.x * 180, Space.World);
            cam.transform.Translate(new Vector3(jjj.chaim.x, jjj.chaim.y, jjj.chaim.z-20f));
            // cam.transform.RotateAround(jjj.chaim, new Vector3 (1, 0, 0), direction.y * 180);
            // cam.transform.RotateAround(jjj.chaim, new Vector3(0, 1, 0), -direction.x * 180);

            previousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
        }
    }
}
