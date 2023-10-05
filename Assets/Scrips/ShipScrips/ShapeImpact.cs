using UnityEngine;

public class ShapeImpact : MonoBehaviour
{
    // Start is called before the first frame update
    protected Collider2D _collider2D;
    protected Rigidbody2D _rigidbody2D;
    public DamageReceiver _receiver;
    // Start is called before the first frame update
    private void Awake()
    {
        
        this.LoadComponent();
    }
    protected void LoadComponent()
    {
        this._receiver = transform.parent.GetComponentInChildren<DamageReceiver>();
        this._collider2D = GetComponent<Collider2D>();
        this._rigidbody2D = GetComponent<Rigidbody2D>();
    }
    public virtual void DestroyShape()
    {
        Destroy(transform.parent.gameObject);
    }
}
