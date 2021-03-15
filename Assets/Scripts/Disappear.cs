using UnityEngine;

public class Disappear : MonoBehaviour
{
    // Start is called before the first frame update
    public void EffectEnd()
    {
        Destroy(gameObject);
    }

    public void SetInactive()
    {
        gameObject.SetActive(false);
    }
}
