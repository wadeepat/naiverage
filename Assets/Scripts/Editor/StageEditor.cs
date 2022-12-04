using UnityEditor;

// [CustomEditor(typeof(StageHandler))]
public class StageEditor : Editor
{
    public SceneIndex sceneName;

    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();
        serializedObject.Update();
        sceneName = (SceneIndex)EditorGUILayout.EnumPopup("Scene", sceneName);

        EditorGUILayout.Space();

        switch (sceneName)
        {
            case SceneIndex.Tutorial:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("t_startGate"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("t_naverGate"));
                break;
            case SceneIndex.NaverTown:
                EditorGUILayout.PropertyField(serializedObject.FindProperty("n_rachneGate"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("n_calfordGate"));
                EditorGUILayout.PropertyField(serializedObject.FindProperty("n_braewoodGate"));
                break;
            case SceneIndex.CalfordCastle:
                //TODO
                break;
            case SceneIndex.BraewoodForest:
                //TODO
                break;
            case SceneIndex.Cave:
                //TODO
                break;
        }
        serializedObject.ApplyModifiedProperties();
    }
}
