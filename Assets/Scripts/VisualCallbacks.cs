using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VisualCallbacks : MonoBehaviour
{
    // Start is called before the first frame update
    public UnityAction<GameObject> onAnimationFinish;
    public UnityAction<GameObject> onBecameInvisible;

    public void OnAnimationFinish()
    {
        onAnimationFinish(gameObject);
    }

    public void OnBecameInvisible()
    {
        onBecameInvisible(gameObject);
    }
}
