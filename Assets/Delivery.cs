using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);

    [SerializeField] float destoryDelay = 0.5f;
    bool hasPackage;

    SpriteRenderer spriteRenderer;
    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnCollisionEnter2D (Collision2D other) 
    {
        Debug.Log(other);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage) 
        {
            Debug.Log("PP");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destoryDelay);
        } 

        if (other.tag == "Customer" && hasPackage) 
        {
            Debug.Log("Package Delivered nerd");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
