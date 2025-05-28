using UnityEngine;

public class OilPourer : MonoBehaviour
{
    [Header("Refs (arraste no Inspetor)")]
    public Transform pourPoint;   // Empty no bico
    public Transform oilStream;   // Cilindro FILHO do pourPoint

    [Header("Ajustes")]
    public float pourAngleThreshold = 100f; // graus
    public float maxStreamLength    = 0.15f; // 15 cm
    public float growSpeed          = 0.40f; // m/s
    public float streamRadius       = 0.015f; // raio (X e Z)

    Vector3 _startScale;
    float   _currentLen = 0f;

    void Awake()
    {
        // Garante hierarquia correta
        oilStream.SetParent(pourPoint, true);

        _startScale = new Vector3(streamRadius, 0f, streamRadius);
        SetStreamLength(0f);  // começa seco
    }

    void Update()
    {
        float tilt   = Vector3.Angle(transform.up, Vector3.up);
        float target = tilt > pourAngleThreshold ? maxStreamLength : 0f;

        _currentLen = Mathf.MoveTowards(_currentLen, target, growSpeed * Time.deltaTime);
        SetStreamLength(_currentLen);
    }

    // ---------- A TUA FUNÇÃO, só que 100 % em coordenadas locais ----------
    void SetStreamLength(float len)
    {
        float half = len * 0.5f;

        // cresce somente em Y
        oilStream.localScale    = new Vector3(_startScale.x, half, _startScale.z);

        // desloca o centro pra baixo metade do comprimento
        oilStream.localPosition = Vector3.down * half * -1;

        // NÃO mexe em rotation: ele já herda a rotação da garrafa,
        // o topo fica colado no pourPoint e a outra ponta cresce.
        // Se a malha do cilindro estiver “deitada”, simplesmente
        // rotacione o prefab 90/180 ° uma única vez no Editor.

        // Debug opcional
        // Debug.Log($"len={len}, half={half}, localPos={oilStream.localPosition}");
    }
}
