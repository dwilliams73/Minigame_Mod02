using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxTrigger : MonoBehaviour
{
    [Tooltip("Tag of objects that belong in the box")]
    public string target_tag = "Untagged";

    void Start()
    {
        if (string.IsNullOrWhiteSpace(target_tag))
        {
            Debug.LogError("Tag is empty or null. Please set a valid tag in the Inspector.");
            return;
        }
    }

    void Update()
    {
        ;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(target_tag))
        {
            // Deactivate the collided object (making it disappear).
            other.gameObject.SetActive(false);
        }
    }

}
