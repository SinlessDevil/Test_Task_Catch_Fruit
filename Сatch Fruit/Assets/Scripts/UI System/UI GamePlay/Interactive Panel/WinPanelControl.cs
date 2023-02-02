namespace UISystem.UIGamePlay.InteractivePanel
{
    public sealed class WinPanelControl : AbstractPanelControl
    {
        private void OnEnable()
        {
            GamePlayButtons.ButtonClickExitToMenuWinPanelEvent += ExitToMeinMenu;
            GamePlayButtons.ButtonClickNextLevelWinPanelEvent += RestartThisScene;
        }

        private void OnDisable()
        {
            GamePlayButtons.ButtonClickExitToMenuWinPanelEvent -= ExitToMeinMenu;
            GamePlayButtons.ButtonClickNextLevelWinPanelEvent -= RestartThisScene;
        }
    }
}