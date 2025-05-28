using UnityEngine;
using TMPro;

public class LifeManager : MonoBehaviour
{
    public static LifeManager instance;
    public int lives = 10;
    public TextMeshProUGUI livesText;
    private int[] toCrash;

// makes a static global reference to the LifeManager and makes sure there is only one instance of
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
           Destroy(gameObject);
        }
    }

    void Start()
    {
        updateText();
    }
    //method to minus a life on the text and a way to end the game once lives <=0
    public void LoseLife()
    {
        lives--;
        updateText();

        //temp
        if (lives <= 0)
        {
            Debug.Log("Game Over");
            toCrash[1] = 0;
        }
    }

    private void updateText()
    {
        if(livesText != null)
        {
            livesText.text = "Lives: " + lives.ToString();
        }
    }
}
