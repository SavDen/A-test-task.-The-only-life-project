
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField] private  Transform _target;
    [SerializeField] private float _speed;
    [SerializeField] private Vector3 _offset;

    private PlayerInput _inputs;
    private bool _forward = true;
    private float _posZLeft, _posZRight;

    private void Awake()
    {
        _posZLeft = -_offset.z;
        _posZRight = _offset.z;

        _inputs = new PlayerInput();
        _inputs.Enable();
    }

    private void LateUpdate()
    {

        if(_target != null)
        {
            TurnCamera();

            MoveCamera();
        }
    }

    private void TurnCamera()
    {
        var direstionZ = _inputs.Player.JoyStick.ReadValue<Vector3>();

        if (direstionZ.z > 0)
            _forward = true;

        else if (direstionZ.z < 0)
            _forward = false;

    }

    private void MoveCamera()
    {
        if (_forward)
            _offset.z = _posZRight;
        else
            _offset.z = _posZLeft;

        transform.position = Vector3.MoveTowards(transform.position, _target.position + _offset, _speed);
    }
}
