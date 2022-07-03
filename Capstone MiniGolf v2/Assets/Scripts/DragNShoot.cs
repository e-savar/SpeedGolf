using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    public float power = 2.3f;
    public Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    Vector3 mouseDir;
    Vector3 mousePos;
    float max = 3f;

    Vector3 camOffset = new Vector3(0,0,10);
    [SerializeField] private LineRenderer lr;

    private void Update()
    {
        cam = Camera.main;

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mouseDir = mousePos - gameObject.transform.position;
        mouseDir.z = 0;
        mouseDir = mouseDir.normalized;
        if (Input.GetMouseButtonDown(0))
        {
            lr.enabled = true;
        }

        if (Input.GetMouseButton(0))
        {
            startPoint = gameObject.transform.position;
            startPoint.z = 0;
            lr.SetPosition(0, startPoint);
            endPoint = mousePos;
            endPoint.z = 0;
            lr.SetPosition(1, endPoint);
        }

        if (Input.GetMouseButtonUp(0))
        {
            lr.enabled = false;
            
            force = new Vector2(Mathf.Clamp(endPoint.x - startPoint.x, minPower.x, maxPower.x), Mathf.Clamp(endPoint.y - startPoint.y, minPower.y, maxPower.y));
            rb.AddForce(force * power, ForceMode2D.Impulse);
        }
    }
}
