using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector3 _direction;
    private Rigidbody _rigidbody;
    private CharacterController _characterController;
    private Animator _animator;
    private Collider[] _colliders;
    private float _nextCollectTime;
    private float _gravityValue = -9.81f;

    [SerializeField] float turnSmoothVelocity;
    [SerializeField] float smoothTurnTime = 0.01f;
    [SerializeField] private float movementSpeed = 10;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float detectionRange;
    [SerializeField] private Transform detectionTransform;
    [SerializeField] float collectRate = 1;
    [SerializeField] float collectSecond = 1;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(detectionTransform.position, detectionRange);
    }

    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();

        _colliders = Physics.OverlapSphere(detectionTransform.position, detectionRange, layerMask);

        foreach (Collider hit in _colliders)
        {
            if (hit.CompareTag("Baobab") && Time.time >= _nextCollectTime)
            {
                _animator.SetTrigger($"Collect");

                StartCoroutine(nameof(Blow));

                _nextCollectTime = Time.time + collectSecond / collectRate;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag($"Zone"))
        {
            other.transform.DOScale(0.2f, 0.2f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag($"Zone"))
        {
            other.transform.DOScale(0.15f, 0.2f);
        }
    }

    private void Move()
    {
        _direction = new Vector3(InputManager.Horizontal, 0, InputManager.Vertical);

        _animator.SetFloat($"Running", _direction.magnitude);

        if (_direction.magnitude > 0.01f)
        {
            float targetAngle = Mathf.Atan2(_direction.x, _direction.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity,
                smoothTurnTime);

            transform.rotation = Quaternion.Euler(0, angle, 0);
            
            _direction.y = _gravityValue * Time.deltaTime;
            
            _characterController.Move(_direction * (movementSpeed * Time.deltaTime)); 
        }
    }

    IEnumerator Blow()
    {
        yield return new WaitForSeconds(0.5f);
        foreach (Collider hitCollider in _colliders)
        {
            hitCollider.GetComponentInParent<Baobab>().Blow();
        }
    }
}