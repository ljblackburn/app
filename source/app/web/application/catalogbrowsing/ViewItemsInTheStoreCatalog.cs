// -----------------------------------------------------------------------
// <copyright file="ViewItemsInTheStoreCatalog.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

using app.web.core;

namespace app.web.application.catalogbrowsing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class ViewItemsInTheStoreCatalog : ISupportAUserFeature
    {
        ISupportAUserFeature feature;

        public ViewItemsInTheStoreCatalog(ISupportAUserFeature feature)
        {
            this.feature = feature;
        }

        public void process(IContainRequestDetails request)
        {
            feature.process(request);
        }
    }
}
