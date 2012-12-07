using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app.web.application.catalogbrowsing.stubs;
using app.web.core;
using app.web.core.stubs;

namespace app.web.application.catalogbrowsing
{
    public class GenericFeature<TRequestType, TItem> : ISupportAUserFeature
    {
        IDisplayInformation display_engine;
        private IExecuteTheCatalogSearch<TItem, TRequestType> searcher; 

        public GenericFeature(IDisplayInformation display_engine,
            IExecuteTheCatalogSearch<TItem, TRequestType> searcher)
        {
          this.display_engine = display_engine;
          this.searcher = searcher;
        }

        public void process(IContainRequestDetails request)
        {
            display_engine.display(searcher.Execute(request.map<TRequestType>()));
        }
    }

    public delegate TItem FindData<TItem, TRequestType>(TRequestType request);
}
