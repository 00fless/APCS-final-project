using UnityEngine;
using TMPro;

public class PointsTracker : MonoBehaviour
{
    public TextMeshProUGUI textRef;
    public int pointNum = 0;
    private string stickTag = "Stickable";

    void Start()
    {
        UpdatePointsText();
    }

    // if there is collision with a baby object it will add 10 points
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(stickTag))
        {
            pointNum += 10;
            UpdatePointsText();
        }
    }

    void UpdatePointsText()
    {
        if (textRef != null)
        {
            textRef.text = "Points - " + pointNum.ToString();
        }
    }
}