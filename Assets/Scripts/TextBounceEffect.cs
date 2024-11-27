using UnityEngine;
using TMPro;
using System.Collections;

public class TextBounceEffect : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    public float fallDistance = 1000f;       // Distance letters fall from above
    public float horizontalOffset = 200f;    // Horizontal offset distance
    public float bounceHeight = 50f;         // Bounce height
    public float animationDuration = 0.6f;   // Duration for the falling and bounce
    public float staggerDelay = 0.05f;       // Delay between each letter's animation

    private void OnEnable()
    {
        StartCoroutine(AnimateLetters());
    }

    private IEnumerator AnimateLetters()
    {
        textMeshPro.ForceMeshUpdate();  // Ensures the text mesh is up-to-date
        TMP_TextInfo textInfo = textMeshPro.textInfo;

        // Store original positions to reset them later
        Vector3[][] originalVertices = new Vector3[textInfo.characterCount][];

        // Set initial positions off-screen with offset before animation starts
        for (int i = 0; i < textInfo.characterCount; i++)
        {
            if (!textInfo.characterInfo[i].isVisible) continue;

            int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;
            int vertexIndex = textInfo.characterInfo[i].vertexIndex;

            Vector3[] vertices = textInfo.meshInfo[materialIndex].vertices;

            // Store the original vertex positions for resetting later
            originalVertices[i] = new Vector3[4];
            for (int j = 0; j < 4; j++)
                originalVertices[i][j] = vertices[vertexIndex + j];

            // Calculate the starting position with offset
            Vector3 startPosition = originalVertices[i][0] + Vector3.up * fallDistance + Vector3.right * horizontalOffset;

            // Move the vertices to the starting position with offset
            for (int j = 0; j < 4; j++)
                vertices[vertexIndex + j] = startPosition;
        }
        textMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);

        // Start staggered animation for each letter
        for (int i = textInfo.characterCount - 1; i >= 0; i--)
        {
            if (!textInfo.characterInfo[i].isVisible) continue;

            int materialIndex = textInfo.characterInfo[i].materialReferenceIndex;
            int vertexIndex = textInfo.characterInfo[i].vertexIndex;

            Vector3[] vertices = textInfo.meshInfo[materialIndex].vertices;

            // Backup the target original position for each vertex
            Vector3[] targetPositions = originalVertices[i];

            Vector3 startPosition = targetPositions[0] + Vector3.up * fallDistance + Vector3.right * horizontalOffset;

            float elapsedTime = 0f;
            while (elapsedTime < animationDuration)
            {
                float t = elapsedTime / animationDuration;
                float bounce = Mathf.Sin(t * Mathf.PI) * bounceHeight * (1f - t);
                Vector3 currentPosition = Vector3.Lerp(startPosition, targetPositions[0], t) + Vector3.up * bounce;

                // Apply bounce effect to all vertices of this character
                for (int j = 0; j < 4; j++)
                    vertices[vertexIndex + j] = currentPosition + (targetPositions[j] - targetPositions[0]);

                textMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);

                elapsedTime += Time.deltaTime;
                yield return null;
            }

            // Snap to final position
            for (int j = 0; j < 4; j++)
                vertices[vertexIndex + j] = targetPositions[j];

            textMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.Vertices);

            // Delay before starting the next letter’s animation
            yield return new WaitForSeconds(staggerDelay);
        }
    }
}
