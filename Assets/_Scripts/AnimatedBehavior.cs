// Nicholas Wile
// Dr. Sungchul Jung
// February 28, 2023

/// <summary>
/// This class provides a debug display to test animations. 
/// </summary> 


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedBehavior : MonoBehaviour
{

    [SerializeField] private Animator animator;
    [SerializeField] private float duration = 3;
    private float min = 2, max = 5;

    private const string EYE = "Eye", HEAD = "Head", BODY = "Body", DONE = "Return";

    // Start is called before the first frame update
    void Start()
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 125, 200), "Animations");

        if (GUI.Button(new Rect(25, 40, 80, 20), "Eye"))
        {
            animator.SetTrigger(EYE);
            StartCoroutine(AnimateAndWait());
            
        }

        if (GUI.Button(new Rect(25, 70, 80, 20), "Head"))
        {
            animator.SetTrigger(HEAD);
            StartCoroutine(AnimateAndWait());
        }

        if (GUI.Button(new Rect(25, 100, 80, 20), "Body"))
        {
            animator.SetTrigger(BODY);
            StartCoroutine(AnimateAndWait());
        }

        duration = GUI.HorizontalSlider(new Rect(25, 130, 100, 30), duration, min, max);

        GUI.Label(new Rect(25, 160, 100, 50), "Duration: " + (int)Mathf.Floor(duration));

    }

    private IEnumerator AnimateAndWait()
    {
        yield return new WaitForSeconds(duration);
        animator.SetTrigger(DONE);
    }
}
