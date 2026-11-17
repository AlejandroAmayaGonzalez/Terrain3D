using UnityEngine;

[ExecuteInEditMode]
public class ProceduralTerrain : MonoBehaviour {
    
    public Terrain myTerrain;
    private TerrainData myTerrainData;

    public float perlinScale = 0.05f;
    public float perlinHeight = 0.3f;

    private void OnEnable(){
        myTerrain = this.GetComponent<Terrain>();
        myTerrainData = myTerrain.terrainData;
    }

    public void RandomTerrain(){
        float[,] heights = new float[myTerrainData.heightmapResolution,myTerrainData.heightmapResolution];

        for (int i = 0; i < myTerrainData.heightmapResolution; i++){
            for (int j = 0; j < myTerrainData.heightmapResolution; j++){
                heights[i,j] = (float)Random.Range(0.0f, 1.0f);
            }
        }

        myTerrainData.SetHeights(0, 0, heights);
    }

    public void PerlinTerrain(){
        float[,] heights = new float[myTerrainData.heightmapResolution,myTerrainData.heightmapResolution];

        for (int i = 0; i < myTerrainData.heightmapResolution; i++){
            for (int j = 0; j < myTerrainData.heightmapResolution; j++){
                float height = (float) Mathf.PerlinNoise(i * perlinScale, j * perlinScale) * perlinHeight;
                heights[i,j] = Mathf.Clamp(height, 0.0f,1.0f);
            }
        }

        myTerrainData.SetHeights(0, 0, heights);
    }

    public void ClearTerrain(){
        float[,] heights = new float[myTerrainData.heightmapResolution,myTerrainData.heightmapResolution];

        myTerrainData.SetHeights(0, 0, heights);
    }
}
