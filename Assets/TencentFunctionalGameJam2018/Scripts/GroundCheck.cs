using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{

    /* Config Propertys */
    public List<Collider2D> colliders = new List<Collider2D>();

    /* Runtime Propertys */
    public bool isGrounded;
    public List<Collider2D> touchingGrounds = new List<Collider2D>();

    /* Unity Events */
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.isTrigger)
            return;

        while (!touchingGrounds.Contains(other))
            touchingGrounds.Add(other);

        UpdateGrounds();
    }
    void OnTriggerExit2D(Collider2D other)
    {
        while (touchingGrounds.Contains(other))
            touchingGrounds.Remove(other);

        UpdateGrounds();
    }

    /* Internal */
    void UpdateGrounds()
    {
        for (int i = touchingGrounds.Count - 1; i >= 0; i--)
        {
            if (touchingGrounds[i] == null)
                touchingGrounds.RemoveAt(i);
        }
        if (isGrounded)
        {
            if (touchingGrounds.Count == 0)
                isGrounded = false;
        }
        else
        {
            if (touchingGrounds.Count > 0)
                isGrounded = true;
        }
    }
}
