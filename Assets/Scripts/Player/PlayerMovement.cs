using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MouseSens = 1f;
    private Vector2 mouseInput;
    public float MoveSpeed = 5f, RunSpeed = 8f;
    private Vector3 moveDir;
    private Vector3 movement;
    public CharacterController CharCont;
    public float JumpForce = 12f, GravityMod = 2.5f;
    [SerializeField] private AnimationController animationController;

 

    public void Rotation()
    {
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * MouseSens;
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseInput.x, transform.rotation.eulerAngles.z);
    }

    public void Move() 
    {
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        float yVel = movement.y;
        movement = ((transform.forward * moveDir.z) + (transform.right * moveDir.x)).normalized * Speed();
        movement.y = yVel;
        if (CharCont.isGrounded)
        {
            animationController.SetBool("Jump", false);
            movement.y = 0;
        }
        if (Input.GetButtonDown("Jump") && CharCont.isGrounded)
        {
            animationController.SetBool("Jump", true);
            movement.y = JumpForce;
        }
        movement.y += Physics.gravity.y * Time.deltaTime * GravityMod;
        CharCont.Move(movement * Time.deltaTime);
    }


    private float Speed()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
          return  RunSpeed;
        }
       else
        {
            return MoveSpeed;
        }      
    }

}
