
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;

    // Animasyon adlarý
    private const string IdleAnimation = "Female_Idle";
    private const string WalkAnimation = "Female_Walk";
    private const string JumpAnimation = "Female_Jump";

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Karakteri yürütme
        float move = Input.GetAxis("Vertical");
        animator.SetFloat("Speed", move);

        // Zýplama animasyonunu baþlatma
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Jump");
        }
    }
}