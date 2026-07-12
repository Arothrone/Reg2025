using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class WingsScript : GeneralUpgradeScript
{
    private Animator animator;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float waitTime = 1f;

    private bool isFlying;

    private void Start()
    {

        animator = GetComponent<Animator>();
    }

    protected override void OnClick()
    {
        StartCoroutine(Fly());
    }

    IEnumerator Fly()
    {
        if (!isFlying)
        {
            if (animator != null)
            {
                animator.SetTrigger("wingsTrigger");
            }
            isFlying = true;
            carRB.AddForceAtPosition(Vector2.up * jumpForce, carRB.worldCenterOfMass, ForceMode2D.Impulse);
            yield return new WaitForSeconds(waitTime);
            isFlying = false;
        }
        yield return null;
    }
}
