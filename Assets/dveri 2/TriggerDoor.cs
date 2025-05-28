using UnityEngine;

public class TriggerDoor : MonoBehaviour
{
    public Animator doorAnimator;
    public string boolParameter = "IsOpen";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetBool(boolParameter, true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorAnimator.SetBool(boolParameter, false);
        }
    }
}