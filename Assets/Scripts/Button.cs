using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private Sprite[] a;
    public bool IsStay;
    public bool buttonPress;
    private void OnTriggerStay2D(Collider2D other)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = a[0];
        IsStay = true;
        buttonPress = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = a[1];
        IsStay = false;
        buttonPress = false;
    }
}