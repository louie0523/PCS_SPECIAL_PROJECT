using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



[CustomEditor(typeof(MapGenerator))]
public class MapGenEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MapGenerator mapGenerator = (MapGenerator)target;
        if(GUILayout.Button("���� �����մϴ�."))
        {
            mapGenerator.BuildGenerator();
        }
    }
}
/** 
 * ����Ƽ ��ũ��Ʈ â GUI�� �ǵ�� ��ũ��Ʈ **/


