// Nicholas Wile
// Dr. Sungchul Jung
// Jan 17, 2023

/// <summary>
/// This class loads the avatars into the scene. 
/// </summary> 

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AvatarLoader : MonoBehaviour
{
    public int numAvatars = 50;
    public int numAvPerChunk = 25;


    [SerializeField] private List<GameObject> avatars;
    [SerializeField] private List<GameObject> avatarInstances;
    [SerializeField] private float height = .83f;
    [SerializeField] private DeskLoader deskLoader;

    // We will use this to place avatars in their desks eventually... 
    private List<Transform> positions;

    private int totalAvatars;


    // Start is called before the first frame update
    void Start()
    {
        if (deskLoader == null)
        {
            deskLoader = GetComponent<DeskLoader>();
        }

        PoolAvatars();
    }

    private void PoolAvatars()
    {

        System.Random rnd = new System.Random();
        totalAvatars = avatars.Count;
        GameObject temp;
        int target, previous=-1;

        for (int i = 0; i < numAvatars; i++)
        {
            // Do this so that the same avatar doesn't load next to itself
            do
            {
                target = rnd.Next(0, totalAvatars);

            } while (target == previous);
            previous = target;

            temp = Instantiate(avatars[target]);

            // Assign a random color to each placeholder object
            //temp.GetComponent<Renderer>().material.color = new Vector4(rnd.Next(0, 2), rnd.Next(0, 2), rnd.Next(0, 2), 1);
            
            //faces avatar in correct direction
            // (because for some reason cc/ic exports them facing backwards)
            temp.transform.Rotate(0, 180, 0);

            temp.SetActive(false);
            avatarInstances.Add(temp);
        }
    }

    public void ActivateAvatars(int i)
    {

        deskLoader.ActivateDesks(i);

        int j = 0;

        // Used for calculating position
        int rowNumber = 0;
        //int avPerRow = i / 3;
        int avPerRow = 5;
        //int rowStep = i/avPerRow;
        int rowStep = 1;
        int colNumber = 0;
        int colStep = 3;

        /*int maxRows = 5;
        int nextCol = 7;*/

        int deskStep = 7;
        int avXPos = -2;


        int deskLength = 4;
        int numAvatarPerDesk = 5;
        int avatarXStep = deskLength / (numAvatarPerDesk - 1);
        float avatarXPos = (0 - (numAvatarPerDesk - 1) * .5f * avatarXStep);

        foreach (GameObject avatar in avatarInstances)
        {
            avatar.transform.position = new Vector3(colNumber+avXPos, height, rowNumber);

            if (j < i)
            {
                avatar.SetActive(true);
            }
            else
            {
                avatar.SetActive(false);
            }
            j++;

            // Used for calculating position
            colNumber += rowStep;
            if (j%avPerRow == 0)
            {
                rowNumber += colStep;
                colNumber = 0;
            }
            if (j%numAvPerChunk == 0)
            {
                avXPos += deskStep;
                rowNumber = 0;
            }

        }
    }
    
}
