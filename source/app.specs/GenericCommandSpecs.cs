using System.Collections.Generic;
using Machine.Specifications;
using app.web;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
  [Subject(typeof(GenericFeature<ViewDepartmentInDepartmentRequest,DepartmentItem>))]
  public class GenericCommandSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature,
                                      GenericFeature<ViewDepartmentInDepartmentRequest,DepartmentItem>>
    {
    }

    public class when_run : concern
    {
        Establish c = () =>
        {
            request = fake.an<IContainRequestDetails>();
            information_in_the_store_finder = depends.on<IFindInformationInTheStore>();
            display_engine = depends.on<IDisplayInformation>();
            the_sub_departments = new List<DepartmentItem>();

            request.setup(x => x.map<ViewDepartmentInDepartmentRequest>()).Return(departments_request);
            information_in_the_store_finder.setup(x => x.get_the_departments_using(departments_request)).Return(the_sub_departments);
        };

        Because b = () =>
          sut.process(request);

        It should_get_the_list_of_the_departments_within_the_main_department = () =>
        {

        };

        It should_display_the_departments_within_the_main_department = () =>
          display_engine.received(x => x.display(the_sub_departments));


        static IFindInformationInTheStore information_in_the_store_finder;
        static IContainRequestDetails request;
        static IEnumerable<DepartmentItem> the_sub_departments;
        static IDisplayInformation display_engine;
        static int department_id;
        static ViewDepartmentInDepartmentRequest departments_request;
    }
  }
}