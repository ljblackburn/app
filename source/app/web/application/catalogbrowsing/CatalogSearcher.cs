using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.web.application.catalogbrowsing
{
    public interface IExecuteTheCatalogSearch<TItem, TRequestType>
    {
        TItem Execute(TRequestType request);
    }

    public class CatalogSearcher<TItem, TRequestType> : IExecuteTheCatalogSearch<TItem, TRequestType>
    {
        private FindData<TItem, TRequestType> data_finder;

        public CatalogSearcher(FindData<TItem, TRequestType> data_finder)
        {
            this.data_finder = data_finder;
        }

        public TItem Execute(TRequestType request)
        {
            return data_finder(request);
        }
    }
}
