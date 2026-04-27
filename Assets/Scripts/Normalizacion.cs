using UnityEngine;

public class Normalizacion : MonoBehaviour
{
    [SerializeField] private Transform tank;
    [SerializeField] private Transform robot;
    [SerializeField] private float velocidadMovimiento = 1f;  
   
    private void Update()
    {
        if (tank == null || robot == null) return;

        // Calculate direction: Target - Current Position
        Vector3 direccion = (robot.position - tank.position).normalized;
        tank.position += direccion * velocidadMovimiento * Time.deltaTime;
    }
}
