namespace UralHedgehog
{
    namespace UI
    {
        public class UIManager
        {
            private readonly UIRoot _uiRoot;
            
            public UIManager(UIRoot uiRoot)
            {
                _uiRoot = uiRoot;
            }

            #region Open
            
            public void OpenViewTopPanel()
            {
                _uiRoot.Create<Config>(nameof(PTopPanel), EntryPoint.Instance.Config);
            }

            #endregion

            //TODO: Методы Close могут понадобиться для принудительного закрытия виджета, либо если виджет не имеет кнопки закрыть.
            //TODO: Его можно закрыть и уничтожить из любого места.
            #region Close

            

            #endregion
        }
    }
}