using UnityEngine;

public class Slider : MonoBehaviour
{
    public int strength = 5;
    private float slideDir = 1f;
    private float leftLim = -18.5f;
    private float rightLim =  18.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }


    void Update()
    {
        if(transform.position.x <=  leftLim)
        {
            slideDir =  1f;
        }
        else if(transform.position.x >=  rightLim)
        {
            slideDir = -1f;
        }
        transform.Translate(new Vector2(slideDir * strength * Time.deltaTime, 0f));  
    }
    public float getSlideDir()
    {
        return slideDir;
    }
    public Vector2 getPosition()
    {
        return transform.position;
    }
    public float getXPos()
    {
        return transform.position.x;
    }
    public float length()
    {
        return GetComponent<Renderer>().bounds.size.x;
    }

}
