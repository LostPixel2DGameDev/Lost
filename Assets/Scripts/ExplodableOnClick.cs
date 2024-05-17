using UnityEngine;

[RequireComponent(typeof(Explodable))]
public class ExplodeOnClick : MonoBehaviour
{
    private Explodable _explodable;

    private void Start()
    {
        _explodable = GetComponent<Explodable>();
        if (_explodable == null)
        {
            Debug.LogError("Explodable component not found!");
        }
    }

    private void OnMouseDown()
    {
        if (_explodable != null)
        {
            _explodable.explode();
            ExplosionForce ef = GameObject.FindObjectOfType<ExplosionForce>();
            if (ef != null)
            {
                ef.doExplosion(transform.position);
            }
            else
            {
                Debug.LogError("ExplosionForce component not found!");
            }
        }
    }
}


