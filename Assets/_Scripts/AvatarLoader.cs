// Nicholas Wile
// Dr. Sungchul Jung
// Created: Jan 17, 2023 - NW
// Last Edited: Feb 22, 2023 - NW

/// <summary>
/// This class loads the avatars into the scene. 
/// </summary> 

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AvatarLoader : MonoBehaviour
{
    public int numColumns = 1;
    public int numAvatars = 50;
    public int numAvatarsPerChunk = 25;
    public int deskZStep = 3;
    public int deskXStep = 7;
    public int initialAvatarZPos = 6;

    [SerializeField] private List<GameObject> avatars;
    [SerializeField] private List<GameObject> avatarInstances;
    [SerializeField] private float height = .83f;
    [SerializeField] private DeskLoader deskLoader;

    [SerializeField] private GameObject desk;
    [SerializeField] private List<GameObject> deskInstances;


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
        int target, previous = -1;

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
            // (because for some reason cc/ic exports models facing backwards)
            temp.transform.Rotate(0, 180, 0);
            
            temp.SetActive(false);
            avatarInstances.Add(temp);
        }
    }

    public void ActivateAvatars(int numAvatarsToLoad)
    {
        int numAvatarsCurrentlyLoaded = 0;

        // Z position of avatar
        int currentDeskRowNumber = 0;

        // X position of avatar
        numColumns = (int)Mathf.Ceil((float)numAvatarsToLoad / (float)numAvatarsPerChunk);

        int deskLength = 4;
        int numAvatarsPerDesk = 5;
        int avatarXStep = deskLength / (numAvatarsPerDesk - 1);
        int changeInAvatarXPos = 0;
        float intialAvatarXPos = (0 - (numColumns-1)*.5f*deskXStep-(numAvatarsPerDesk - 1) * .5f * avatarXStep);
        float currentAvatarXPos;

        deskLoader.ActivateDesks(numAvatarsToLoad);

        foreach (GameObject avatar in avatarInstances)
        {
            currentAvatarXPos = intialAvatarXPos + changeInAvatarXPos;

            avatar.transform.position = new Vector3(currentAvatarXPos, height, initialAvatarZPos + currentDeskRowNumber);

            if (numAvatarsCurrentlyLoaded < numAvatarsToLoad)
            {
                avatar.SetActive(true);
            }

            else
            {
                avatar.SetActive(false);
            }

            numAvatarsCurrentlyLoaded++;

            changeInAvatarXPos += avatarXStep;

            // Start a new row after numAvatarsPerDesk is reached
            if (numAvatarsCurrentlyLoaded%numAvatarsPerDesk == 0)
            {
                currentDeskRowNumber += deskZStep;
                changeInAvatarXPos = 0;
            }

            // Start a new column after numAvatarsPerChunk is reached
            if (numAvatarsCurrentlyLoaded%numAvatarsPerChunk == 0)
            {
                intialAvatarXPos += deskXStep;
                currentDeskRowNumber = 0;
            }

        }
    }
    
}
