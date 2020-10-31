using System.Collections.Generic;
using TrashBox.Models;

namespace TrashBox.Services
{
    public partial interface IMockDataService
    {
        IList<WatchInfo> GetBabyWatches();

        IList<WatchInfo> GetFemaleWatches();

        IList<WatchInfo> GetMaleWatches();

        IList<WatchInfo> GetWatches();

        IList<WatchInfo> GetNewWatches();

        IList<WatchInfo> GetDiscountWatches();
    }
}