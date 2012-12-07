using System.Collections.Generic;
using Machine.Specifications;
using Rhino.Mocks;
using app.web;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
    [Subject(typeof (NullRequestCatalogSearcher<IEnumerable<DepartmentItem>>))]
    public class NullRequestCatalogSearcherSpecs
    {
        public abstract class concern :
            Observes<IExecuteTheCatalogSearch<IEnumerable<DepartmentItem>, NullRequest>,
                NullRequestCatalogSearcher<IEnumerable<DepartmentItem>>>
        {
        }

        public class when_run : concern
        {
            private Establish c = () =>
                {
                };

            private Because b = () =>
                result = sut.Execute(request);

            private It should_get_the_list_of_the_departments_within_the_main_department = () =>
                {
                    result.ShouldNotBeNull();
                };


            private static NullRequest request;
            private static IEnumerable<DepartmentItem> result;
        }
    }
}