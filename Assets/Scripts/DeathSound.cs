using UnityEngine;

public class DeathSound : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("NoMore", .3f);
    }

    public void NoMore()
    {
        Destroy(gameObject);
    }
}
