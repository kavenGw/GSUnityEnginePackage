using System;
using GS.NativeDialog;
using GSEngine.Extension;
using GSEngine.SingleTon;
using GSEngine.Tools;
using GSEngine.Xlsx;
using UI.SceneManager;
using UI.UIManager;
using Unity.Transforms;

namespace DefaultNamespace
{
    public static class NativeDialogManager
    {
        public static void OpenNetworkErrorDialog()
        {
            OpenDialog("Alert", "ServiceUnavailable", "Ok",(() => GSSceneTool.LoadScene(typeof(SplashScene)).WrapErrors()));
        }
        
        public static void OpenDialog(string title,string content,string button_name,Action cb)
        {
#if UNITY_TVOS
            UICommonDialogScene.OpenCommonDialog1(title,content,button_name,(go => cb()),show_close:false);
#else
            GSNativeDialogTool.ShowDialog(
                GSTranslateHelp.Translate(title),
                GSTranslateHelp.Translate(content),
                GSTranslateHelp.Translate(button_name),
                cb
            );
#endif
        }
        
        public static void OpenDialog(string title,string content,string button_name,string button_cancel_name,Action cb,Action cancel_action)
        {
#if UNITY_TVOS
            UICommonDialogScene.OpenCommonDialog2(title,content,button_name,button_cancel_name,(go => cb()),(go => cancel_action()),show_close:false);
#else
            GSNativeDialogTool.ShowDialog(
                GSTranslateHelp.Translate(title),
                GSTranslateHelp.Translate(content),
                GSTranslateHelp.Translate(button_name),
                cb,
                GSTranslateHelp.Translate(button_cancel_name),
                cancel_action
            );
#endif
        }
    }
}