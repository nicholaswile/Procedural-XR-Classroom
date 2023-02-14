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

    // Start is called before the first frame update
    void Start()
    {
        if (avatarLoader == null)
        {
            avatarLoader = GetComponent<AvatarLoader>();
        }
        numAvatars = (int)avatarLoader.numAvatars;
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
        int deskNum = 0;
        int deskZPos = -1 + 3 * deskNum;
        int j = 0;

        int deskXPos = 2;
        int deskXStep = 7;

        int deskPerCol = 5;
      
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
            j++;
            
            if (deskNum % deskPerCol == 0)
            {
                deskXPos += deskXStep;
                j = 0;
                
            }

            deskZPos = -1 + 3 * j;

        }
    }
}
