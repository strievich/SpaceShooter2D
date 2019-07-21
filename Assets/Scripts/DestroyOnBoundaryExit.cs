using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnBoundaryExit : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Object " + other.tag + " is exit boundary and destroyed");
        Destroy(other.gameObject);
    }
}
