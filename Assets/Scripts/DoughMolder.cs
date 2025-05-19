using UnityEngine;

public class DoughMolder : MonoBehaviour
{
    public GameObject flatDough;       // Massa achatada
    public GameObject moldedDough;     // Massa moldada (cannoli)
    public GameObject poofEffect;      // Prefab do efeito com som e partículas

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("FlatDough"))
        {
            // Instancia o efeito visual + som
            if (poofEffect != null && flatDough != null)
            {
                Vector3 spawnPosition = flatDough.transform.position + Vector3.up * 0.05f;
                GameObject effect = Instantiate(poofEffect, spawnPosition, Quaternion.identity);
                Destroy(effect, 2f); // destrói após 2 segundos
            }

            flatDough.SetActive(false);
            moldedDough.SetActive(true);
        }
    }
}
