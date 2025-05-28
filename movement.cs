using UnityEngine;

public class movement : MonoBehaviour
{
    public float rotationSpeed = 30f;
    public float strength = 30f;
    public Rigidbody2D rb;
    public float xMove;
    public float rotationInput = 0f;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    { 
        // left and right movement
        if(Input.GetKey(KeyCode.D))
        {
            xMove = 1f;
            
        }
        else if(Input.GetKey(KeyCode.A))
        {
            xMove = -1f;  
        }
        else
        {
            xMove = 0f;
        }

        rb.linearVelocity = new Vector2((xMove * strength), 0f);
        
        // left and right rotation
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rotationInput = 30f;
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rotationInput = -30f;
        }
        else
        {
            rotationInput = 0f;
        }
         
        float newRotation = rb.rotation + rotationInput * rotationSpeed * Time.deltaTime;
        rb.MoveRotation(newRotation);
     }
 }