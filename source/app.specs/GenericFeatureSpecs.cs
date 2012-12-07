using System.Collections;
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
  [Subject(typeof(GenericFeature<ViewDepartmentInDepartmentRequest, IEnumerable<DepartmentItem>>))]
  public class GenericFeatureSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature,
                                      GenericFeature<ViewDepartmentInDepartmentRequest,IEnumerable<DepartmentItem>>>
    {
    }

    public class when_run : concern
    {
        Establish c = () =>
        {
            request = fake.an<IContainRequestDetails>();
            display_engine = depends.on<IDisplayInformation>();
            the_sub_departments = new List<DepartmentItem>();
            departments_request = fake.an<ViewDepartmentInDepartmentRequest>();
            request.setup(x => x.map<ViewDepartmentInDepartmentRequest>()).Return(departments_request);
            searcher =
                depends.on<IExecuteTheCatalogSearch<IEnumerable<DepartmentItem>, ViewDepartmentInDepartmentRequest>>();
            searcher.setup(x => x.Execute(departments_request)).Return(the_sub_departments);
        };

        Because b = () =>
          sut.process(request);

        It should_get_the_list_of_the_departments_within_the_main_department = () =>
        {

        };

        private It should_display_the_departments_within_the_main_department = () =>
            {
                request.received(x => x.map<ViewDepartmentInDepartmentRequest>());
                display_engine.received(x => x.display(the_sub_departments));
            };

        static IContainRequestDetails request;
        static IEnumerable<DepartmentItem> the_sub_departments;
        static IDisplayInformation display_engine;
        static ViewDepartmentInDepartmentRequest departments_request;
        static IExecuteTheCatalogSearch<IEnumerable<DepartmentItem>, ViewDepartmentInDepartmentRequest> searcher;
    }
  }
}