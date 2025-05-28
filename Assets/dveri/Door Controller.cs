using UnityEngine;

public class DoorController1 : MonoBehaviour
{
    private Animator doorAnimator;
    private bool IsTriger = false;
    private static readonly int IsBoooHash = Animator.StringToHash("IsBooo");
    private bool isAnimating = false; // ‘лаг анимации
    void Start()
    {
        doorAnimator = GetComponentInChildren<Animator>();
        if (doorAnimator == null)
        {
            Debug.LogError("Animator not found!", this);
            enabled = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !IsTriger && !isAnimating)
        {
            StartCoroutine(OpenDoorRoutine());
        }
        else if (Input.GetKeyDown(KeyCode.Q) && IsTriger && !isAnimating)
        {
            StartCoroutine(CloseDoorRoutine());
        }
    }

    System.Collections.IEnumerator OpenDoorRoutine()
    {
        isAnimating = true;
        doorAnimator.SetBool(IsBoooHash, true);
        // ∆дем завершени€ анимации (учитывайте длину вашей анимации)
        yield return new WaitForSeconds(1f);
        IsTriger = true;
        isAnimating = false;
    }

    System.Collections.IEnumerator CloseDoorRoutine()
    {
        isAnimating = true;
        doorAnimator.SetBool(IsBoooHash, false);
        yield return new WaitForSeconds(1f);
        IsTriger = false;
        isAnimating = false;
    }
}
