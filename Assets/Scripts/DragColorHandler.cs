using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragColorHandler : MonoBehaviour, IDragHandler, IEndDragHandler {

    Vector3 beginingPos;
    public GameObject cannonGO;

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("why wont you work ;_;");
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        Debug.Log(collision);
        Debug.Log("why wont you work ");
    }

    public void OnCollisionExit2D(Collision2D collision) {
        Debug.Log(collision);
        Debug.Log("why wont you work ;");
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
        Debug.Log(transform.position);
        Debug.Log(cannonGO.transform.position);
    }

    public void OnEndDrag(PointerEventData eventData) {
        transform.localPosition = beginingPos;
    }

    // Start is called before the first frame update
    void Start() {
        beginingPos = transform.localPosition;
    }
}
