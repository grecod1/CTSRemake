using System.Web;
using System.Web.Optimization;

namespace Helpline
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(                                                
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Scripts/jquery-ui.js",
                        "~/Scripts/AlertFade.js",
                        "~/Scripts/DropdownLists.js",
                        "~/Scripts/ScreenWidth.js",
                        "~/Scripts/DisplayName.js",
                        "~/Scripts/numericInputScript.js",
                        "~/Scripts/DetermineBrowser.js"
                        ));            

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/unobtrusive-bootstrap.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/TicketIndex").Include(
                        "~/Scripts/DatePicker.js",
                        "~/Scripts/ResetButton.js",                        
                        "~/Scripts/IndexTable.js",                        
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.bootstrap4.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryArchives").Include(
                        "~/Scripts/ArchiveDatePicker.js",
                        "~/Scripts/ResetButton.js",
                        "~/Scripts/ArchiveIndexTable.js",                        
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.bootstrap4.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryEventLogs").Include(
                        "~/Scripts/DatePicker.js",
                        "~/Scripts/EventLogResetButton.js",
                        "~/Scripts/EventLogIndexTable.js",
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.bootstrap4.js"));

            bundles.Add(new ScriptBundle("~/bundles/AdminEdit").Include(
                        "~/Scripts/AdminEdit.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/Programs").Include(
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.bootstrap4.js",
                        "~/Scripts/ProgramIndexTable.js"));

            bundles.Add(new ScriptBundle("~/bundles/RequestTypes").Include(
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.bootstrap4.js",
                        "~/Scripts/RequestTypeIndexTable.js"));

            bundles.Add(new ScriptBundle("~/bundles/RoutingCategories").Include(
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.bootstrap4.js",
                        "~/Scripts/RoutingCategoryIndexTable.js"));

            bundles.Add(new ScriptBundle("~/bundles/AddRoutingCategory").Include(
                        "~/Scripts/AddEmailList.js",
                        "~/Scripts/DetermineBrowser.js",
                        "~/Scripts/AlertFade.js"));

            bundles.Add(new ScriptBundle("~/bundles/EditRoutingCategory").Include(
                        "~/Scripts/AdminEdit.js",
                        "~/Scripts/EditEmailList.js"));

            bundles.Add(new ScriptBundle("~/bundles/OfficeLocations").Include(
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.bootstrap4.js",
                        "~/Scripts/OfficeLocationIndexTable.js"));

            bundles.Add(new ScriptBundle("~/bundles/Users").Include(
                        "~/Scripts/DataTables/jquery.dataTables.js",
                        "~/Scripts/DataTables/dataTables.bootstrap4.js",
                        "~/Scripts/UserIndexTable.js"));            

            bundles.Add(new ScriptBundle("~/bundles/jqueryDetails").Include(
                        "~/Scripts/DetailsAccordian.js",
                        "~/Scripts/Collapse.js",
                        "~/Scripts/AlertFade.js",
                        "~/Scripts/DetailsModal.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryCreate").Include(
                        "~/Scripts/SameAddress.js",
                        "~/Scripts/POBox.js",
                        "~/Scripts/AddPhoneList.js",
                        "~/Scripts/AddressInvolved.js",
                        "~/Scripts/ConfirmationModal.js",
                        "~/Scripts/PasteControl.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryEdit").Include(
                        "~/Scripts/EditTicket.js",
                        "~/Scripts/AddressInvolved.js",
                        "~/Scripts/POBox.js",
                        "~/Scripts/SameAddress.js",
                        "~/Scripts/EditPhoneList.js",
                        "~/Scripts/PasteControl.js"));

            bundles.Add(new ScriptBundle("~/bundles/images").Include(
                        "~/Scripts/TicketImages.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryReports").Include(
                        "~/Scripts/DatePicker.js",
                        "~/Scripts/Chart.js",
                        "~/Scripts/ProgramBarChart.js",
                        "~/Scripts/ProgramLineGraph.js"));
            
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.bundle.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/bootstrap-CTS.css",
                      "~/Content/font-awesome.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/jquery-ui.structure.css",
                      "~/Content/jquery-ui.theme.css",                      
                      "~/Content/DataTables/css/dataTables.bootstrap4.css",
                      "~/Content/DataTables/css/dataTables.bootstrap.css",
                      "~/Content/Site.css"));

        }
    }
}