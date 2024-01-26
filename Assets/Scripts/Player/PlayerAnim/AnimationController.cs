using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class AnimationController : MonoBehaviour
{
    public Animator _animator;

    public void SetBool(string name,bool value)
    {
        _animator.SetBool(name, value);
    } 
    public void CrossFade(string name,float value)
    {
        _animator.CrossFade(name, value);
    }

    public void StopAttack()
    {
        _animator.SetBool("Attack", false);
    }
}
