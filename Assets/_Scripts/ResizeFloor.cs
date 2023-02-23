// Nicholas Wile
// Dr. Sungchul Jung
// Created: Jan 17, 2023 - NW
// Last Edited: Feb 22, 2023 - NW

/// <summary>
/// This class resizes the floor space. 
/// </summary> 

using UnityEngine;

public class ResizeFloor : MonoBehaviour
{
    [SerializeField] private Transform floor;

    //[Range(1f, 5f)]
    //public float scale = 1;

    private float xValue, zValue;
    private Vector3 resize;
    private float numColumns;
    
    //[SerializeField] private Interface ui;
    [SerializeField] private AvatarLoader avatarLoader;

    // Start is called before the first frame update
    void Start()
    {
        if (floor == null)
        {
            floor = GetComponent<Transform>();
        }
       /* if (ui == null)
        {
            ui = GetComponent<Interface>();
        }*/
        if (avatarLoader == null)
        {
            avatarLoader = GetComponent<AvatarLoader>();
        }

        xValue = floor.localScale.x;
        zValue = floor.localScale.z;

    }

    // Update is called once per frame
    void Update()
    {
        //scale = ui.sliderValue;
        numColumns = avatarLoader.numColumns;

        resize = new Vector3(xValue*numColumns, 1, zValue*2);
        floor.localScale = resize;
    }
}
