﻿// Made with <3 by Ryan Boyer http://ryanjboyer.com

#if UNITY_EDITOR
using UnityEditor;

namespace BurstLines.Editors
{
    public abstract class ShapeSOEditor : Editor
    {
        protected ShapeSO scriptableObject;
        protected Shape shapeObject;

        protected SerializedProperty shape;

        protected SerializedProperty position;
        protected SerializedProperty eulerRotation;
        protected SerializedProperty scale;

        public virtual void OnEnable()
        {
            scriptableObject = (ShapeSO)target;

            shape = serializedObject.FindProperty("shape");

            position = shape.FindPropertyRelative("translation");
            eulerRotation = shape.FindPropertyRelative("eulerRotation");
            scale = shape.FindPropertyRelative("scale");
        }

        public override void OnInspectorGUI()
        {
            ShapeEditors.TransformEditor(position, eulerRotation, scale);
        }

        public abstract void DuringSceneGUI(SceneView sceneView);
    }
}
#endif