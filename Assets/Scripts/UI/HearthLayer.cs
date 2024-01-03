using UnityEngine;

public class HearthLayer : MonoBehaviour
{
    public static HearthLayer instance { get; private set; }
    private GameObject[] hearts;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        hearts = GetAllHearts();
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
            Debug.LogError("Invalid index for heart removal: " + removeAt);
            return;
        }

        Destroy(hearts[removeAt]);

        hearts[removeAt] = null;
    }
}
