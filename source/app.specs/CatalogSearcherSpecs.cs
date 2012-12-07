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
    [Subject(typeof (CatalogSearcher<IEnumerable<DepartmentItem>, ViewDepartmentInDepartmentRequest>))]
    public class CatalogSearcherSpecs
    {
        public abstract class concern :
            Observes<IExecuteTheCatalogSearch<IEnumerable<DepartmentItem>, ViewDepartmentInDepartmentRequest>,
                CatalogSearcher<IEnumerable<DepartmentItem>, ViewDepartmentInDepartmentRequest>>
        {
        }

        public class when_run : concern
        {
            Establish c = () =>
                {
                    request = fake.an<ViewDepartmentInDepartmentRequest>();
                    departments = fake.an<IEnumerable<DepartmentItem>>();
                    catalog = fake.an<IFindInformationInTheStore>();
                    catalog.setup(x => x.get_the_departments_using(request)).Return(departments);
                    find_data = catalog.get_the_departments_using;
                    depends.on(find_data);
                };

            Because b = () =>
                results = sut.Execute(request);

            It should_get_the_list_of_the_departments_within_the_main_department = () =>
                {
                    results.ShouldBeTheSameAs(departments);
                };


            static ViewDepartmentInDepartmentRequest request;
            static IEnumerable<DepartmentItem> departments;
            static IEnumerable<DepartmentItem> results; 
            static FindData<IEnumerable<DepartmentItem>, ViewDepartmentInDepartmentRequest> find_data;
            static IFindInformationInTheStore catalog;
        }
    }
}