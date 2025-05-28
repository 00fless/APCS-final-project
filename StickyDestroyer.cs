using System.Collections.Generic;
using UnityEngine;

public class StickyDestroyer2D : MonoBehaviour
{
    //doesn't work as expected
    private List<Transform> stuckTargets = new List<Transform>();
    private List<Collider2D[]> hitboxesList = new List<Collider2D[]>();
    private List<bool[]> hitFlagsList = new List<bool[]>();


    void OnCollisionEnter2D(Collision2D collision)
    {
        Transform root = collision.collider.transform.root;

        int index = stuckTargets.IndexOf(root);
        if (index == -1)
        {
            stuckTargets.Add(root);

            Collider2D[] hitboxes = root.GetComponentsInChildren<Collider2D>();
            hitboxesList.Add(hitboxes);
            hitFlagsList.Add(new bool[hitboxes.Length]);

            index = stuckTargets.Count - 1;

        }

        Collider2D[] hitboxesArr = hitboxesList[index];
        bool[] hitFlags = hitFlagsList[index];

        for (int i = 0; i < hitboxesArr.Length; i++)
        {
            if (hitboxesArr[i] == collision.collider && !hitFlags[i])
            {
                hitFlags[i] = true;

                int hitCount = 0;
                foreach (bool hit in hitFlags)
                    if (hit) hitCount++;

                if (hitCount >= hitboxesArr.Length)
                {
                    stuckTargets.RemoveAt(index);
                    hitboxesList.RemoveAt(index);
                    hitFlagsList.RemoveAt(index);
                    Destroy(root.gameObject);
                }

                break;
            }
        }
    }
}