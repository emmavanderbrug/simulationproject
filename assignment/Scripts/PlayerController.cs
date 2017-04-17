using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody rb;

    public Text winText;

    private int count;

    public Text countText;


    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizonal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizonal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

        void OnTriggerEnter(Collider other) 
        {
            if (other.gameObject.CompareTag("Pick Up"))
            {
                other.gameObject.SetActive(false);
                count = count + 1;
                SetCountText();
            }
        }
    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 11)
        {
            winText.text = "You Win!";
        }
    }
}