using UnityEngine;

public class AbrirFecharForno : MonoBehaviour
{
    public ControleForno forno;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            forno.AlternarEstadoForno();
        }
    }
}