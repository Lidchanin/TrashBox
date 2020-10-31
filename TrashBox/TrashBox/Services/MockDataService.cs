namespace TrashBox.Services
{
    public partial class MockDataService : IMockDataService
    {
        #region Instance

        private static IMockDataService _instance;

        public static IMockDataService Instance => _instance ??= new MockDataService();

        #endregion Instance
    }
}