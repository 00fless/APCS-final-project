using UnityEngine;
using TMPro;

public class BabyDestruction : MonoBehaviour
{
    public float maxDist = -20f;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // checks if after it offscreen and destories the object
        if (transform.position.y  < maxDist)
        {
            if (LifeManager.instance != null)
            {
                LifeManager.instance.LoseLife();  // <- this line
            }
            Destroy(gameObject);
        }
    }
}
