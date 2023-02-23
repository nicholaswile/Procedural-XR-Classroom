// Nicholas Wile
// Dr. Sungchul Jung
// Created: Feb 13, 2023 - NW
// Last Edited: Feb 22, 2023 - NW

/// <summary>
/// This class loads the desks into the scene; it depends on the num of avatars. 
/// </summary> 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskLoader : MonoBehaviour
{
    [SerializeField] private GameObject desk;
    [SerializeField] private AvatarLoader avatarLoader;
    [SerializeField] private List<GameObject> deskInstances;

    private int totalDesks;
    private int numAvatars;
    private int numAvatarsPerChunk;

    // Start is called before the first frame update
    void Start()
    {
        if (avatarLoader == null)
        {
            avatarLoader = GetComponent<AvatarLoader>();
        }
        numAvatars = (int)avatarLoader.numAvatars;
        numAvatarsPerChunk = avatarLoader.numAvatarsPerChunk;
        totalDesks = (int) Mathf.Ceil(numAvatars / 5);
     
        PoolDesks();
    }

    private void PoolDesks()
    {
        GameObject temp;
        for (int i = 0; i < totalDesks; i++)
        {
            temp = Instantiate(desk);
            temp.SetActive(false);
            deskInstances.Add(temp);
        }
    }

    public void ActivateDesks(int activeAvatars)
    {
        int deskZStep = avatarLoader.deskZStep;
        int deskXStep = avatarLoader.deskXStep;
        int numCol = avatarLoader.numColumns;
        int initialDeskZPos = avatarLoader.initialAvatarZPos - 1;

        int deskNum = 0;
        int currentDeskRowNumber = 0;
        int deskPerCol = 5;

        // Formula: Player Position - 1/2 (DistanceBtwnDesks) * (NumberAdditionalColumns)
        // If only one column, desks spawn in same X position as player
        // If two columns, desks spawn at X=-1/2 Distance and X=+1/2 Distance
        // If three columns, desks spawn at X=-1 Distance, X=0 Distance, and X=1 Distance
        // And so on...


        int deskZPos = initialDeskZPos + deskZStep * deskNum;
        float deskXPos = (0 - (numCol - 1) * .5f * deskXStep);

        GameObject desk;

        for (int i = 0; i < numAvatars; i++)
        {

            if (i%5 != 0)
            {
                continue;
            }
          
            desk = deskInstances[deskNum];
            desk.transform.position = new Vector3(deskXPos, 1, deskZPos);

            if (i >= activeAvatars)
            {
                desk.SetActive(false);
            }
            else
            {
                desk.SetActive(true);
            }
            
            deskNum++;
            currentDeskRowNumber++;
            
            if (deskNum % deskPerCol == 0)
            { 
                deskXPos += deskXStep;
               
                currentDeskRowNumber = 0;
                
            }

            deskZPos = initialDeskZPos + deskZStep * currentDeskRowNumber;

        }
    }
}
