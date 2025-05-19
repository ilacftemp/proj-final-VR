using UnityEngine;

public class CortarMassaEmTiras : MonoBehaviour
{
    public GameObject massaDividida;
    public string tagPizzaCutter = "PizzaCutter";

    private static bool massaJaFoiCortada = false;

    private void OnTriggerEnter(Collider other)
    {
        if (massaJaFoiCortada) return;

        if (other.CompareTag(tagPizzaCutter))
        {
            massaJaFoiCortada = true;
            massaDividida.SetActive(true);
            gameObject.SetActive(false);
        }
    }

    public static void ResetarEstado()
    {
        massaJaFoiCortada = false;
    }
}
