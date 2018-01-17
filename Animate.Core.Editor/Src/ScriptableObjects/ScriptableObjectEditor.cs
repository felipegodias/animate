using Animate.Core.Editor.Styles;
using UnityEditor;
using UnityEngine;

namespace Animate.Core.Editor.ScriptableObjects {

    public abstract class ScriptableObjectEditor : UnityEditor.Editor {

        /// <summary>
        /// </summary>
        private static ScriptableObjectStyle style;

        /// <summary>
        /// </summary>
        private readonly float headerHeight = 45;

        /// <summary>
        /// </summary>
        private readonly float headerOffset = 3;

        /// <summary>
        /// </summary>
        private Rect iconRect = new Rect(9, 7, 25, 30);

        /// <summary>
        /// </summary>
        private Rect titleRect = new Rect(-1, -3, 200, 19);

        /// <summary>
        /// </summary>
        private Rect settingsRect = new Rect(-1, 6, 16, 16);

        /// <summary>
        /// </summary>
        private Rect helpRect = new Rect(-3, 0, 16, 16);

        /// <summary>
        /// </summary>
        private Rect headerArea;

        /// <summary>
        /// </summary>
        private Rect iconArea;

        /// <summary>
        /// </summary>
        private Rect titleArea;

        /// <summary>
        /// </summary>
        private Rect settingsArea;

        /// <summary>
        /// </summary>
        private Rect helpArea;

        /// <summary>
        /// </summary>
        protected virtual bool DrawSettingsButton { get; }

        /// <summary>
        /// </summary>
        protected virtual string HelpUrl { get; }

        /// <summary>
        /// </summary>
        protected virtual string FallbackName { get; }

        /// <summary>
        /// </summary>
        protected virtual void OnSettingsButtonClick() { }

        /// <summary>
        /// </summary>
        protected virtual void OnMenuGUI() { }

        /// <summary>
        /// </summary>
        protected virtual void OnContentGUI() { }

        /// <summary>
        /// </summary>
        protected override void OnHeaderGUI() {
            if (style == null) {
                style = new ScriptableObjectStyle();
            }

            this.headerArea = EditorGUILayout.GetControlRect(false, this.headerHeight);

            this.headerArea = new Rect(this.headerArea.xMin - this.headerOffset, this.headerArea.yMin,
                this.headerArea.xMax + this.headerOffset,
                this.headerArea.yMax);

            this.iconArea = new Rect(this.headerArea.xMin + this.iconRect.xMin,
                this.headerArea.yMin + this.iconRect.yMin, this.iconRect.width, this.iconRect.height);

            this.titleArea = new Rect(this.iconArea.xMin + this.iconArea.xMax + this.titleRect.xMin,
                this.iconArea.yMin + this.titleRect.yMin, this.titleRect.width, this.titleRect.height);

            if (this.DrawSettingsButton) {
                this.settingsArea = new Rect(this.headerArea.xMax + this.settingsRect.xMin - this.settingsRect.width,
                    this.headerArea.yMin + this.settingsRect.yMin, this.settingsRect.width, this.settingsRect.height);

                this.helpArea = new Rect(this.settingsArea.xMin + this.helpRect.xMin - this.helpRect.width,
                    this.settingsArea.yMin + this.helpRect.yMin, this.helpRect.width, this.helpRect.height);
            } else {
                this.helpArea = new Rect(this.headerArea.xMax + this.settingsRect.xMin - this.helpArea.width,
                    this.headerArea.yMin + this.settingsRect.yMin, this.helpArea.width, this.helpArea.height);
            }

            if (Event.current != null && Event.current.type == EventType.Repaint) {
                int controlId = 0;
                style.InspectorBig.Draw(this.headerArea, GUIContent.none, controlId++);
                GUIStyle.none.Draw(this.iconArea, style.Icon, controlId++);
                string title = this.target.name != string.Empty ? this.target.name : this.FallbackName;
                title = ObjectNames.NicifyVariableName(title);
                EditorStyles.largeLabel.Draw(this.titleArea, new GUIContent(title), controlId);
            }

            if (this.DrawSettingsButton && GUI.Button(this.settingsArea, style.SettingsIcon, GUIStyle.none)) {
                this.OnSettingsButtonClick();
            }

            if (this.HelpUrl != null && GUI.Button(this.helpArea, style.HelpIcon, GUIStyle.none)) {
                Application.OpenURL(this.HelpUrl);
            }
        }

    }

}