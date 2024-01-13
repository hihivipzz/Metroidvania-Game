using System;
using UnityEngine;

public class HearthLayer : MonoBehaviour
{
    public static HearthLayer instance { get; private set; }
    private GameObject[] hearts;
    [SerializeField] Player player;
    private int currentHeart;

    void Awake()
    {
        instance = this;

    }

    void Start()
    {
        hearts = GetAllHearts();
        currentHeart = player.currentLive;
        player.OnPlayerLiveChange += Player_OnPlayerLiveChange;
        UpdateHeart();
    }

    private void Player_OnPlayerLiveChange(object sender, EventArgs e)
    {
        currentHeart = player.currentLive;
        UpdateHeart();
    }

    void Update()
    {

    }

    public GameObject[] GetAllHearts()
    {
        Transform[] childTransforms = GetComponentsInChildren<Transform>();

        var childrenList = new System.Collections.Generic.List<GameObject>();
        foreach (Transform childTransform in childTransforms)
        {
            if (childTransform.gameObject != gameObject)
            {
                childrenList.Add(childTransform.gameObject);
            }
        }

        return childrenList.ToArray();
    }

    public void RemoveHeart(int removeAt)
    {
        if (removeAt < 0 || removeAt > hearts.Length)
        {
            return;
        }

        Destroy(hearts[removeAt]);

        hearts[removeAt] = null;
    }

    public void UpdateHeart()
    {
        for (int i = 0; i < currentHeart; i++)
        {
            hearts[i].SetActive(true);
        }

        for (int i = currentHeart; i < hearts.Length; i++)
        {
            hearts[i].SetActive(false);
        }
    }
}
