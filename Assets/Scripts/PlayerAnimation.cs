using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }
}
