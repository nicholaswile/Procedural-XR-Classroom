// Nicholas Wile
// Dr. Sungchul Jung
// Jan 17, 2023

/// <summary>
/// This class provides a UI to scale the class. 
/// </summary> 

using System.Diagnostics;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public float sliderValue = 1f;
    public float minValue = 1.0f, maxValue = 5.0f;

    private enum AvatarValues { Size1 = 10, Size2 = 30, Size3 = 50};
    private int avatarCount = (int)AvatarValues.Size1;

    [SerializeField] private AvatarLoader avatarLoader;

    private void Start()
    {
        if (avatarLoader == null)
        {
            avatarLoader = GetComponent<AvatarLoader>();
        }
    }

    private void OnGUI()
    {
        GUI.Box(new Rect(10, 10, 125, 150), "Resize Menu");

        if (GUI.Button(new Rect(25, 40, 80, 20), "Size 1"))
        {
            sliderValue = minValue;
            avatarCount = (int) AvatarValues.Size1;
        }

        if (GUI.Button(new Rect(25, 70, 80, 20), "Size 2"))
        {
            sliderValue = (minValue+maxValue)/2;
            avatarCount = (int)AvatarValues.Size2;
        }

        if (GUI.Button(new Rect(25, 100, 80, 20), "Size 3"))
        {
            sliderValue = maxValue;
            avatarCount = (int)AvatarValues.Size3;
        }

        sliderValue = GUI.HorizontalSlider(new Rect(25, 130, 100, 30), sliderValue, minValue, maxValue);
        
        avatarCount = (int)(10 * sliderValue);

        avatarLoader.ActivateAvatars(avatarCount);

        GUI.Box(new Rect(10, 185, 125, 60), "Avatar Data");

        GUI.Label(new Rect(25, 215, 100, 50), "Total Avatars: " + avatarCount);


    }
}
