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
        if(GUILayout.Button("맵을 생성합니다."))
        {
            mapGenerator.BuildGenerator();
        }
    }
}
/** 
 * 유니티 스크립트 창 GUI를 건드는 스크립트 **/


