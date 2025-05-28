using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorISopen : MonoBehaviour
{
    [Header("Настройки двери")]
    public Animator doorAnimator;
    public string boolParameter = "IsOpen"; // Параметр в аниматоре
    public float openDistance = 3f; // Дистанция срабатывания

    [Header("Цель")]
    public Transform player; // Ссылка на игрока
    private bool playerNearby = false;

    void Start()
    {
        if (doorAnimator == null)
            doorAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        // Проверяем дистанцию до игрока
        float distance = Vector3.Distance(transform.position, player.position);
        bool shouldOpen = distance <= openDistance;

        // Если состояние изменилось
        if (shouldOpen != playerNearby)
        {
            playerNearby = shouldOpen;
            doorAnimator.SetBool(boolParameter, shouldOpen);

            // Опционально: звук открытия/закрытия
            Debug.Log(playerNearby ? "Дверь открывается" : "Дверь закрывается");
        }
    }

    // Визуализация зоны срабатывания в редакторе
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, openDistance);
    }
}