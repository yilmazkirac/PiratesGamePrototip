using UnityEngine;
public class ShipController : MonoBehaviour, IInteract
{
    public float Speed;

    public float ShipSpeed;
    public float ShipAngulerStop;
    public float ShipAngulerSpeed;

    public float RotSpeed;
    public float RotAngulerStop;
    public float RotAngulerSpeed;

    bool shipControl;

    [SerializeField] private Transform _spawner;
   
    private void Update()
    {      
        if (shipControl)
        {
            gameObject.transform.Translate(0, 0, SetSpeed() * Time.deltaTime * Speed);
            gameObject.transform.Rotate(0, SetRot() * Time.deltaTime * Speed, SetRot() * Time.deltaTime * Speed);
            if (Input.GetKeyDown(KeyCode.R))
            {
                GameManager.Instance.Player.transform.position = _spawner.position;
                GameManager.Instance.Cam1.SetActive(shipControl);
                GameManager.Instance.Cam2.SetActive(!shipControl);
                GameManager.Instance.Player.SetActive(shipControl);
                Execute();
            }
        }      
    }


    private float SetSpeed()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (ShipSpeed < 1)
            {
                return ShipSpeed += Time.deltaTime * ShipAngulerSpeed;
            }
            else
            {
                return 1f;
            }

        }
        else
        {
            if (ShipSpeed > 0)
            {
                return ShipSpeed -= Time.deltaTime * ShipAngulerStop;
            }
            else
            {
                return 0;
            }
        }
    }

    private float SetRot()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (RotSpeed >-1f&& RotSpeed < 0)
            {
                return RotSpeed -= Time.deltaTime * RotAngulerSpeed;
            }
           else if (RotSpeed > -1f)
            {
                return RotSpeed -= Time.deltaTime * RotAngulerSpeed*2;
            }
            else
            {
                return -1f;
            }
        }
   
        else if (Input.GetKey(KeyCode.D))
        {
            if (RotSpeed < 1f && RotSpeed > 0)
            {
                return RotSpeed += Time.deltaTime * RotAngulerSpeed;
            }
            else if (RotSpeed <1f)
            {
                return RotSpeed += Time.deltaTime * RotAngulerSpeed * 2;
            }
            else
            {
                return 1f ;
            }
        }
        else
        {
            if (RotSpeed > 0)
            {
                return RotSpeed -= Time.deltaTime * RotAngulerStop;
            }
            else if (RotSpeed < 0)
            {
                return RotSpeed += Time.deltaTime * RotAngulerStop;
            }
            else
            {
                return 0;
            }
        }
    }

    public void Execute()
    {
        shipControl = shipControl ? false : true;
        GameManager.Instance.Cam1.SetActive(!shipControl);
        GameManager.Instance.Cam2.SetActive(shipControl);
        GameManager.Instance.Player.SetActive(!shipControl);
      
    }
}
