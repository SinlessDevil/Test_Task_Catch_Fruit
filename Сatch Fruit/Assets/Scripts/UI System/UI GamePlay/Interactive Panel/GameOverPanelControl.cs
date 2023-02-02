namespace UISystem.UIGamePlay.InteractivePanel
{
    public sealed class GameOverPanelControl : AbstractPanelControl
    {
        private void OnEnable()
        {
            GamePlayButtons.ButtonClickExitTiMenuGameOverPanelEvent += ExitToMeinMenu;
            GamePlayButtons.ButtonClickRestartGameOverPanelEvent += RestartThisScene;
        }

        private void OnDisable()
        {
            GamePlayButtons.ButtonClickExitTiMenuGameOverPanelEvent -= ExitToMeinMenu;
            GamePlayButtons.ButtonClickRestartGameOverPanelEvent -= RestartThisScene;
        }
    }
}