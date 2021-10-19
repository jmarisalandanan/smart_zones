using UnityEngine;

public class TriggerHandler : MonoBehaviour
{
    public LayerMask layer;
    public IntEvent OnActorEnteredSmartZone;

    private void OnTriggerEnter(Collider col)
    {
        if (1 << col.gameObject.layer == layer.value)
        {
            OnActorEnteredSmartZone.Invoke(col.gameObject.GetInstanceID());
        }
    }
}
