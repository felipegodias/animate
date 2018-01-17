using System;
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Animate.Core.Editor.Styles {

    /// <summary>
    /// </summary>
    public class ScriptableObjectStyle {

        /// <summary>
        /// </summary>
        private const string kEditorTypeSStylesField = "s_Styles";

        /// <summary>
        /// </summary>
        private const string kSStylesTypeInspectorBigField = "inspectorBig";

        /// <summary>
        /// </summary>
        private const string kEditorGUITypeGUIContentsField = "GUIContents";

        /// <summary>
        /// </summary>
        private const string kGUIContentsTypeHelpIconField = "<helpIcon>k__BackingField";

        /// <summary>
        /// </summary>
        private const string kGUIContentsTypeSettingsIconField = "<titleSettingsIcon>k__BackingField";

        /// <summary>
        /// </summary>
        private const string kPluginIconNamespace = "Animate.Core.Editor.Resources.icon.png";

        /// <summary>
        /// </summary>
        private GUIStyle inspectorBig;

        /// <summary>
        /// </summary>
        private GUIContent helpIcon;

        /// <summary>
        /// </summary>
        private GUIContent settingsIcon;

        /// <summary>
        /// </summary>
        private GUIContent icon;

        /// <summary>
        /// </summary>
        public GUIStyle InspectorBig {
            get {
                if (this.inspectorBig != null) {
                    return this.inspectorBig;
                }

                Type editorType = typeof(UnityEditor.Editor);
                FieldInfo sStylesFieldInfo = editorType.GetField(kEditorTypeSStylesField,
                    BindingFlags.NonPublic | BindingFlags.Static);

                if (sStylesFieldInfo == null) {
                    this.inspectorBig = GUIStyle.none;
                    return this.inspectorBig;
                }

                object sStyles = sStylesFieldInfo.GetValue(null);
                if (sStyles == null) {
                    sStyles = Activator.CreateInstance(sStylesFieldInfo.FieldType);
                    sStylesFieldInfo.SetValue(null, sStyles);
                }

                Type styleType = sStyles.GetType();
                FieldInfo inspectorBigFieldInfo = styleType.GetField(kSStylesTypeInspectorBigField);
                this.inspectorBig = inspectorBigFieldInfo.GetValue(sStyles) as GUIStyle;
                return this.inspectorBig;
            }
        }

        /// <summary>
        /// </summary>
        public GUIContent HelpIcon {
            get {
                if (this.helpIcon != null) {
                    return this.helpIcon;
                }

                Type editorGuiType = typeof(EditorGUI);
                Type guiContentsType =
                    editorGuiType.GetNestedType(kEditorGUITypeGUIContentsField, BindingFlags.NonPublic);
                FieldInfo helpIconFieldInfo = guiContentsType.GetField(kGUIContentsTypeHelpIconField,
                    BindingFlags.Static | BindingFlags.NonPublic);

                if (helpIconFieldInfo == null) {
                    this.helpIcon = GUIContent.none;
                    return this.helpIcon;
                }

                this.helpIcon = helpIconFieldInfo.GetValue(null) as GUIContent;
                return this.helpIcon;
            }
        }

        /// <summary>
        /// </summary>
        public GUIContent SettingsIcon {
            get {
                if (this.settingsIcon != null) {
                    return this.settingsIcon;
                }

                Type editorGuiType = typeof(EditorGUI);
                Type guiContentsType =
                    editorGuiType.GetNestedType(kEditorGUITypeGUIContentsField, BindingFlags.NonPublic);
                FieldInfo titleSettingsIconFieldInfo = guiContentsType.GetField(
                    kGUIContentsTypeSettingsIconField,
                    BindingFlags.Static | BindingFlags.NonPublic);

                if (titleSettingsIconFieldInfo == null) {
                    this.settingsIcon = GUIContent.none;
                    return this.settingsIcon;
                }

                this.settingsIcon = titleSettingsIconFieldInfo.GetValue(null) as GUIContent;
                return this.settingsIcon;
            }
        }

        /// <summary>
        /// </summary>
        public GUIContent Icon {
            get {
                if (this.icon != null) {
                    return this.icon;
                }

                Texture2D iconTexture = new Texture2D(4, 4);
                Assembly assembly = Assembly.GetExecutingAssembly();
                Stream file = assembly.GetManifestResourceStream(kPluginIconNamespace);

                if (file == null) {
                    this.icon = GUIContent.none;
                    return this.icon;
                }

                byte[] imageData = new byte[file.Length];
                file.Read(imageData, 0, (int) file.Length);
                file.Dispose();

                iconTexture.LoadImage(imageData);
                this.icon = new GUIContent(iconTexture);
                return this.icon;
            }
        }

    }

}