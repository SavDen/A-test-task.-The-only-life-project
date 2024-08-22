using UnityEngine;
using System;
using UnityEngine.TextCore.Text;

[Serializable]
public class Character 
{
    public CharacterController controller;

    [SerializeField] private float moveSpeed = 1, turnSpeed = 1;

    private float _yEuler;

    public void Move(Vector3 direction)
    {
        controller.SimpleMove(direction * moveSpeed);
    }

    public void Turn(float directionZ, Transform transform)
    {
        if (directionZ < 0)
        {
            _yEuler = -180;
        }

        else if(directionZ > 0)
        {
            _yEuler = 0;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, _yEuler, 0), turnSpeed);
    }
}
