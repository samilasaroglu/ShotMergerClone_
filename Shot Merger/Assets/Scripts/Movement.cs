using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Movement : MonoBehaviour
{

    private float speed;
    private Vector3 move;
    private bool isInArea, leftWallTouch, rightWallTouch;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private TextMeshPro tmp;
  

    // Start is called before the first frame update
    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
        isInArea = true;
        speed = 8f;
        leftWallTouch = false;
        rightWallTouch = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        tmp.text = "" +collectableBox.shotCount + "/sec";

        if (isInArea == true)
        {
            move = new Vector3(Input.GetAxis("Horizontal") * speed, 0, speed);
            transform.Translate(move * Time.deltaTime);
        }
        else
        {
            if (leftWallTouch == true)
            {
                if (Input.GetAxis("Horizontal") <= 0)
                {
                    move = new Vector3(0, 0, speed);
                    transform.Translate(move * Time.deltaTime);
                }
                else
                {
                    move = new Vector3(Input.GetAxis("Horizontal") * speed, 0, speed);
                    transform.Translate(move * Time.deltaTime);
                }
            }
            if (rightWallTouch == true)
            {
                if (Input.GetAxis("Horizontal") >= 0)
                {
                    move = new Vector3(0, 0, speed);
                    transform.Translate(move * Time.deltaTime);
                }
                else
                {
                    move = new Vector3(Input.GetAxis("Horizontal") * speed, 0, speed);
                    transform.Translate(move * Time.deltaTime);
                }
            }



        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "leftWall")
        {
            isInArea = false;
            leftWallTouch = true;

        }
        if (other.gameObject.tag == "rightWall")
        {

            isInArea = false;
            rightWallTouch = true;

        }
        if (other.gameObject.tag == "Finish")
        {
            Time.timeScale = 0;
            winPanel.SetActive(true);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "leftWall")
        {
            isInArea = true;
            leftWallTouch = false;
        }
        if (other.gameObject.tag == "rightWall")
        {
            isInArea = true;
            rightWallTouch = false;
        }
    }
}
