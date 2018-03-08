namespace Tony.Common.Infrastructure.Events
{
    public enum PageParamKey
    {
        None = 0,
        FormalPage = 1,
        Account,
        Income,
        Expenditure,
        Transfer,
        PagedListPageIndex,
        PagedListCurrnetPageIndex,
        PagedListParentType
    }

    public enum SeatStatus
    {
        Available, NotAvailable, Sold
    }
}
