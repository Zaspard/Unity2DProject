using UnityEngine;

public class Unit : MonoBehaviour {

    protected virtual void ReceivingDamage()
    { }

    protected virtual void CausingDamage()
    { }

    protected virtual void Die()
    {
        Destroy(gameObject);
    }

    protected virtual void Move()
    { }
}
