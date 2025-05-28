using UnityEngine;

public class StickOnCollision2D : MonoBehaviour
{
    public string stickTag = "Stickable";
    public FixedJoint2D[] joints = new FixedJoint2D[10];
    private int jointCount = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(stickTag))
        {
            Rigidbody2D otherRb = collision.rigidbody;

             for (int i = 0; i < jointCount; i++)
             {
                 if (joints[i].connectedBody == otherRb)
                        return; 
             }

            // creating the joint
            FixedJoint2D joint = gameObject.AddComponent<FixedJoint2D>();
            joint.connectedBody = otherRb;
            joint.autoConfigureConnectedAnchor = true;
            joint.enableCollision = false;
            joint.dampingRatio = 1f;
            joint.frequency = 5f;
            
            joints[jointCount] = joint;
            jointCount++;
            }
        }
 }

