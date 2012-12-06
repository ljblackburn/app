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
        IFindInformationInTheStore store_catalog;
        IDisplayInformation display_engine;
        private FindData<TItem, TRequestType> data_finder;

        public GenericFeature() : this(new StubStoreCatalog(), new StubDisplayEngine())
        {
        }

        public GenericFeature(IFindInformationInTheStore information_in_the_store_catalog,
                                                IDisplayInformation department_viewer)
        {
          this.store_catalog = information_in_the_store_catalog;
          this.display_engine = department_viewer;
        }

        public FindData<TItem,TRequestType> datafinder
        {
            set { this.data_finder = value; }
        }

        public void process(IContainRequestDetails request)
        {
            var mapped_request = request.map<TRequestType>();
            IEnumerable<TItem> departments = data_finder(mapped_request);
            display_engine.display(departments);
        }
    }

    public delegate IEnumerable<TItem> FindData<TItem, TRequestType>(TRequestType request);
}
