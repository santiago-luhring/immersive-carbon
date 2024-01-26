using UnityEngine;

public class MenuBlocker : MonoBehaviour
{
    void LateUpdate()
    {
        float x = (float)-1.813124;
        float y = (float)2.5;
        float z = (float)-11.77943;
        // Defina a posição desejada da câmera a cada quadro
        // Isso impede que a câmera se mova, mas ainda permite rotação
        transform.position = new Vector3(x,y,z);
    }
}