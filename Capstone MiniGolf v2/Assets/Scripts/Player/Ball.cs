using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    //0.1
    public GameObject gameObject;
    public SpriteRenderer skin;
    [SerializeField] private float power;
    public float linearDrag;

    //0.2

    // Start is called before the first frame update
    void Start()
    {
        power = GetComponent<DragNShoot>().power;
        linearDrag = GetComponent<Rigidbody2D>().drag - (Profile.instance.friction/20);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Sand")
        {
            GetComponent<DragNShoot>().power = GetComponent<DragNShoot>().power/2;
            GetComponent<Rigidbody2D>().drag = GetComponent<Rigidbody2D>().drag*3;
        }
        else if(other.tag == "Water")
        {
            this.transform.position = new Vector3(0, -3.5f, 0);
            GetComponent<Rigidbody2D>().drag = GetComponent<Rigidbody2D>().drag * 10000;
        }
        else
        {
            GetComponent<DragNShoot>().power = power;
            GetComponent<Rigidbody2D>().drag = linearDrag;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        GetComponent<DragNShoot>().power = power;
        GetComponent<Rigidbody2D>().drag = linearDrag;
    }
}
