using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.web.application.catalogbrowsing
{
    public class NullRequestCatalogSearcher<TItem> : IExecuteTheCatalogSearch<TItem, NullRequest>
    {
        private FindData<TItem> data_finder;

        public NullRequestCatalogSearcher(FindData<TItem> data_finder)
        {
            this.data_finder = data_finder;
        }

        public TItem Execute(NullRequest request)
        {
            return data_finder();
        }
    }

    public delegate TItem FindData<TItem>();
}