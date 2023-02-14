// Nicholas Wile
// Dr. Sungchul Jung
// Jan 17, 2023

/// <summary>
/// This class resizes the floor space. 
/// </summary> 

using UnityEngine;

public class ResizeFloor : MonoBehaviour
{
    [SerializeField] private Transform floor;

    //[Range(1f, 5f)]
    public float scale = 1;

    private float xValue, zValue;

    private Vector3 resize;
    
    [SerializeField] private Interface ui;

    // Start is called before the first frame update
    void Start()
    {
        if (floor == null)
        {
            floor = GetComponent<Transform>();
        }
        if (ui == null)
        {
            ui = GetComponent<Interface>();
        }
        xValue = floor.localScale.x;
        zValue = floor.localScale.z;
    }

    // Update is called once per frame
    void Update()
    {
        scale = ui.sliderValue;
        resize = new Vector3(xValue*scale, 1, zValue*scale);
        floor.localScale = resize;
    }
}
