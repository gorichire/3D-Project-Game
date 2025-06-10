using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        float move_amount = Mathf.Clamp01(Mathf.Abs(movement.x) + Mathf.Abs(movement.z));

        animator.SetFloat("MoveAmount", move_amount);

        if(move_amount > 0f)
        {
            Quaternion target_rotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, target_rotation ,500 * Time.deltaTime);
        }
    }
}
