using UnityEngine;

public class Item : MonoBehaviour
{

    public Item instance;

    public void Awake()
    {
        instance = this;
    }

    public void DestroySelf(int v)
    {
        moneyCounter.instance.ServedCoffe();
        Destroy(gameObject);
    }
}
