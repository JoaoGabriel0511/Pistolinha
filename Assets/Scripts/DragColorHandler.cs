using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragColorHandler : MonoBehaviour, IDragHandler, IEndDragHandler {

    Vector3 beginingPos;

    public BoxCollider2D cannon;

    void OnTriggerEnter2D(Collider2D other) {

    }

    public void OnCollisionEnter2D(Collision2D collision) {
 
    }

    public void OnCollisionExit2D(Collision2D collision) {

    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
        //Debug.Log(transform.position);
    }

    public void OnEndDrag(PointerEventData eventData) {
        if(new Rect(cannon.bounds.min.x, cannon.bounds.min.y, cannon.size.x, cannon.size.y).Contains(Camera.main.ScreenToWorldPoint(transform.position))) {
            switch(GetComponent<ButtonCollor>().GetCollor()) {
                case Constants.Type.BLUE:
                    cannon.GetComponent<Cannon>().SwitchToBlue();
                    break;
                case Constants.Type.RED:
                    cannon.GetComponent<Cannon>().SwitchToRed();
                    break;
                case Constants.Type.GREEN:
                    cannon.GetComponent<Cannon>().SwitchToGreen();
                    break;
                default:
                    break;
            }
        }
        transform.localPosition = beginingPos;
    }

    // Start is called before the first frame update
    void Start() {
        beginingPos = transform.localPosition;
    }
}
