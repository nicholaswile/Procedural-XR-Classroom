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
        int j = 0;
        GameObject desk;
        for (int i = 0; i < numAvatars; i++)
        {
            if (i%5 != 0)
            {
                continue;
            }
            desk = deskInstances[j];
            desk.transform.position = new Vector3(2, 1, -1 + 3 * j);
            if (i >= activeAvatars)
            {
                desk.SetActive(false);
            }
            else
            {
                desk.SetActive(true);
            }
            j++;
        }
    }
}
