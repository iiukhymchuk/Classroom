using Front.Contracts;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Front.Shared
{
    public abstract class TableGridLogic<TableItem> : ComponentBase
    {
        [Parameter] public RenderFragment GridHeader { get; set; }
        [Parameter] public RenderFragment<TableItem> GridRow { get; set; }
        [Parameter] public IEnumerable<TableItem> Items { get; set; }
        [Parameter] public int PageSize { get; set; }

        [Inject] public NavigationManager UriHelper { get; set; }

        protected int TotalPagesNumber { get; set; }
        protected IEnumerable<TableItem> CurrentItems { get; set; }

        protected enum Direction { Previous = -1, None = 0, Next = 1 }

        protected int curentPageNumber;
        protected int startPageNumber;
        protected int endPageNumber;

        int pagerSize;

        protected override async Task OnInitializedAsync()
        {
            if (Items is null || Items.Count() == 0)
                return;

            curentPageNumber = 1;
            startPageNumber = 1;
            pagerSize = 3;
            endPageNumber = 3;

            await Task.CompletedTask;
        }

        protected override async Task OnParametersSetAsync()
        {
            if (Items is null || Items.Count() == 0)
                return;

            TotalPagesNumber = (int)Math.Ceiling(Items.Count() / (double)PageSize);
            endPageNumber = Math.Min(endPageNumber, TotalPagesNumber);

            CurrentItems = GetCurrentItemList(curentPageNumber);

            await Task.CompletedTask;

            StateHasChanged();
        }

        protected void OnClickRow(TableItem item)
        {
            var navigationItem = item as INavigationItem;
            if (navigationItem != null)
                UriHelper.NavigateTo(navigationItem.NavigationLink);
        }

        protected void GoToPage(int page)
        {
            GoToPageInternal(page);
        }

        protected void GoToPage(Direction direction)
        {
            var page = Math.Max(curentPageNumber + (int)direction, 1);
            page = Math.Min(page, TotalPagesNumber);

            GoToPageInternal(page);

            if (curentPageNumber < startPageNumber || curentPageNumber > endPageNumber)
            {
                Direction dir = curentPageNumber < startPageNumber ? Direction.Previous : Direction.Next;
                FloatPager(dir);
            }
        }

        protected void FloatPager(Direction direction)
        {
            if (!MayPagerFloat(direction))
                return;

            if (direction == Direction.Previous)
            {
                startPageNumber = Math.Max(startPageNumber - pagerSize, 1);
                endPageNumber = Math.Max(startPageNumber + pagerSize - 1, pagerSize);
            }

            if (direction == Direction.Next)
            {
                startPageNumber = Math.Min(endPageNumber + 1, TotalPagesNumber);
                endPageNumber = Math.Min(endPageNumber + pagerSize, TotalPagesNumber);
            }
        }

        bool MayPagerFloat(Direction direction)
        {
            if (direction == Direction.Next)
                return endPageNumber < TotalPagesNumber;
            if (direction == Direction.Previous)
                return startPageNumber > 1;
            return false;
        }

        void GoToPageInternal(int pageNumber)
        {
            curentPageNumber = pageNumber;
            CurrentItems = GetCurrentItemList(curentPageNumber);

            StateHasChanged();
        }

        IEnumerable<TableItem> GetCurrentItemList(int pageNumber)
        {
            return Items.Skip((pageNumber - 1) * PageSize).Take(PageSize);
        }
    }
}