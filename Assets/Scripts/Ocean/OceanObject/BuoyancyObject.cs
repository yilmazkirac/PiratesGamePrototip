using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BuoyancyObject : MonoBehaviour
{
    public Transform[] Floaters;
    public float UnderWatherDrag = 3;
    public float UnderWatherAngularDrag = 1;

    public float AirDrag = 0;
    public float AirAngularDrag = 0.05f;


    public float FloatingPower = 15;

    public float WaterHeight=0;

    Rigidbody rigidbody;
    int floatersUnderWater;

    bool underWater;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        floatersUnderWater = 0;
        for (int i = 0; i < Floaters.Length; i++)
        {
            float difference = Floaters[i].position.y - WaterHeight;

            if (difference < 0)
            {
                rigidbody.AddForceAtPosition(Vector3.up * FloatingPower * Mathf.Abs(difference), Floaters[i].position, ForceMode.Force);
                floatersUnderWater += 1;
                if (!underWater)
                {
                    underWater = true;
                    SwitchState(true);
                }
            }
        }

        if (underWater&& floatersUnderWater==0)
        {
            underWater = false;
            SwitchState(false);
        }
    }

    void SwitchState(bool isUnderWater)
    {
        if (isUnderWater)
        {
            rigidbody.drag = UnderWatherDrag;
            rigidbody.angularDrag = UnderWatherAngularDrag;
        }
        else
        {
            rigidbody.drag = AirDrag;
            rigidbody.angularDrag = AirAngularDrag;
        }
    }
}
