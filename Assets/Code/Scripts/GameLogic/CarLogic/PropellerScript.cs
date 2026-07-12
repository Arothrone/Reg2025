using UnityEngine;
using UnityEngine.EventSystems;

public class PropellerScript : GeneralUpgradeScript
{
    private Animator animator;
    private bool running;
    [SerializeField] float propellerPower = 50f;
    private void Start()
    {
        animator = GetComponent<Animator>();
        running = animator.GetBool("run");
    }

    protected override void OnClick()
    {
        running = !running;
        animator.SetBool("run", running);
    }
    private void FixedUpdate()
    {
        if (running)
        {
            carRB.AddForce(transform.right * propellerPower, ForceMode2D.Force);
            
        }
    }
}
