using UnityEditor;
using UnityEngine;

namespace Helpers.TagSelector.Editor
{
    [CustomPropertyDrawer(typeof(TagSelectorAttribute))]
    public class TagSelectorDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Make sure this is modifying a string
            if (property.propertyType != SerializedPropertyType.String)
            {
                EditorGUI.HelpBox(position, "TagSelector attribute can only be used on strings.", MessageType.Error);
                return;
            }

            EditorGUI.BeginProperty(position, label, property);
        
            // Get all tags from Unity's Tag Manager
            string[] allTags = UnityEditorInternal.InternalEditorUtility.tags;
            string currentTag = property.stringValue;

            // Find the index of the currently assigned tag
            int currentIndex = -1;
            if (!string.IsNullOrEmpty(currentTag))
            {
                // Using a simple loop is often clearer and sufficient for editor tools
                for (int i = 0; i < allTags.Length; i++)
                {
                    if (allTags[i] == currentTag)
                    {
                        currentIndex = i;
                        break;
                    }
                }
            }
        
            // Draw the popup
            int newIndex = EditorGUI.Popup(position, label.text, currentIndex, allTags);

            // If the user selected a new tag, update the property
            if (newIndex != currentIndex)
            {
                property.stringValue = newIndex > 0 ? allTags[newIndex] : string.Empty;
            
                //Debug.Log(property.stringValue);
            }

            EditorGUI.EndProperty();
        }
    }
}