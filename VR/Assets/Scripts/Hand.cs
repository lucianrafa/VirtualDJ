using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Hand : MonoBehaviour
{
    private Animator _animator;
    private float _gripTarget;
    private float _triggerTarget;
    private float _gripCurrent;
    private float _triggerCurrent;
    private string animatorGripParam="Grip";
    private string animatorTriggerParam="Trigger";
    public float speed;

    [SerializeField] private GameObject followObject;
    [SerializeField] private float followSpeed=30f;
    [SerializeField] private float rotateSpeed=100f;
    [SerializeField] private Vector3 positionOffset;
    [SerializeField] private Vector3 rotationOffset;
    private Transform _followTarget;
    private Rigidbody _body;
    void Start()
    {

        _animator = GetComponent<Animator>();

        _followTarget = followObject.transform;
        _body = GetComponent<Rigidbody>();
        _body.collisionDetectionMode = CollisionDetectionMode.Continuous;
        _body.interpolation = RigidbodyInterpolation.Interpolate;
        _body.mass = 20f;
        
        //tp hands
        _body.position = _followTarget.position;
        _body.rotation = _followTarget.rotation;
    }

    void Update()
    {
        AnimateHand();

        PhysicsMove();
    }

    private void PhysicsMove()
    {

        var positioWithOffset = _followTarget.position + positionOffset;
        var distance = Vector3.Distance(positioWithOffset, transform.position);
        _body.velocity = (positioWithOffset - transform.position).normalized * (followSpeed * distance);

        var rotationWithOffset = _followTarget.rotation * Quaternion.Euler(rotationOffset);
        var q = rotationWithOffset * Quaternion.Inverse(_body.rotation);
        q.ToAngleAxis(out float angle, out Vector3 axis);
        _body.angularVelocity = axis * (angle * Mathf.Deg2Rad * rotateSpeed);
    }

    private void AnimateHand()
    {
        if (_gripCurrent!=_gripTarget)
        {
            _gripCurrent = Mathf.MoveTowards(_gripCurrent, _gripTarget, Time.deltaTime * speed);
            _animator.SetFloat(animatorGripParam,_gripCurrent);
        }
        if (_triggerCurrent!=_triggerTarget)
        {
            _triggerCurrent = Mathf.MoveTowards(_triggerCurrent, _triggerTarget, Time.deltaTime * speed);
            _animator.SetFloat(animatorTriggerParam,_triggerCurrent);
        }
    }

    public void SetGrip(float readValue)
    {
        _gripTarget = readValue;
    }

    public void SetTrigger(float readValue)
    {
        _triggerTarget = readValue;
    }
}
