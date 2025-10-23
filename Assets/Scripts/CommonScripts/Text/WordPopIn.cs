using UnityEngine;
using DG.Tweening;

public class WordPopIn : MonoBehaviour
{
    [Header("Harfler")]
    public Transform[] letters;

    [Header("Ayarlamalar")]
    public float delayBetween = 0.15f;         // Harfler arasi gecikme
    public float scaleTime = 0.4f;             // Her harfin buyume suresi
    public float startDelay = 0.5f;            // Sayfa acildiktan sonra gecikme
    public Ease ease = Ease.OutBack;           // Scale easing

    private Vector3[] originalScales;

    private void OnEnable()
    {
        // Orijinal scale'lari kaydet
        originalScales = new Vector3[letters.Length];
        for (int i = 0; i < letters.Length; i++)
        {
            originalScales[i] = letters[i].localScale;
            letters[i].localScale = Vector3.zero;
        }

        // Gecikmeli olarak animasyon baslat
        DOVirtual.DelayedCall(startDelay, () =>
        {
            for (int i = 0; i < letters.Length; i++)
            {
                letters[i].DOScale(originalScales[i], scaleTime)
                          .SetEase(ease)
                          .SetDelay(i * delayBetween);
            }
        });
    }
}
