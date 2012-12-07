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
            Establish c = () =>
                {
                    request = fake.an<NullRequest>();
                    departments = fake.an<IEnumerable<DepartmentItem>>();
                    catalog = fake.an<IFindInformationInTheStore>();
                    catalog.setup(x => x.get_the_main_departments_in_the_store()).Return(departments);
                    find_data = catalog.get_the_main_departments_in_the_store;
                    depends.on(find_data);

                };

            Because b = () =>
                results = sut.Execute(request);

            It should_get_the_list_of_the_departments_within_the_main_department = () =>
                {
                    results.ShouldBeTheSameAs(departments);
                };


            static NullRequest request;
            static IEnumerable<DepartmentItem> results;
            static IEnumerable<DepartmentItem> departments;
            static FindData<IEnumerable<DepartmentItem>> find_data;
            static IFindInformationInTheStore catalog;

        }
    }
}