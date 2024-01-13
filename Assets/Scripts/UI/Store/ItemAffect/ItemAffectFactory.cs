using System.Collections.Generic;
using UnityEngine;

public class ItemAffectFactory : MonoBehaviour
{
    private Dictionary<int, ItemAffect> listItemAffect;
    private static ItemAffectFactory instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            listItemAffect = new Dictionary<int, ItemAffect>();
            listItemAffect.Add(3, GetComponent<HealingAffect>());
        }
        else
        {
            Destroy(this);
        }
    }

    public static ItemAffectFactory Instance
    {
        get
        {
            return instance;
        }
    }

    public ItemAffect CreateAffect(int type)
    {
        return listItemAffect[type];
    }
}
